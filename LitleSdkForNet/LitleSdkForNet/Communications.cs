using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Tamir.SharpSsh.jsch;

namespace Litle.Sdk
{
    public class Communications
    {
        private readonly IDictionary<string, StringBuilder> _cache;

        static Communications()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }
        public Communications(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
        }

        public static bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }

        public virtual string HttpPost(string xmlRequest, Dictionary<string, string> config)
        {
            var request = (HttpWebRequest)WebRequest.Create(config["url"]);
            request.ContentType = "text/xml";
            request.Method = "POST";
            request.ServicePoint.MaxIdleTime = 10000;
            request.ServicePoint.Expect100Continue = false;
            if (isProxyOn(config))
            {
                request.Proxy = new WebProxy(config["proxyHost"], int.Parse(config["proxyPort"]))
                {
                    BypassProxyOnLocal = true
                };
            }

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(xmlRequest);
            }

            var resp = request.GetResponse();
            var responseStream = resp.GetResponseStream();
            if (responseStream == null) return null;//TODO: Handle this as an exception in callers.
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd().Trim();
            }
        }

        public bool isProxyOn(Dictionary<string, string> config) => 
            config.ContainsKey("proxyHost") && (config["proxyHost"]?.Any() ?? false) &&
            config.ContainsKey("proxyPort") && (config["proxyPort"]?.Any() ?? false);

        public virtual string socketStream(string xmlRequestFilePath, string xmlResponseDestinationDirectory,
            Dictionary<string, string> config)
        {
            var url = config["onlineBatchUrl"];
            var port = int.Parse(config["onlineBatchPort"]);
            TcpClient tcpClient;
            SslStream sslStream;

            try
            {
                tcpClient = new TcpClient(url, port);
                sslStream = new SslStream(tcpClient.GetStream(), false, ValidateServerCertificate, null);
            }
            catch (SocketException e)
            {
                throw new LitleOnlineException("Error establishing a network connection", e);
            }

            try
            {
                sslStream.AuthenticateAsClient(url);
            }
            catch (AuthenticationException e)
            {
                tcpClient.Close();
                throw new LitleOnlineException("Error establishing a network connection - SSL Authencation failed", e);
            }

            var stringBuilder = _cache[xmlRequestFilePath];
            var buffer = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            sslStream.Write(buffer);
            sslStream.Flush();

            var batchName = Path.GetFileName(xmlRequestFilePath);
            var byteBuffer = new byte[2048];
            var messageData = new StringBuilder();
            int bytes;
            do
            {
                bytes = sslStream.Read(byteBuffer, 0, byteBuffer.Length);

                var decoder = Encoding.UTF8.GetDecoder();
                var chars = new char[decoder.GetCharCount(byteBuffer, 0, bytes)];
                decoder.GetChars(byteBuffer, 0, bytes, chars, 0);
                messageData.Append(chars);
            } while (bytes != 0);

            _cache.Add(xmlResponseDestinationDirectory + batchName, messageData);

            tcpClient.Close();
            sslStream.Close();

            return xmlResponseDestinationDirectory + batchName;
        }

        public virtual void FtpDropOff(string fileDirectory, string fileName, Dictionary<string, string> config)
        {
            ChannelSftp channelSftp;

            var url = config["sftpUrl"];
            var username = config["sftpUsername"];
            var password = config["sftpPassword"];
            var knownHostsFile = config["knownHostsFile"];
            var filePath = fileDirectory + fileName;
            var jsch = new JSch();
            jsch.setKnownHosts(knownHostsFile);

            var session = jsch.getSession(username, url);
            session.setPassword(password);

            try
            {
                session.connect();

                var channel = session.openChannel("sftp");
                channel.connect();
                channelSftp = (ChannelSftp) channel;
            }
            catch (SftpException e)
            {
                throw new LitleOnlineException("Error occured while attempting to establish an SFTP connection", e);
            }
            catch (JSchException e)
            {
                throw new LitleOnlineException("Error occured while attempting to establish an SFTP connection", e);
            }

            try
            {
                channelSftp.put(filePath, "inbound/" + fileName + ".prg", ChannelSftp.OVERWRITE);
                channelSftp.rename("inbound/" + fileName + ".prg", "inbound/" + fileName + ".asc");
            }
            catch (SftpException e)
            {
                throw new LitleOnlineException("Error occured while attempting to upload and save the file to SFTP", e);
            }

            channelSftp.quit();
            session.disconnect();
        }

        public virtual void FtpPoll(string fileName, int timeout, Dictionary<string, string> config)
        {
            fileName = fileName + ".asc";
            ChannelSftp channelSftp;

            var url = config["sftpUrl"];
            var username = config["sftpUsername"];
            var password = config["sftpPassword"];
            var knownHostsFile = config["knownHostsFile"];
            var jsch = new JSch();
            jsch.setKnownHosts(knownHostsFile);

            var session = jsch.getSession(username, url);
            session.setPassword(password);

            try
            {
                session.connect();

                var channel = session.openChannel("sftp");
                channel.connect();
                channelSftp = (ChannelSftp) channel;
            }
            catch (SftpException e)
            {
                throw new LitleOnlineException("Error occured while attempting to establish an SFTP connection", e);
            }
            
            SftpATTRS sftpAttrs = null;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                try
                {
                    sftpAttrs = channelSftp.lstat("outbound/" + fileName);
                }
                catch (SftpException)
                {
                    Thread.Sleep(30000);
                }
            } while (sftpAttrs == null && stopWatch.Elapsed.TotalMilliseconds <= timeout);
        }

        public virtual void FtpPickUp(string destinationFilePath, Dictionary<string, string> config, string fileName)
        {
            ChannelSftp channelSftp;
            
            var url = config["sftpUrl"];
            var username = config["sftpUsername"];
            var password = config["sftpPassword"];
            var knownHostsFile = config["knownHostsFile"];
            var jsch = new JSch();
            jsch.setKnownHosts(knownHostsFile);

            var session = jsch.getSession(username, url);
            session.setPassword(password);

            try
            {
                session.connect();

                var channel = session.openChannel("sftp");
                channel.connect();
                channelSftp = (ChannelSftp) channel;
            }
            catch (SftpException e)
            {
                throw new LitleOnlineException("Error occured while attempting to establish an SFTP connection", e);
            }

            try
            {
                channelSftp.get("outbound/" + fileName + ".asc", destinationFilePath);
                channelSftp.rm("outbound/" + fileName + ".asc");
            }
            catch (SftpException e)
            {
                throw new LitleOnlineException(
                    "Error occured while attempting to retrieve and save the file from SFTP", e);
            }

            channelSftp.quit();
            session.disconnect();
        }
    }
}
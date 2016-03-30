using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Tamir.SharpSsh.jsch;

namespace Litle.Sdk
{
    public class Communications
    {
        private static readonly object SynLock = new object();
        private readonly IDictionary<string, StringBuilder> _cache;

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
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers. 
            return false;
        }

        public void neuterXML(ref string inputXml)
        {
            const string pattern1 = "(?i)<number>.*?</number>";
            const string pattern2 = "(?i)<accNum>.*?</accNum>";

            var rgx1 = new Regex(pattern1);
            var rgx2 = new Regex(pattern2);
            inputXml = rgx1.Replace(inputXml, "<number>xxxxxxxxxxxxxxxx</number>");
            inputXml = rgx2.Replace(inputXml, "<accNum>xxxxxxxxxx</accNum>");
        }

        public void log(string logMessage, string logFile, bool neuter)
        {
            lock (SynLock)
            {
                if (neuter)
                {
                    neuterXML(ref logMessage);
                }
                var logWriter = new StreamWriter(logFile, true);
                var time = DateTime.Now;
                logWriter.WriteLine(time.ToString(CultureInfo.InvariantCulture));
                logWriter.WriteLine(logMessage + "\r\n");
                logWriter.Close();
            }
        }

        public virtual string HttpPost(string xmlRequest, Dictionary<string, string> config)
        {
            string logFile = null;
            if (config.ContainsKey("logFile"))
            {
                logFile = config["logFile"];
            }

            var uri = config["url"];
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 |
                                                   SecurityProtocolType.Tls;
            var req = (HttpWebRequest)WebRequest.Create(uri);

            var neuter = false;
            if (config.ContainsKey("neuterAccountNums"))
            {
                neuter = ("true".Equals(config["neuterAccountNums"]));
            }

            var printxml = false;
            if (config.ContainsKey("printxml"))
            {
                if ("true".Equals(config["printxml"]))
                {
                    printxml = true;
                }
            }
            if (printxml)
            {
                Console.WriteLine(xmlRequest);
                Console.WriteLine(logFile);
            }

            //log request
            if (logFile != null)
            {
                log(xmlRequest, logFile, neuter);
            }

            req.ContentType = "text/xml";
            req.Method = "POST";
            req.ServicePoint.MaxIdleTime = 10000;
            req.ServicePoint.Expect100Continue = false;
            if (isProxyOn(config))
            {
                req.Proxy = new WebProxy(config["proxyHost"], int.Parse(config["proxyPort"]))
                {
                    BypassProxyOnLocal = true
                };
            }

            // submit http request
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(xmlRequest);
            }

            // read response
            var resp = req.GetResponse();
            string xmlResponse;
            var responseStream = resp.GetResponseStream();
            if (responseStream == null) return null;//TODO: Handle this as an exception in callers.
            using (var reader = new StreamReader(responseStream))
            {
                xmlResponse = reader.ReadToEnd().Trim();
            }
            if (printxml)
            {
                Console.WriteLine(xmlResponse);
            }

            //log response
            if (logFile != null)
            {
                log(xmlResponse, logFile, neuter);
            }

            return xmlResponse;
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

            if ("true".Equals(config["printxml"]))
            {
                Console.WriteLine("Using XML File: " + xmlRequestFilePath);
            }

            var stringBuilder = _cache[xmlRequestFilePath];
            var buffer = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            sslStream.Write(buffer);
            sslStream.Flush();

            var batchName = Path.GetFileName(xmlRequestFilePath);
            if ("true".Equals(config["printxml"]))
            {
                Console.WriteLine("Writing to XML File: " + xmlResponseDestinationDirectory + batchName);
            }

            var byteBuffer = new byte[2048];
            var messageData = new StringBuilder();
            int bytes;
            do
            {
                // Read the client's test message.
                bytes = sslStream.Read(byteBuffer, 0, byteBuffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
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

            var printxml = config["printxml"] == "true";
            if (printxml)
            {
                Console.WriteLine("Sftp Url: " + url);
                Console.WriteLine("Username: " + username);
                Console.WriteLine("Known hosts file path: " + knownHostsFile);
            }

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
                if (printxml)
                {
                    Console.WriteLine("Dropping off local file " + filePath + " to inbound/" + fileName + ".prg");
                }
                channelSftp.put(filePath, "inbound/" + fileName + ".prg", ChannelSftp.OVERWRITE);
                if (printxml)
                {
                    Console.WriteLine("File copied - renaming from inbound/" + fileName + ".prg to inbound/" + fileName +
                                      ".asc");
                }
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
            var printxml = config["printxml"] == "true";
            if (printxml)
            {
                Console.WriteLine("Polling for outbound result file.  Timeout set to " + timeout +
                                  "ms. File to wait for is " + fileName);
            }
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

            //check if file exists
            SftpATTRS sftpAttrs = null;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                if (printxml)
                {
                    Console.WriteLine("Elapsed time is " + stopWatch.Elapsed.TotalMilliseconds);
                }
                try
                {
                    sftpAttrs = channelSftp.lstat("outbound/" + fileName);
                    if (printxml)
                    {
                        Console.WriteLine("Attrs of file are: " + sftpAttrs);
                    }
                }
                catch (SftpException e)
                {
                    if (printxml)
                    {
                        Console.WriteLine(e.message);
                    }
                    Thread.Sleep(30000);
                }
            } while (sftpAttrs == null && stopWatch.Elapsed.TotalMilliseconds <= timeout);
        }

        public virtual void FtpPickUp(string destinationFilePath, Dictionary<string, string> config, string fileName)
        {
            ChannelSftp channelSftp;

            var printxml = config["printxml"] == "true";

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
                if (printxml)
                {
                    Console.WriteLine("Picking up remote file outbound/" + fileName + ".asc");
                    Console.WriteLine("Putting it at " + destinationFilePath);
                }
                channelSftp.get("outbound/" + fileName + ".asc", destinationFilePath);
                if (printxml)
                {
                    Console.WriteLine("Removing remote file output/" + fileName + ".asc");
                }
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
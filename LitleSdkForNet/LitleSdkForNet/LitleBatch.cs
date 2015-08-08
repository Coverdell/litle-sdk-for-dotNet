using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class LitleRequest
    {
        private authentication _authentication;
        private readonly Dictionary<String, String> _config;
        private Communications _communication;
        private litleXmlSerializer _litleXmlSerializer;
        private int _numOfLitleBatchRequest;
        private int _numOfRfrRequest;
        public string FinalFilePath = null;
        private string _batchFilePath;
        private string _requestDirectory;
        private string _responseDirectory;
        private LitleTime _litleTime;
        private LitleFile _litleFile;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */

        public LitleRequest()
        {
            _config = new Dictionary<string, string>();

            _config["url"] = Settings.Default.url;
            _config["reportGroup"] = Settings.Default.reportGroup;
            _config["username"] = Settings.Default.username;
            _config["printxml"] = Settings.Default.printxml;
            _config["timeout"] = Settings.Default.timeout;
            _config["proxyHost"] = Settings.Default.proxyHost;
            _config["merchantId"] = Settings.Default.merchantId;
            _config["password"] = Settings.Default.password;
            _config["proxyPort"] = Settings.Default.proxyPort;
            _config["sftpUrl"] = Settings.Default.sftpUrl;
            _config["sftpUsername"] = Settings.Default.sftpUsername;
            _config["sftpPassword"] = Settings.Default.sftpPassword;
            _config["knownHostsFile"] = Settings.Default.knownHostsFile;
            _config["onlineBatchUrl"] = Settings.Default.onlineBatchUrl;
            _config["onlineBatchPort"] = Settings.Default.onlineBatchPort;
            _config["requestDirectory"] = Settings.Default.requestDirectory;
            _config["responseDirectory"] = Settings.Default.responseDirectory;

            InitializeRequest();
        }

        /**
         * Construct a LitleOnline specifying the configuration in code.  This should be used by integration that have another way
         * to specify their configuration settings or where different configurations are needed for different instances of LitleOnline.
         * 
         * Properties that *must* be set are:
         * url (eg https://payments.litle.com/vap/communicator/online)
         * reportGroup (eg "Default Report Group")
         * username
         * merchantId
         * password
         * timeout (in seconds)
         * Optional properties are:
         * proxyHost
         * proxyPort
         * printxml (possible values "true" and "false" - defaults to false)
         * sftpUrl
         * sftpUsername
         * sftpPassword
         * knownHostsFile
         * onlineBatchUrl
         * onlineBatchPort
         * requestDirectory
         * responseDirectory
         */
        public LitleRequest(Dictionary<String, String> config)
        {
            _config = config;
            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _communication = new Communications();

            _authentication = new authentication {user = _config["username"], password = _config["password"]};

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleXmlSerializer = new litleXmlSerializer();
            _litleTime = new LitleTime();
            _litleFile = new LitleFile();
        }

        public authentication GetAuthenication()
        {
            return _authentication;
        }

        public string GetRequestDirectory()
        {
            return _requestDirectory;
        }

        public string GetResponseDirectory()
        {
            return _responseDirectory;
        }

        public void SetCommunication(Communications communication)
        {
            _communication = communication;
        }

        public Communications GetCommunication()
        {
            return _communication;
        }

        public void SetLitleXmlSerializer(litleXmlSerializer litleXmlSerializer)
        {
            _litleXmlSerializer = litleXmlSerializer;
        }

        public litleXmlSerializer GetLitleXmlSerializer()
        {
            return _litleXmlSerializer;
        }

        public void SetLitleTime(LitleTime litleTime)
        {
            _litleTime = litleTime;
        }

        public LitleTime GetLitleTime()
        {
            return _litleTime;
        }

        public void SetLitleFile(LitleFile litleFile)
        {
            _litleFile = litleFile;
        }

        public LitleFile GetLitleFile()
        {
            return _litleFile;
        }

        public void AddBatch(batchRequest litleBatchRequest)
        {
            if (_numOfRfrRequest != 0)
            {
                throw new LitleOnlineException("Can not add a batch request to a batch with an RFRrequest!");
            }

            FillInReportGroup(litleBatchRequest);

            _batchFilePath = SerializeBatchRequestToFile(litleBatchRequest, _batchFilePath);
            _numOfLitleBatchRequest++;
        }

        public void AddRfrRequest(RFRRequest rfrRequest)
        {
            if (_numOfLitleBatchRequest != 0)
            {
                throw new LitleOnlineException("Can not add an RFRRequest to a batch with requests!");
            }
            if (_numOfRfrRequest >= 1)
            {
                throw new LitleOnlineException("Can not add more than one RFRRequest to a batch!");
            }

            _batchFilePath = SerializeRfrRequestToFile(rfrRequest, _batchFilePath);
            _numOfRfrRequest++;
        }

        public litleResponse SendToLitleWithStream()
        {
            var requestFilePath = Serialize();
            var responseFilePath = _communication.SocketStream(requestFilePath, _responseDirectory, _config);
            return _litleXmlSerializer.DeserializeObjectFromFile(responseFilePath);
        }

        public string SendToLitle()
        {
            var requestFilePath = Serialize();
            _communication.FtpDropOff(_requestDirectory, Path.GetFileName(requestFilePath), _config);
            return Path.GetFileName(requestFilePath);
        }
        
        public void BlockAndWaitForResponse(string fileName, int timeOut)
        {
            _communication.FtpPoll(fileName, timeOut, _config);
        }

        public litleResponse ReceiveFromLitle(string batchFileName)
        {
            _litleFile.CreateDirectory(_responseDirectory);
            _communication.FtpPickUp(_responseDirectory + batchFileName, _config, batchFileName);
            return _litleXmlSerializer.DeserializeObjectFromFile(_responseDirectory + batchFileName);
        }

        public string SerializeBatchRequestToFile(batchRequest litleBatchRequest, string filePath)
        {
            filePath = _litleFile.CreateRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_litleRequest.xml",
                _litleTime);
            var tempFilePath = litleBatchRequest.Serialize();

            _litleFile.AppendFileToFile(filePath, tempFilePath);
            return filePath;
        }

        public string SerializeRfrRequestToFile(RFRRequest rfrRequest, string filePath)
        {
            filePath = _litleFile.CreateRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_litleRequest.xml",
                _litleTime);
            var tempFilePath = rfrRequest.Serialize();

            _litleFile.AppendFileToFile(filePath, tempFilePath);
            return filePath;
        }

        public string Serialize()
        {
            var xmlHeader = "<?xml version='1.0' encoding='utf-8'?>\r\n<litleRequest version=\"9.3\"" +
                               " xmlns=\"http://www.litle.com/schema\" " +
                               "numBatchRequests=\"" + _numOfLitleBatchRequest + "\">";

            const string xmlFooter = "\r\n</litleRequest>";

            FinalFilePath = _litleFile.CreateRandomFile(_requestDirectory, Path.GetFileName(FinalFilePath), ".xml",
                _litleTime);
            var filePath = FinalFilePath;

            _litleFile.AppendLineToFile(FinalFilePath, xmlHeader);
            _litleFile.AppendLineToFile(FinalFilePath, _authentication.Serialize());

            if (_batchFilePath != null)
            {
                _litleFile.AppendFileToFile(FinalFilePath, _batchFilePath);
            }
            else
            {
                throw new LitleOnlineException("No batch was added to the LitleBatch!");
            }

            _litleFile.AppendLineToFile(FinalFilePath, xmlFooter);
            FinalFilePath = null;
            return filePath;
        }

        private void FillInReportGroup(batchRequest litleBatchRequest)
        {
            if (litleBatchRequest.reportGroup == null)
            {
                litleBatchRequest.reportGroup = _config["reportGroup"];
            }
        }
    }

    public class LitleFile
    {
        public virtual string CreateRandomFile(string fileDirectory, string fileName, string fileExtension,
            LitleTime litleTime)
        {
            string filePath;
            if (string.IsNullOrEmpty(fileName))
            {
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                fileName = litleTime.GetCurrentTime("MM-dd-yyyy_HH-mm-ss-ffff_") + RandomGen.NextString(8);
                filePath = fileDirectory + fileName + fileExtension;

                using (new FileStream(filePath, FileMode.Create))
                {
                }
            }
            else
            {
                filePath = fileDirectory + fileName;
            }

            return filePath;
        }

        public virtual string AppendLineToFile(string filePath, string lineToAppend)
        {
            using (var fs = new FileStream(filePath, FileMode.Append))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(lineToAppend);
            }

            return filePath;
        }
        
        public virtual string AppendFileToFile(string filePathToAppendTo, string filePathToAppend)
        {
            using (var fs = new FileStream(filePathToAppendTo, FileMode.Append))
            using (var fsr = new FileStream(filePathToAppend, FileMode.Open))
            {
                var buffer = new byte[16];
                int bytesRead;

                do
                {
                    bytesRead = fsr.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, bytesRead);
                } while (bytesRead > 0);
            }

            File.Delete(filePathToAppend);
            return filePathToAppendTo;
        }

        public virtual void CreateDirectory(string destinationFilePath)
        {
            var destinationDirectory = Path.GetDirectoryName(destinationFilePath);

            Debug.Assert(destinationDirectory != null, "destinationDirectory != null");
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
        }
    }

    public static class RandomGen
    {
        private static readonly RNGCryptoServiceProvider Global = new RNGCryptoServiceProvider();
        private static Random _local;

        public static int NextInt()
        {
            if (_local != null) return _local.Next();
            var buffer = new byte[8];
            Global.GetBytes(buffer);
            _local = new Random(BitConverter.ToInt32(buffer, 0));

            return _local.Next();
        }

        public static string NextString(int length)
        {
            var result = "";

            for (var i = 0; i < length; i++)
            {
                result += Convert.ToChar(NextInt()%('Z' - 'A') + 'A');
            }

            return result;
        }
    }

    public class LitleTime
    {
        public virtual String GetCurrentTime(String format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
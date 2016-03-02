using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class LitleRequest
    {
        private readonly IDictionary<string, StringBuilder> _memoryStreams;
        private Authentication _authentication;
        private readonly Dictionary<string, string> _config;
        private Communications _communication;
        private LitleXmlSerializer _litleXmlSerializer;
        private int _numOfLitleBatchRequest;
        private int _numOfRfrRequest;
        public string FinalFilePath;
        private string _batchFilePath;
        private string _requestDirectory;
        private string _responseDirectory;
        private LitleTime _litleTime;
        private LitleFile _litleFile;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */

        public LitleRequest(IDictionary<string, StringBuilder> memoryStreams)
        {
            _memoryStreams = memoryStreams;
            _config = new Dictionary<string, string>
            {
                ["url"] = Settings.Default.url,
                ["reportGroup"] = Settings.Default.reportGroup,
                ["username"] = Settings.Default.username,
                ["printxml"] = Settings.Default.printxml,
                ["timeout"] = Settings.Default.timeout,
                ["proxyHost"] = Settings.Default.proxyHost,
                ["merchantId"] = Settings.Default.merchantId,
                ["password"] = Settings.Default.password,
                ["proxyPort"] = Settings.Default.proxyPort,
                ["sftpUrl"] = Settings.Default.sftpUrl,
                ["sftpUsername"] = Settings.Default.sftpUsername,
                ["sftpPassword"] = Settings.Default.sftpPassword,
                ["knownHostsFile"] = Settings.Default.knownHostsFile,
                ["onlineBatchUrl"] = Settings.Default.onlineBatchUrl,
                ["onlineBatchPort"] = Settings.Default.onlineBatchPort,
                ["requestDirectory"] = Settings.Default.requestDirectory,
                ["responseDirectory"] = Settings.Default.responseDirectory
            };

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

        public LitleRequest(IDictionary<string, StringBuilder> memoryStreams, Dictionary<string, string> config)
        {
            _memoryStreams = memoryStreams;
            _config = config;

            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _communication = new Communications(_memoryStreams);
            _authentication = new Authentication
            {
                User = _config["username"],
                Password = _config["password"]
            };

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleXmlSerializer = new LitleXmlSerializer();
            _litleTime = new LitleTime();
            _litleFile = new LitleFile(_memoryStreams);
        }

        public Authentication GetAuthenication()
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

        public void SetLitleXmlSerializer(LitleXmlSerializer litleXmlSerializer)
        {
            _litleXmlSerializer = litleXmlSerializer;
        }

        public LitleXmlSerializer GetLitleXmlSerializer()
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

        public void AddBatch(BatchRequest litleBatchRequest)
        {
            if (_numOfRfrRequest != 0)
            {
                throw new LitleOnlineException("Can not add a batch request to a batch with an RFRrequest!");
            }

            FillInReportGroup(litleBatchRequest);

            _batchFilePath = SerializeBatchRequestToFile(litleBatchRequest, _batchFilePath);
            _numOfLitleBatchRequest++;
        }

        public void AddRfrRequest(RfrRequest rfrRequest)
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
            var litleResponse = _litleXmlSerializer.DeserializeObjectFromFile(_communication, responseFilePath);
            return litleResponse;
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
            _communication.FtpPickUp(_responseDirectory + batchFileName, _config, batchFileName);

            var litleResponse = _litleXmlSerializer.DeserializeObjectFromFile(_communication,
                _responseDirectory + batchFileName);
            return litleResponse;
        }

        public string SerializeBatchRequestToFile(BatchRequest litleBatchRequest, string filePath)
        {
            filePath = _litleFile.CreateRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_litleRequest.xml",
                _litleTime);
            var tempFilePath = litleBatchRequest.Serialize();

            _litleFile.AppendFileToFile(filePath, tempFilePath);

            return filePath;
        }

        public string SerializeRfrRequestToFile(RfrRequest rfrRequest, string filePath)
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

        private void FillInReportGroup(BatchRequest litleBatchRequest)
        {
            if (litleBatchRequest.ReportGroup == null)
            {
                litleBatchRequest.ReportGroup = _config["reportGroup"];
            }
        }
    }

    public class LitleFile
    {
        private readonly IDictionary<string, StringBuilder> _cache;

        public LitleFile(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
        }

        public StringBuilder this[string name]
        {
            get { return _cache[name]; }
        }

        public virtual string CreateRandomFile(string fileDirectory, string fileName, string fileExtension,
            LitleTime litleTime)
        {
            string filePath;
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = litleTime.GetCurrentTime("MM-dd-yyyy_HH-mm-ss-ffff_") + RandomGen.NextString(8);
                filePath = fileDirectory + fileName + fileExtension;
            }
            else
            {
                filePath = fileDirectory + fileName;
            }
            if (_cache.ContainsKey(filePath))
            {
                _cache[filePath] = new StringBuilder();
            }
            else
            {
                _cache.Add(filePath, new StringBuilder());
            }
            return filePath;
        }

        public virtual string AppendLineToFile(string filePath, string lineToAppend)
        {
            var ms = _cache[filePath];
            ms.Append(lineToAppend);
            return filePath;
        }

        public virtual string ReadPosition(string filepath)
        {
            var s = _cache[filepath];
            return s.ToString();
        }

        public virtual string AppendFileToFile(string filePathToAppendTo, string filePathToAppend)
        {
            var fs = _cache[filePathToAppendTo];
            if (filePathToAppend != null)
            {
                var fsr = _cache[filePathToAppend];
                fs.Append(fsr);
            }

            return filePathToAppendTo;
        }
    }

    public static class RandomGen
    {
        private static readonly RNGCryptoServiceProvider Global = new RNGCryptoServiceProvider();
        private static Random _local;

        public static int NextInt()
        {
            var inst = _local;
            if (inst == null)
            {
                var buffer = new byte[8];
                Global.GetBytes(buffer);
                _local = inst = new Random(BitConverter.ToInt32(buffer, 0));
            }

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
        public virtual string GetCurrentTime(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}

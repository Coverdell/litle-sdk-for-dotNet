using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class litleRequest
    {
        internal static readonly Dictionary<string, string> DefaultConfig = new Dictionary<string, string>
        {
            ["url"] = Settings.Default.url,
            ["reportGroup"] = Settings.Default.reportGroup,
            ["username"] = Settings.Default.username,
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

        private readonly IDictionary<string, StringBuilder> _cache;
        private authentication _authentication;
        private readonly Dictionary<string, string> _config;
        private Communications _communication;
        private litleXmlSerializer _litleXmlSerializer;
        private int _numOfLitleBatchRequest;
        private int _numOfRfrRequest;
        private string _finalFilePath;
        private string _batchFilePath;
        private string _requestDirectory;
        private string _responseDirectory;
        private litleTime _litleTime;
        private litleFile _litleFile;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */

        public litleRequest(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
            _config = DefaultConfig;

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
        public litleRequest(IDictionary<string, StringBuilder> cache, Dictionary<string, string> config)
        {
            _cache = cache;
            _config = config;

            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _communication = new Communications(_cache);

            _authentication = new authentication
            {
                user = _config["username"],
                password = _config["password"]
            };

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleXmlSerializer = new litleXmlSerializer();
            _litleTime = new litleTime();
            _litleFile = new litleFile(_cache);
        }

        public authentication getAuthenication() => _authentication;

        public string getRequestDirectory() => _requestDirectory;

        public string getResponseDirectory() => _responseDirectory;

        public void setCommunication(Communications communication) => _communication = communication;

        public Communications getCommunication() => _communication;

        public void setLitleXmlSerializer(litleXmlSerializer litleXmlSerializer) => _litleXmlSerializer = litleXmlSerializer;

        public litleXmlSerializer getLitleXmlSerializer() => _litleXmlSerializer;

        public void setLitleTime(litleTime litleTime) => _litleTime = litleTime;

        public litleTime getLitleTime() => _litleTime;

        public void setLitleFile(litleFile litleFile) => _litleFile = litleFile;

        public litleFile getLitleFile() => _litleFile;

        public void addBatch(batchRequest litleBatchRequest)
        {
            if (_numOfRfrRequest != 0)
            {
                throw new LitleOnlineException("Can not add a batch request to a batch with an RFRrequest!");
            }

            fillInReportGroup(litleBatchRequest);

            _batchFilePath = SerializeBatchRequestToFile(litleBatchRequest, _batchFilePath);
            _numOfLitleBatchRequest++;
        }

        public void addRFRRequest(RFRRequest rfrRequest)
        {
            if (_numOfLitleBatchRequest != 0)
            {
                throw new LitleOnlineException("Can not add an RFRRequest to a batch with requests!");
            }
            if (_numOfRfrRequest >= 1)
            {
                throw new LitleOnlineException("Can not add more than one RFRRequest to a batch!");
            }

            _batchFilePath = SerializeRFRRequestToFile(rfrRequest, _batchFilePath);
            _numOfRfrRequest++;
        }

        public litleResponse sendToLitleWithStream()
        {
            var requestFilePath = Serialize();
            var responseFilePath = _communication.socketStream(requestFilePath, _responseDirectory, _config);
            var stringBuilder = _cache[responseFilePath];
            var litleResponse = _litleXmlSerializer.DeserializeObjectFromString(stringBuilder.ToString());
            return litleResponse;
        }

        public string sendToLitle()
        {
            var requestFilePath = Serialize();

            _communication.FtpDropOff(_requestDirectory, Path.GetFileName(requestFilePath), _config);
            return Path.GetFileName(requestFilePath);
        }


        public void blockAndWaitForResponse(string fileName, int timeOut)
        {
            _communication.FtpPoll(fileName, timeOut, _config);
        }

        public litleResponse receiveFromLitle(string batchFileName)
        {
            _communication.FtpPickUp(_responseDirectory + batchFileName, _config, batchFileName);

            var stringBuilder = _cache[_responseDirectory + batchFileName];
            var litleResponse = _litleXmlSerializer.DeserializeObjectFromString(stringBuilder.ToString());
            return litleResponse;
        }

        public string SerializeBatchRequestToFile(batchRequest litleBatchRequest, string filePath)
        {
            filePath = _litleFile.createRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_litleRequest.xml",
                _litleTime);
            var tempFilePath = litleBatchRequest.Serialize();

            _litleFile.AppendFileToFile(filePath, tempFilePath);

            return filePath;
        }

        public string SerializeRFRRequestToFile(RFRRequest rfrRequest, string filePath)
        {
            filePath = _litleFile.createRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_litleRequest.xml",
                _litleTime);
            var tempFilePath = rfrRequest.Serialize();

            _litleFile.AppendFileToFile(filePath, tempFilePath);

            return filePath;
        }

        public string Serialize()
        {
            var xmlHeader = "<?xml version='1.0' encoding='utf-8'?>\r\n<litleRequest version=\"9.3\"" +
                            " xmlns=\"http://www.litle.com/schema\" " +
                            $"numBatchRequests=\"{_numOfLitleBatchRequest}\">";

            const string xmlFooter = "\r\n</litleRequest>";

            _finalFilePath = _litleFile.createRandomFile(_requestDirectory, Path.GetFileName(_finalFilePath), ".xml",
                _litleTime);
            var filePath = _finalFilePath;

            _litleFile.AppendLineToFile(_finalFilePath, xmlHeader);
            _litleFile.AppendLineToFile(_finalFilePath, _authentication.Serialize());

            if (_batchFilePath != null)
            {
                _litleFile.AppendFileToFile(_finalFilePath, _batchFilePath);
            }
            else
            {
                throw new LitleOnlineException("No batch was added to the LitleBatch!");
            }

            _litleFile.AppendLineToFile(_finalFilePath, xmlFooter);
            _finalFilePath = null;

            return filePath;
        }

        private void fillInReportGroup(batchRequest litleBatchRequest)
        {
            if (litleBatchRequest.reportGroup == null)
            {
                litleBatchRequest.reportGroup = _config["reportGroup"];
            }
        }
    }

    public class litleFile
    {
        private readonly IDictionary<string, StringBuilder> _cache;

        public litleFile(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
        }

        public virtual string createRandomFile(string fileDirectory, string fileName, string fileExtension,
            litleTime litleTime)
        {
            string filePath;
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = litleTime.getCurrentTime("MM-dd-yyyy_HH-mm-ss-ffff_") + RandomGen.NextString(8);
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
            if (_local == null)
            {
                var buffer = new byte[8];
                Global.GetBytes(buffer);
                _local = new Random(BitConverter.ToInt32(buffer, 0));
            }

            return _local.Next();
        }

        public static string NextString(int length)
        {
            var results = Enumerable.Range(0, length)
                .Select(x => NextInt()%('Z' - 'A') + 'A')
                .Select(Convert.ToChar)
                .ToArray();
            return new string(results);
        }
    }

    public class litleTime
    {
        public virtual string getCurrentTime(string format) => DateTime.Now.ToString(format);
    }
}

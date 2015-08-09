using System.Collections.Generic;
using System.IO;
using Litle.Sdk.Properties;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class LitleRequest
    {
        private Authentication _authentication;
        private readonly Dictionary<string, string> _config;
        private Communications _communication;
        private LitleXmlSerializer _litleXmlSerializer;
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
        public LitleRequest(Dictionary<string, string> config)
        {
            _config = config;
            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _communication = new Communications();

            _authentication = new Authentication {User = _config["username"], Password = _config["password"]};

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleXmlSerializer = new LitleXmlSerializer();
            _litleTime = new LitleTime();
            _litleFile = new LitleFile();
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

        public LitleResponse SendToLitleWithStream()
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

        public LitleResponse ReceiveFromLitle(string batchFileName)
        {
            _litleFile.CreateDirectory(_responseDirectory);
            _communication.FtpPickUp(_responseDirectory + batchFileName, _config, batchFileName);
            return _litleXmlSerializer.DeserializeObjectFromFile(_responseDirectory + batchFileName);
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
}
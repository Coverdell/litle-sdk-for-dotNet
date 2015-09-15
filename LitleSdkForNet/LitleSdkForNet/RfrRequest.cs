using System.Collections.Generic;
using Litle.Sdk.Properties;

namespace Litle.Sdk.Requests
{
    public class RfrRequest
    {
        public long LitleSessionId { get; set; }
        public AccountUpdateFileRequestData AccountUpdateFileRequestData { get; set; }

        private LitleTime _litleTime;
        private LitleFile _litleFile;
        private string _requestDirectory;
        private string _responseDirectory;

        private Dictionary<string, string> _config;

        public RfrRequest()
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
            _config["requestDirectory"] = Settings.Default.requestDirectory;
            _config["responseDirectory"] = Settings.Default.responseDirectory;

            _litleTime = new LitleTime();
            _litleFile = new LitleFile();

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";
        }

        public RfrRequest(Dictionary<string, string> config)
        {
            _config = config;
            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleFile = new LitleFile();
            _litleTime = new LitleTime();
        }

        public string GetRequestDirectory()
        {
            return _requestDirectory;
        }

        public string GetResponseDirectory()
        {
            return _responseDirectory;
        }

        public void SetConfig(Dictionary<string, string> config)
        {
            _config = config;
        }

        public void SetLitleFile(LitleFile litleFile)
        {
            _litleFile = litleFile;
        }

        public LitleFile GetLitleFile()
        {
            return _litleFile;
        }

        public void SetLitleTime(LitleTime litleTime)
        {
            _litleTime = litleTime;
        }

        public LitleTime GetLitleTime()
        {
            return _litleTime;
        }

        public string Serialize()
        {
            const string xmlHeader = "\r\n<RFRRequest xmlns=\"http://www.litle.com/schema\">";
            const string xmlFooter = "\r\n</RFRRequest>";

            string filePath = _litleFile.CreateRandomFile(_requestDirectory, null, "_RFRRequest.xml", _litleTime);

            string xmlBody = "";

            if (AccountUpdateFileRequestData != null)
            {
                xmlBody += "\r\n<accountUpdateFileRequestData>";
                xmlBody += AccountUpdateFileRequestData.Serialize();
                xmlBody += "\r\n</accountUpdateFileRequestData>";
            }
            else
            {
                xmlBody += "\r\n<litleSessionId>" + LitleSessionId + "</litleSessionId>";
            }
            _litleFile.AppendLineToFile(filePath, xmlHeader);
            _litleFile.AppendLineToFile(filePath, xmlBody);
            _litleFile.AppendLineToFile(filePath, xmlFooter);

            return filePath;
        }
    }
}
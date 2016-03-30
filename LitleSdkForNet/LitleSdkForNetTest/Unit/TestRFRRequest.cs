using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestRfrRequest
    {
        #region Setup

        private RFRRequest _rfrRequest;

        private const string MockFileName = "TheRainbow.xml",
            MockFilePath = "C:\\Somewhere\\\\Over\\\\" + MockFileName;

        private Mock<litleFile> _mockLitleFile;
        private Mock<litleTime> _mockLitleTime;
        private IDictionary<string, StringBuilder> _memoryCache;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _memoryCache = new Dictionary<string, StringBuilder>();
            _mockLitleFile = new Mock<litleFile>(_memoryCache);
            _mockLitleTime = new Mock<litleTime>();

            _mockLitleFile.Setup(litleFile => 
                    litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object))
                .Returns(MockFilePath);
            _mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(MockFilePath, It.IsAny<string>()))
                .Returns(MockFilePath);
        }

        [SetUp]
        public void SetUpBeforeTest() => _rfrRequest = new RFRRequest(_memoryCache);

        #endregion Setup

        [Test]
        public void TestInitialization()
        {
            _rfrRequest = new RFRRequest(_memoryCache, new Dictionary<string, string>
            {
                ["url"] = "https://www.mockurl.com",
                ["reportGroup"] = "Mock Report Group",
                ["username"] = "mockUser",
                ["printxml"] = "false",
                ["timeout"] = "35",
                ["proxyHost"] = "www.mockproxy.com",
                ["merchantId"] = "MOCKID",
                ["password"] = "mockPassword",
                ["proxyPort"] = "3000",
                ["sftpUrl"] = "www.mockftp.com",
                ["sftpUsername"] = "mockFtpUser",
                ["sftpPassword"] = "mockFtpPassword",
                ["knownHostsFile"] = "C:\\MockKnownHostsFile",
                ["onlineBatchUrl"] = "www.mockbatch.com",
                ["onlineBatchPort"] = "4000",
                ["requestDirectory"] = "C:\\MockRequests",
                ["responseDirectory"] = "C:\\MockResponses"
            });

            Assert.AreEqual("C:\\MockRequests\\Requests\\", _rfrRequest.getRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", _rfrRequest.getResponseDirectory());

            Assert.NotNull(_rfrRequest.getLitleTime());
            Assert.NotNull(_rfrRequest.getLitleFile());
        }

        [Test]
        public void TestSerialize()
        {
            _rfrRequest.litleSessionId = 123456789;
            _rfrRequest.setLitleFile(_mockLitleFile.Object);
            _rfrRequest.setLitleTime(_mockLitleTime.Object);

            Assert.AreEqual(MockFilePath, _rfrRequest.Serialize());

            _mockLitleFile.Verify(litleFile =>
                litleFile.AppendLineToFile(MockFilePath, "\r\n<RFRRequest xmlns=\"http://www.litle.com/schema\">"));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, "\r\n<litleSessionId>123456789</litleSessionId>"));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, "\r\n</RFRRequest>"));
        }

        [Test]
        public void TestAccountUpdateFileRequestData()
        {
            const string mockid = "MOCKID";
            var accountUpdateFileRequestDefault = new accountUpdateFileRequestData();
            var accountUpdateFileRequest = new accountUpdateFileRequestData(new Dictionary<string, string>
            {
                ["url"] = "https://www.mockurl.com",
                ["reportGroup"] = "Mock Report Group",
                ["username"] = "mockUser",
                ["printxml"] = "false",
                ["timeout"] = "35",
                ["proxyHost"] = "www.mockproxy.com",
                ["merchantId"] = mockid,
                ["password"] = "mockPassword",
                ["proxyPort"] = "3000",
                ["sftpUrl"] = "www.mockftp.com",
                ["sftpUsername"] = "mockFtpUser",
                ["sftpPassword"] = "mockFtpPassword",
                ["knownHostsFile"] = "C:\\MockKnownHostsFile",
                ["onlineBatchUrl"] = "www.mockbatch.com",
                ["onlineBatchPort"] = "4000",
                ["requestDirectory"] = "C:\\MockRequests",
                ["responseDirectory"] = "C:\\MockResponses"
            });

            Assert.AreEqual(accountUpdateFileRequestDefault.merchantId, Settings.Default.merchantId);
            Assert.AreEqual(accountUpdateFileRequest.merchantId, mockid);
        }
    }
}
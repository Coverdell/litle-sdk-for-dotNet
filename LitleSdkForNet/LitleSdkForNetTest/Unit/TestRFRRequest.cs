using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestRFRRequest
    {
        private RfrRequest rfrRequest;

        private const string timeFormat = "MM-dd-yyyy_HH-mm-ss-ffff_";
        private const string timeRegex = "[0-1][0-9]-[0-3][0-9]-[0-9]{4}_[0-9]{2}-[0-9]{2}-[0-9]{2}-[0-9]{4}_";
        private const string batchNameRegex = timeRegex + "[A-Z]{8}";
        private const string mockFileName = "TheRainbow.xml";
        private const string mockFilePath = "C:\\Somewhere\\\\Over\\\\" + mockFileName;

        private Mock<LitleFile> mockLitleFile;
        private Mock<LitleTime> mockLitleTime;

        [TestFixtureSetUp]
        public void setUp()
        {
            mockLitleFile = new Mock<LitleFile>();
            mockLitleTime = new Mock<LitleTime>();

            mockLitleFile.Setup(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object)).Returns(mockFilePath);
            mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(mockFilePath, It.IsAny<String>())).Returns(mockFilePath);
        }

        [SetUp]
        public void setUpBeforeTest()
        {
            rfrRequest = new RfrRequest();
        }

        [Test]
        public void testInitialization()
        {
            Dictionary<String, String> mockConfig = new Dictionary<string, string>();

            mockConfig["url"] = "https://www.mockurl.com";
            mockConfig["reportGroup"] = "Mock Report Group";
            mockConfig["username"] = "mockUser";
            mockConfig["printxml"] = "false";
            mockConfig["timeout"] = "35";
            mockConfig["proxyHost"] = "www.mockproxy.com";
            mockConfig["merchantId"] = "MOCKID";
            mockConfig["password"] = "mockPassword";
            mockConfig["proxyPort"] = "3000";
            mockConfig["sftpUrl"] = "www.mockftp.com";
            mockConfig["sftpUsername"] = "mockFtpUser";
            mockConfig["sftpPassword"] = "mockFtpPassword";
            mockConfig["knownHostsFile"] = "C:\\MockKnownHostsFile";
            mockConfig["onlineBatchUrl"] = "www.mockbatch.com";
            mockConfig["onlineBatchPort"] = "4000";
            mockConfig["requestDirectory"] = "C:\\MockRequests";
            mockConfig["responseDirectory"] = "C:\\MockResponses";

            rfrRequest = new RfrRequest(mockConfig);

            Assert.AreEqual("C:\\MockRequests\\Requests\\", rfrRequest.GetRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", rfrRequest.GetResponseDirectory());

            Assert.NotNull(rfrRequest.GetLitleTime());
            Assert.NotNull(rfrRequest.GetLitleFile());
        }

        [Test]
        public void testSerialize()
        {
            LitleFile mockedLitleFile = mockLitleFile.Object;
            LitleTime mockedLitleTime = mockLitleTime.Object;

            rfrRequest.LitleSessionId = 123456789;
            rfrRequest.SetLitleFile(mockedLitleFile);
            rfrRequest.SetLitleTime(mockedLitleTime);

            Assert.AreEqual(mockFilePath, rfrRequest.Serialize());

            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, "\r\n<RFRRequest xmlns=\"http://www.litle.com/schema\">"));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, "\r\n<litleSessionId>123456789</litleSessionId>"));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, "\r\n</RFRRequest>"));
        }

        [Test]
        public void testAccountUpdateFileRequestData() 
        {
            Dictionary<String, String> mockConfig = new Dictionary<string, string>();

            mockConfig["url"] = "https://www.mockurl.com";
            mockConfig["reportGroup"] = "Mock Report Group";
            mockConfig["username"] = "mockUser";
            mockConfig["printxml"] = "false";
            mockConfig["timeout"] = "35";
            mockConfig["proxyHost"] = "www.mockproxy.com";
            mockConfig["merchantId"] = "MOCKID";
            mockConfig["password"] = "mockPassword";
            mockConfig["proxyPort"] = "3000";
            mockConfig["sftpUrl"] = "www.mockftp.com";
            mockConfig["sftpUsername"] = "mockFtpUser";
            mockConfig["sftpPassword"] = "mockFtpPassword";
            mockConfig["knownHostsFile"] = "C:\\MockKnownHostsFile";
            mockConfig["onlineBatchUrl"] = "www.mockbatch.com";
            mockConfig["onlineBatchPort"] = "4000";
            mockConfig["requestDirectory"] = "C:\\MockRequests";
            mockConfig["responseDirectory"] = "C:\\MockResponses";

            AccountUpdateFileRequestData accountUpdateFileRequest = new AccountUpdateFileRequestData(mockConfig);
            AccountUpdateFileRequestData accountUpdateFileRequestDefault = new AccountUpdateFileRequestData();

            Assert.AreEqual(accountUpdateFileRequestDefault.MerchantId, Properties.Settings.Default.merchantId);
            Assert.AreEqual(accountUpdateFileRequest.MerchantId, mockConfig["merchantId"]);
        }
    }
}

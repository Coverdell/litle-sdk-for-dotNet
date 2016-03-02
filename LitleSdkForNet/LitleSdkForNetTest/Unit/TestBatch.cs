using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestBatch
    {
        private LitleRequest litle;
        private const string timeFormat = "MM-dd-yyyy_HH-mm-ss-ffff_";
        private const string timeRegex = "[0-1][0-9]-[0-3][0-9]-[0-9]{4}_[0-9]{2}-[0-9]{2}-[0-9]{2}-[0-9]{4}_";
        private const string batchNameRegex = timeRegex + "[A-Z]{8}";
        private const string mockFileName = "TheRainbow.xml";
        private const string mockFilePath = "C:\\Somewhere\\Over\\" + mockFileName;

        private Mock<LitleTime> mockLitleTime;
        private Mock<LitleFile> mockLitleFile;
        private Mock<Communications> mockCommunications;
        private Mock<XmlReader> mockXmlReader;
        private IDictionary<string, StringBuilder> memoryStreams;

        [TestFixtureSetUp]
        public void setUp()
        {
            memoryStreams = new Dictionary<string, StringBuilder>();
            mockLitleTime = new Mock<LitleTime>();
            mockLitleTime.Setup(
                litleTime => litleTime.GetCurrentTime(It.Is<string>(resultFormat => resultFormat == timeFormat)))
                .Returns("01-01-1960_01-22-30-1234_");

            mockLitleFile = new Mock<LitleFile>(memoryStreams);
            mockLitleFile.Setup(
                litleFile =>
                    litleFile.CreateRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                        mockLitleTime.Object)).Returns(mockFilePath);
            mockLitleFile.Setup(litleFile => litleFile.AppendFileToFile(mockFilePath, It.IsAny<string>()))
                .Returns(mockFilePath);
            mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(mockFilePath, It.IsAny<string>()))
                .Returns(mockFilePath);

            mockCommunications = new Mock<Communications>(memoryStreams);
        }

        [SetUp]
        public void setUpBeforeEachTest()
        {
            litle = new LitleRequest(memoryStreams);

            mockXmlReader = new Mock<XmlReader>();
            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadToFollowing(It.IsAny<string>()))
                .Returns(true)
                .Returns(true)
                .Returns(false);
            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadState)
                .Returns(ReadState.Initial)
                .Returns(ReadState.Interactive)
                .Returns(ReadState.Closed);
        }

        [Test]
        public void testInitialization()
        {
            var mockConfig = new Dictionary<string, string>();

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

            litle = new LitleRequest(memoryStreams, mockConfig);

            Assert.AreEqual("C:\\MockRequests\\Requests\\", litle.GetRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", litle.GetResponseDirectory());

            Assert.NotNull(litle.GetCommunication());
            Assert.NotNull(litle.GetLitleTime());
            Assert.NotNull(litle.GetLitleFile());
            Assert.NotNull(litle.GetLitleXmlSerializer());
        }

        [Test]
        public void testAccountUpdate()
        {
            var accountUpdate = new AccountUpdate();
            accountUpdate.reportGroup = "Planets";
            accountUpdate.OrderId = "12344";
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            accountUpdate.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>")
                .Returns(
                    "<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setAccountUpdateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockedCommunication, It.IsAny<string>()))
                .Returns(mockedLitleResponse);


            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAccountUpdate(accountUpdate);
            litleBatchRequest.AddAccountUpdate(accountUpdate);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualAccountUpdateResponse1 = actualLitleBatchResponse.nextAccountUpdateResponse();
            var actualAccountUpdateResponse2 = actualLitleBatchResponse.nextAccountUpdateResponse();
            var nullAccountUpdateResponse = actualLitleBatchResponse.nextAccountUpdateResponse();

            Assert.AreEqual(123, actualAccountUpdateResponse1.litleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse1.response);
            Assert.AreEqual(124, actualAccountUpdateResponse2.litleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse2.response);
            Assert.IsNull(nullAccountUpdateResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }


        [Test]
        public void testAuth()
        {
            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>123</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>")
                .Returns(
                    "<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>124</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setAuthorizationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthorization(authorization);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.nextAuthorizationResponse().litleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.nextAuthorizationResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextAuthorizationResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testAuthReversal()
        {
            var authreversal = new AuthReversal();
            authreversal.LitleTxnId = 12345678000;
            authreversal.Amount = 106;
            authreversal.PayPalNotes = "Notes";

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>")
                .Returns(
                    "<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setAuthReversalResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunications = mockCommunications.Object;
            litle.SetCommunication(mockedCommunications);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthReversal(authreversal);
            litleBatchRequest.AddAuthReversal(authreversal);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualAuthReversalResponse1 = actualLitleBatchResponse.nextAuthReversalResponse();
            var actualAuthReversalResponse2 = actualLitleBatchResponse.nextAuthReversalResponse();
            var nullAuthReversalResponse = actualLitleBatchResponse.nextAuthReversalResponse();

            Assert.AreEqual(123, actualAuthReversalResponse1.litleTxnId);
            Assert.AreEqual(124, actualAuthReversalResponse2.litleTxnId);
            Assert.IsNull(nullAuthReversalResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testCapture()
        {
            var capture = new Capture();
            capture.LitleTxnId = 12345678000;
            capture.Amount = 106;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<captureResponse id=\"123\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>123</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>")
                .Returns(
                    "<captureResponse id=\"124\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>124</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setCaptureResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCapture(capture);
            litleBatchRequest.AddCapture(capture);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualCaptureResponse1 = actualLitleBatchResponse.nextCaptureResponse();
            var actualCaptureResponse2 = actualLitleBatchResponse.nextCaptureResponse();
            var nullCaptureResponse = actualLitleBatchResponse.nextCaptureResponse();

            Assert.AreEqual(123, actualCaptureResponse1.litleTxnId);
            Assert.AreEqual(124, actualCaptureResponse2.litleTxnId);
            Assert.IsNull(nullCaptureResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testCaptureGivenAuth()
        {
            var capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.OrderId = "12344";
            capturegivenauth.Amount = 106;
            var authinfo = new AuthInformation();
            authinfo.AuthDate = new DateTime(2002, 10, 9);
            authinfo.AuthCode = "543216";
            authinfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authinfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            capturegivenauth.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></captureGivenAuthResponse>")
                .Returns(
                    "<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></captureGivenAuthResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setCaptureGivenAuthResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);
            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualCaptureGivenAuthReponse1 = actualLitleBatchResponse.nextCaptureGivenAuthResponse();
            var actualCaptureGivenAuthReponse2 = actualLitleBatchResponse.nextCaptureGivenAuthResponse();
            var nullCaptureGivenAuthReponse = actualLitleBatchResponse.nextCaptureGivenAuthResponse();

            Assert.AreEqual(123, actualCaptureGivenAuthReponse1.litleTxnId);
            Assert.AreEqual(124, actualCaptureGivenAuthReponse2.litleTxnId);
            Assert.IsNull(nullCaptureGivenAuthReponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testCredit()
        {
            var credit = new Credit();
            credit.OrderId = "12344";
            credit.Amount = 106;
            credit.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            credit.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></creditResponse>")
                .Returns(
                    "<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></creditResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCredit(credit);
            litleBatchRequest.AddCredit(credit);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualCreditReponse1 = actualLitleBatchResponse.nextCreditResponse();
            var actualCreditReponse2 = actualLitleBatchResponse.nextCreditResponse();
            var nullCreditReponse1 = actualLitleBatchResponse.nextCreditResponse();

            Assert.AreEqual(123, actualCreditReponse1.litleTxnId);
            Assert.AreEqual(124, actualCreditReponse2.litleTxnId);
            Assert.IsNull(nullCreditReponse1);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckCredit()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12;
            echeckcredit.LitleTxnId = 123456789101112;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckCreditResponse>")
                .Returns(
                    "<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckCreditResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckCredit(echeckcredit);
            litleBatchRequest.AddEcheckCredit(echeckcredit);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckCreditResponse1 = actualLitleBatchResponse.nextEcheckCreditResponse();
            var actualEcheckCreditResponse2 = actualLitleBatchResponse.nextEcheckCreditResponse();
            var nullEcheckCreditResponse = actualLitleBatchResponse.nextEcheckCreditResponse();

            Assert.AreEqual(123, actualEcheckCreditResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckCreditResponse2.litleTxnId);
            Assert.IsNull(nullEcheckCreditResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckRedeposit()
        {
            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckRedepositResponse>")
                .Returns(
                    "<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckRedepositResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckRedepositResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckRedepositResponse1 = actualLitleBatchResponse.nextEcheckRedepositResponse();
            var actualEcheckRedepositResponse2 = actualLitleBatchResponse.nextEcheckRedepositResponse();
            var nullEcheckRedepositResponse = actualLitleBatchResponse.nextEcheckRedepositResponse();

            Assert.AreEqual(123, actualEcheckRedepositResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckRedepositResponse2.litleTxnId);
            Assert.IsNull(nullEcheckRedepositResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckSale()
        {
            var echecksale = new EcheckSale();
            echecksale.OrderId = "12345";
            echecksale.Amount = 123456;
            echecksale.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echecksale.Echeck = echeck;
            var contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echecksale.BillToAddress = contact;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckSalesResponse>")
                .Returns(
                    "<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckSalesResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckSalesResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckSale(echecksale);
            litleBatchRequest.AddEcheckSale(echecksale);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckSalesResponse1 = actualLitleBatchResponse.nextEcheckSalesResponse();
            var actualEcheckSalesResponse2 = actualLitleBatchResponse.nextEcheckSalesResponse();
            var nullEcheckSalesResponse = actualLitleBatchResponse.nextEcheckSalesResponse();

            Assert.AreEqual(123, actualEcheckSalesResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckSalesResponse2.litleTxnId);
            Assert.IsNull(nullEcheckSalesResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckVerification()
        {
            var echeckverification = new EcheckVerification();
            echeckverification.OrderId = "12345";
            echeckverification.Amount = 123456;
            echeckverification.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckverification.Echeck = echeck;
            var contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckverification.BillToAddress = contact;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckVerificationResponse>")
                .Returns(
                    "<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckVerificationResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckVerificationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckVerification(echeckverification);
            litleBatchRequest.AddEcheckVerification(echeckverification);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckVerificationResponse1 = actualLitleBatchResponse.nextEcheckVerificationResponse();
            var actualEcheckVerificationResponse2 = actualLitleBatchResponse.nextEcheckVerificationResponse();
            var nullEcheckVerificationResponse = actualLitleBatchResponse.nextEcheckVerificationResponse();

            Assert.AreEqual(123, actualEcheckVerificationResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckVerificationResponse2.litleTxnId);
            Assert.IsNull(nullEcheckVerificationResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testForceCapture()
        {
            var forcecapture = new ForceCapture();
            forcecapture.OrderId = "12344";
            forcecapture.Amount = 106;
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            forcecapture.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></forceCaptureResponse>")
                .Returns(
                    "<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></forceCaptureResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setForceCaptureResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddForceCapture(forcecapture);
            litleBatchRequest.AddForceCapture(forcecapture);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualForceCaptureResponse1 = actualLitleBatchResponse.nextForceCaptureResponse();
            var actualForceCaptureResponse2 = actualLitleBatchResponse.nextForceCaptureResponse();
            var nullForceCaptureResponse = actualLitleBatchResponse.nextForceCaptureResponse();

            Assert.AreEqual(123, actualForceCaptureResponse1.litleTxnId);
            Assert.AreEqual(124, actualForceCaptureResponse2.litleTxnId);
            Assert.IsNull(nullForceCaptureResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testSale()
        {
            var sale = new Sale();
            sale.OrderId = "12344";
            sale.Amount = 106;
            sale.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            sale.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></saleResponse>")
                .Returns("<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></saleResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setSaleResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddSale(sale);
            litleBatchRequest.AddSale(sale);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualSaleResponse1 = actualLitleBatchResponse.nextSaleResponse();
            var actualSaleResponse2 = actualLitleBatchResponse.nextSaleResponse();
            var nullSaleResponse = actualLitleBatchResponse.nextSaleResponse();

            Assert.AreEqual(123, actualSaleResponse1.litleTxnId);
            Assert.AreEqual(124, actualSaleResponse2.litleTxnId);
            Assert.IsNull(nullSaleResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testToken()
        {
            var token = new RegisterTokenRequestType();
            token.OrderId = "12344";
            token.AccountNumber = "1233456789103801";

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></registerTokenResponse>")
                .Returns(
                    "<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></registerTokenResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setRegisterTokenResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddRegisterTokenRequest(token);
            litleBatchRequest.AddRegisterTokenRequest(token);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualRegisterTokenResponse1 = actualLitleBatchResponse.nextRegisterTokenResponse();
            var actualRegisterTokenResponse2 = actualLitleBatchResponse.nextRegisterTokenResponse();
            var nullRegisterTokenResponse = actualLitleBatchResponse.nextRegisterTokenResponse();

            Assert.AreEqual(123, actualRegisterTokenResponse1.litleTxnId);
            Assert.AreEqual(124, actualRegisterTokenResponse2.litleTxnId);
            Assert.IsNull(nullRegisterTokenResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testUpdateCardValidationNumOnToken()
        {
            var updateCardValidationNumOnToken = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken.OrderId = "12344";
            updateCardValidationNumOnToken.LitleToken = "123";

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></updateCardValidationNumOnTokenResponse>")
                .Returns(
                    "<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></updateCardValidationNumOnTokenResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setUpdateCardValidationNumOnTokenResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);
            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualUpdateCardValidationNumOnTokenResponse1 =
                actualLitleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
            var actualUpdateCardValidationNumOnTokenResponse2 =
                actualLitleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
            var nullUpdateCardValidationNumOnTokenResponse =
                actualLitleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();

            Assert.AreEqual(123, actualUpdateCardValidationNumOnTokenResponse1.litleTxnId);
            Assert.AreEqual(124, actualUpdateCardValidationNumOnTokenResponse2.litleTxnId);
            Assert.IsNull(nullUpdateCardValidationNumOnTokenResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testLitleOnlineException()
        {
            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleBatchResponse = new Mock<batchResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            var mockAuthorizationResponse1 = new authorizationResponse();
            mockAuthorizationResponse1.litleTxnId = 123;
            var mockAuthorizationResponse2 = new authorizationResponse();
            mockAuthorizationResponse2.litleTxnId = 124;

            mockLitleBatchResponse.SetupSequence(litleBatchResponse => litleBatchResponse.nextAuthorizationResponse())
                .Returns(mockAuthorizationResponse1)
                .Returns(mockAuthorizationResponse2)
                .Returns(null);

            var mockedLitleResponse = mockLitleResponse.Object;
            mockedLitleResponse.message = "Error validating xml data against the schema";
            mockedLitleResponse.response = "1";

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            try
            {
                litle.SetCommunication(mockedCommunications);
                litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
                litle.SetLitleFile(mockedLitleFile);
                litle.SetLitleTime(mockLitleTime.Object);
                var litleBatchRequest = new BatchRequest(memoryStreams);
                litleBatchRequest.SetLitleFile(mockedLitleFile);
                litleBatchRequest.SetLitleTime(mockLitleTime.Object);

                litleBatchRequest.AddAuthorization(authorization);
                litleBatchRequest.AddAuthorization(authorization);
                litle.AddBatch(litleBatchRequest);

                var batchFileName = litle.SendToLitle();
                var litleResponse = litle.ReceiveFromLitle(batchFileName);
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void testInvalidOperationException()
        {
            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleResponse mockLitleResponse = null;

            var mockXml = new Mock<LitleXmlSerializer>();

            var mockedCommunications = mockCommunications.Object;

            mockXml.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockLitleResponse);
            var mockedLitleXmlSerializer = mockXml.Object;

            var mockedLitleFile = mockLitleFile.Object;

            try
            {
                litle.SetCommunication(mockedCommunications);
                litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
                litle.SetLitleFile(mockedLitleFile);
                litle.SetLitleTime(mockLitleTime.Object);
                var litleBatchRequest = new BatchRequest(memoryStreams);
                litleBatchRequest.SetLitleFile(mockedLitleFile);
                litleBatchRequest.SetLitleTime(mockLitleTime.Object);

                litleBatchRequest.AddAuthorization(authorization);
                litleBatchRequest.AddAuthorization(authorization);
                litle.AddBatch(litleBatchRequest);

                var batchFileName = litle.SendToLitle();
                var litleResponse = litle.ReceiveFromLitle(batchFileName);
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void testDefaultReportGroup()
        {
            var authorization = new Authorization();
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></authorizationResponse>")
                .Returns(
                    "<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></authorizationResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setAuthorizationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);
            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthorization(authorization);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualAuthorizationResponse1 = actualLitleBatchResponse.nextAuthorizationResponse();
            var actualAuthorizationResponse2 = actualLitleBatchResponse.nextAuthorizationResponse();
            var nullAuthorizationResponse = actualLitleBatchResponse.nextAuthorizationResponse();

            Assert.AreEqual(123, actualAuthorizationResponse1.litleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse1.reportGroup);
            Assert.AreEqual(124, actualAuthorizationResponse2.litleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse2.reportGroup);
            Assert.IsNull(nullAuthorizationResponse);

            mockLitleFile.Verify(
                litleFile =>
                    litleFile.AppendLineToFile(mockFilePath,
                        It.IsRegex(".*reportGroup=\"Default Report Group\".*", RegexOptions.Singleline)));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testSerialize()
        {
            var authorization = new Authorization();
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockedLitleFile = mockLitleFile.Object;
            var mockedLitleTime = mockLitleTime.Object;

            litle.SetLitleTime(mockedLitleTime);
            litle.SetLitleFile(mockedLitleFile);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            var resultFile = litle.Serialize();

            Assert.IsTrue(resultFile.Equals(mockFilePath));

            mockLitleFile.Verify(litleFile => litleFile.AppendFileToFile(mockFilePath, It.IsAny<string>()));
        }

        [Test]
        public void testRFRRequest()
        {
            var rfrRequest = new RfrRequest(memoryStreams);
            rfrRequest.LitleSessionId = 123456789;

            var mockBatchXmlReader = new Mock<XmlReader>();
            mockBatchXmlReader.Setup(XmlReader => XmlReader.ReadState).Returns(ReadState.Closed);

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadState)
                .Returns(ReadState.Interactive)
                .Returns(ReadState.Closed);
            mockXmlReader.Setup(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<RFRResponse response=\"1\" message=\"The account update file is not ready yet. Please try again later.\" xmlns='http://www.litle.com/schema'> </RFRResponse>");

            var mockedLitleResponse = new litleResponse();
            mockedLitleResponse.setRfrResponseReader(mockXmlReader.Object);
            mockedLitleResponse.setBatchResponseReader(mockBatchXmlReader.Object);

            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();
            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;
            var mockedLitleTime = mockLitleTime.Object;
            var mockedCommunications = mockCommunications.Object;

            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockedLitleTime);
            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            rfrRequest.SetLitleFile(mockedLitleFile);
            rfrRequest.SetLitleTime(mockedLitleTime);

            litle.AddRfrRequest(rfrRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var nullLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualRFRResponse = actualLitleResponse.nextRFRResponse();
            var nullRFRResponse = actualLitleResponse.nextRFRResponse();

            Assert.IsNotNull(actualRFRResponse);
            Assert.AreEqual("1", actualRFRResponse.response);
            Assert.AreEqual("The account update file is not ready yet. Please try again later.",
                actualRFRResponse.message);
            Assert.IsNull(nullLitleBatchResponse);
            Assert.IsNull(nullRFRResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testCancelSubscription()
        {
            var cancel = new CancelSubscription();
            cancel.SubscriptionId = 12345;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></cancelSubscriptionResponse>")
                .Returns(
                    "<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></cancelSubscriptionResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setCancelSubscriptionResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCancelSubscription(cancel);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("12345", actualLitleBatchResponse.nextCancelSubscriptionResponse().subscriptionId);
            Assert.AreEqual("54321", actualLitleBatchResponse.nextCancelSubscriptionResponse().subscriptionId);
            Assert.IsNull(actualLitleBatchResponse.nextCancelSubscriptionResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testUpdateSubscription()
        {
            var update = new UpdateSubscription();
            update.BillingDate = new DateTime(2002, 10, 9);
            var billToAddress = new Contact();
            billToAddress.Name = "Greg Dake";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "sdksupport@litle.com";
            update.BillToAddress = billToAddress;
            var card = new CardType();
            card.Number = "4100000000000001";
            card.ExpDate = "1215";
            card.Type = MethodOfPaymentTypeEnum.VI;
            update.Card = card;
            update.PlanCode = "abcdefg";
            update.SubscriptionId = 12345;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></updateSubscriptionResponse>")
                .Returns(
                    "<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></updateSubscriptionResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setUpdateSubscriptionResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdateSubscription(update);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("12345", actualLitleBatchResponse.nextUpdateSubscriptionResponse().subscriptionId);
            Assert.AreEqual("54321", actualLitleBatchResponse.nextUpdateSubscriptionResponse().subscriptionId);
            Assert.IsNull(actualLitleBatchResponse.nextUpdateSubscriptionResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testCreatePlan()
        {
            var createPlan = new CreatePlan();
            createPlan.PlanCode = "thePlanCode";
            createPlan.Name = "theName";
            createPlan.IntervalType = IntervalType.ANNUAL;
            createPlan.Amount = 100;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></createPlanResponse>")
                .Returns(
                    "<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></createPlanResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setCreatePlanResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCreatePlan(createPlan);
            litleBatchRequest.AddCreatePlan(createPlan);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextCreatePlanResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextCreatePlanResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextCreatePlanResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testUpdatePlan()
        {
            var updatePlan = new UpdatePlan();
            updatePlan.PlanCode = "thePlanCode";
            updatePlan.Active = true;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></updatePlanResponse>")
                .Returns(
                    "<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></updatePlanResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setUpdatePlanResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdatePlan(updatePlan);
            litleBatchRequest.AddUpdatePlan(updatePlan);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextUpdatePlanResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextUpdatePlanResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextUpdatePlanResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testActivate()
        {
            var activate = new Activate();
            activate.OrderId = "theOrderId";
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.Card = new CardType();

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></activateResponse>")
                .Returns(
                    "<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></activateResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setActivateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddActivate(activate);
            litleBatchRequest.AddActivate(activate);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextActivateResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextActivateResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextActivateResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testDeactivate()
        {
            var deactivate = new Deactivate();
            deactivate.OrderId = "theOrderId";
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></deactivateResponse>")
                .Returns(
                    "<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></deactivateResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setDeactivateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddDeactivate(deactivate);
            litleBatchRequest.AddDeactivate(deactivate);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextDeactivateResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextDeactivateResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextDeactivateResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testLoad()
        {
            var load = new Load();
            load.OrderId = "theOrderId";
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></loadResponse>")
                .Returns(
                    "<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></loadResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setLoadResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddLoad(load);
            litleBatchRequest.AddLoad(load);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextLoadResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextLoadResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextLoadResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testUnload()
        {
            var unload = new Unload();
            unload.OrderId = "theOrderId";
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></unloadResponse>")
                .Returns(
                    "<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></unloadResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setUnloadResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUnload(unload);
            litleBatchRequest.AddUnload(unload);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextUnloadResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextUnloadResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextUnloadResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testBalanceInquiry()
        {
            var balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderId = "theOrderId";
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></balanceInquiryResponse>")
                .Returns(
                    "<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></balanceInquiryResponse>");

            var mockLitleBatchResponse = new batchResponse();
            mockLitleBatchResponse.setBalanceInquiryResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse()).Returns(mockLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            var mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            var mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddBalanceInquiry(balanceInquiry);
            litleBatchRequest.AddBalanceInquiry(balanceInquiry);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();
            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.nextBalanceInquiryResponse().litleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.nextBalanceInquiryResponse().litleTxnId);
            Assert.IsNull(actualLitleBatchResponse.nextBalanceInquiryResponse());

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckPreNoteSale()
        {
            var echeckPreNoteSale = new EcheckPreNoteSale();
            echeckPreNoteSale.OrderId = "12345";
            echeckPreNoteSale.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckPreNoteSale.Echeck = echeck;
            var contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckPreNoteSale.BillToAddress = contact;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteSaleResponse>")
                .Returns(
                    "<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteSaleResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckPreNoteSaleResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSale);
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSale);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckPreNoteSaleResponse1 = actualLitleBatchResponse.nextEcheckPreNoteSaleResponse();
            var actualEcheckPreNoteSaleResponse2 = actualLitleBatchResponse.nextEcheckPreNoteSaleResponse();
            var nullEcheckPreNoteSalesResponse = actualLitleBatchResponse.nextEcheckPreNoteSaleResponse();

            Assert.AreEqual(123, actualEcheckPreNoteSaleResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckPreNoteSaleResponse2.litleTxnId);
            Assert.IsNull(nullEcheckPreNoteSalesResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }

        [Test]
        public void testEcheckPreNoteCredit()
        {
            var echeckPreNoteCredit = new EcheckPreNoteCredit();
            echeckPreNoteCredit.OrderId = "12345";
            echeckPreNoteCredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.CorpSavings;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckPreNoteCredit.Echeck = echeck;
            var contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckPreNoteCredit.BillToAddress = contact;

            var mockLitleResponse = new Mock<litleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns(
                    "<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteCreditResponse>")
                .Returns(
                    "<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteCreditResponse>");

            var mockedLitleBatchResponse = new batchResponse();
            mockedLitleBatchResponse.setEcheckPreNoteCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(mockedLitleBatchResponse);
            var mockedLitleResponse = mockLitleResponse.Object;

            var mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(
                litleXmlSerializer =>
                    litleXmlSerializer.DeserializeObjectFromFile(mockCommunications.Object, It.IsAny<string>()))
                .Returns(mockedLitleResponse);
            var mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            var mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCredit);
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCredit);
            litle.AddBatch(litleBatchRequest);

            var batchFileName = litle.SendToLitle();

            var actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualEcheckPreNoteCreditResponse1 = actualLitleBatchResponse.nextEcheckPreNoteCreditResponse();
            var actualEcheckPreNoteCreditResponse2 = actualLitleBatchResponse.nextEcheckPreNoteCreditResponse();
            var nullEcheckPreNoteCreditsResponse = actualLitleBatchResponse.nextEcheckPreNoteCreditResponse();

            Assert.AreEqual(123, actualEcheckPreNoteCreditResponse1.litleTxnId);
            Assert.AreEqual(124, actualEcheckPreNoteCreditResponse2.litleTxnId);
            Assert.IsNull(nullEcheckPreNoteCreditsResponse);

            mockCommunications.Verify(
                Communications =>
                    Communications.FtpDropOff(It.IsAny<string>(), mockFileName, It.IsAny<Dictionary<string, string>>()));
            mockCommunications.Verify(
                Communications =>
                    Communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), mockFileName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;
using Moq.Language.Flow;
using System.Xml;
using Capture = Litle.Sdk.Requests.Capture;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestBatch
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

        [TestFixtureSetUp]
        public void setUp()
        {
            mockLitleTime = new Mock<LitleTime>();
            mockLitleTime.Setup(litleTime => litleTime.GetCurrentTime(It.Is<String>(resultFormat => resultFormat == timeFormat))).Returns("01-01-1960_01-22-30-1234_");

            mockLitleFile = new Mock<LitleFile>();
            mockLitleFile.Setup(litleFile => litleFile.CreateDirectory(It.IsAny<String>()));
            mockLitleFile.Setup(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object)).Returns(mockFilePath);
            mockLitleFile.Setup(litleFile => litleFile.AppendFileToFile(mockFilePath, It.IsAny<String>())).Returns(mockFilePath);
            mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(mockFilePath, It.IsAny<String>())).Returns(mockFilePath);

            mockCommunications = new Mock<Communications>();
        }

        [SetUp]
        public void setUpBeforeEachTest()
        {
            litle = new LitleRequest();

            mockXmlReader = new Mock<XmlReader>();
            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadToFollowing(It.IsAny<String>())).Returns(true).Returns(true).Returns(false);
            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadState).Returns(ReadState.Initial).Returns(ReadState.Interactive).Returns(ReadState.Closed);
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

            litle = new LitleRequest(mockConfig);

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
            AccountUpdate accountUpdate = new AccountUpdate();
            accountUpdate.ReportGroup = "Planets";
            accountUpdate.OrderId = "12344";
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            accountUpdate.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>")
                .Returns("<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetAccountUpdateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAccountUpdate(accountUpdate);
            litleBatchRequest.AddAccountUpdate(accountUpdate);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            AccountUpdateResponse actualAccountUpdateResponse1 = actualLitleBatchResponse.NextAccountUpdateResponse();
            AccountUpdateResponse actualAccountUpdateResponse2 = actualLitleBatchResponse.NextAccountUpdateResponse();
            AccountUpdateResponse nullAccountUpdateResponse = actualLitleBatchResponse.NextAccountUpdateResponse();

            Assert.AreEqual(123, actualAccountUpdateResponse1.LitleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse1.Response);
            Assert.AreEqual(124, actualAccountUpdateResponse2.LitleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse2.Response);
            Assert.IsNull(nullAccountUpdateResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }


        [Test]
        public void testAuth()
        {
            Authorization authorization = new Authorization();
            authorization.ReportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>123</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>")
                .Returns("<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>124</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetAuthorizationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthorization(authorization);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextAuthorizationResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextAuthorizationResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextAuthorizationResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testAuthReversal()
        {
            AuthReversal authreversal = new AuthReversal();
            authreversal.LitleTxnId = 12345678000;
            authreversal.Amount = 106;
            authreversal.PayPalNotes = "Notes";

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>")
                .Returns("<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetAuthReversalResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunications = mockCommunications.Object;
            litle.SetCommunication(mockedCommunications);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthReversal(authreversal);
            litleBatchRequest.AddAuthReversal(authreversal);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            AuthReversalResponse actualAuthReversalResponse1 = actualLitleBatchResponse.NextAuthReversalResponse();
            AuthReversalResponse actualAuthReversalResponse2 = actualLitleBatchResponse.NextAuthReversalResponse();
            AuthReversalResponse nullAuthReversalResponse = actualLitleBatchResponse.NextAuthReversalResponse();

            Assert.AreEqual(123, actualAuthReversalResponse1.LitleTxnId);
            Assert.AreEqual(124, actualAuthReversalResponse2.LitleTxnId);
            Assert.IsNull(nullAuthReversalResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testCapture()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 12345678000;
            capture.Amount = 106;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
              .Returns("<captureResponse id=\"123\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>123</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>")
              .Returns("<captureResponse id=\"124\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>124</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetCaptureResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCapture(capture);
            litleBatchRequest.AddCapture(capture);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            CaptureResponse actualCaptureResponse1 = actualLitleBatchResponse.NextCaptureResponse();
            CaptureResponse actualCaptureResponse2 = actualLitleBatchResponse.NextCaptureResponse();
            CaptureResponse nullCaptureResponse = actualLitleBatchResponse.NextCaptureResponse();

            Assert.AreEqual(123, actualCaptureResponse1.LitleTxnId);
            Assert.AreEqual(124, actualCaptureResponse2.LitleTxnId);
            Assert.IsNull(nullCaptureResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testCaptureGivenAuth()
        {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.OrderId = "12344";
            capturegivenauth.Amount = 106;
            AuthInformation authinfo = new AuthInformation();
            authinfo.AuthDate = new DateTime(2002, 10, 9);
            authinfo.AuthCode = "543216";
            authinfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authinfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            capturegivenauth.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></captureGivenAuthResponse>")
                .Returns("<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></captureGivenAuthResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetCaptureGivenAuthResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);
            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            CaptureGivenAuthResponse actualCaptureGivenAuthReponse1 = actualLitleBatchResponse.NextCaptureGivenAuthResponse();
            CaptureGivenAuthResponse actualCaptureGivenAuthReponse2 = actualLitleBatchResponse.NextCaptureGivenAuthResponse();
            CaptureGivenAuthResponse nullCaptureGivenAuthReponse = actualLitleBatchResponse.NextCaptureGivenAuthResponse();

            Assert.AreEqual(123, actualCaptureGivenAuthReponse1.LitleTxnId);
            Assert.AreEqual(124, actualCaptureGivenAuthReponse2.LitleTxnId);
            Assert.IsNull(nullCaptureGivenAuthReponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testCredit()
        {
            Credit credit = new Credit();
            credit.OrderId = "12344";
            credit.Amount = 106;
            credit.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            credit.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></creditResponse>")
                .Returns("<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></creditResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCredit(credit);
            litleBatchRequest.AddCredit(credit);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            CreditResponse actualCreditReponse1 = actualLitleBatchResponse.NextCreditResponse();
            CreditResponse actualCreditReponse2 = actualLitleBatchResponse.NextCreditResponse();
            CreditResponse nullCreditReponse1 = actualLitleBatchResponse.NextCreditResponse();

            Assert.AreEqual(123, actualCreditReponse1.LitleTxnId);
            Assert.AreEqual(124, actualCreditReponse2.LitleTxnId);
            Assert.IsNull(nullCreditReponse1);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckCredit()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12;
            echeckcredit.LitleTxnId = 123456789101112;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckCreditResponse>")
                .Returns("<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckCreditResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckCredit(echeckcredit);
            litleBatchRequest.AddEcheckCredit(echeckcredit);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckCreditResponse actualEcheckCreditResponse1 = actualLitleBatchResponse.NextEcheckCreditResponse();
            EcheckCreditResponse actualEcheckCreditResponse2 = actualLitleBatchResponse.NextEcheckCreditResponse();
            EcheckCreditResponse nullEcheckCreditResponse = actualLitleBatchResponse.NextEcheckCreditResponse();

            Assert.AreEqual(123, actualEcheckCreditResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckCreditResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckCreditResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckRedeposit()
        {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.LitleTxnId = 123456;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckRedepositResponse>")
                .Returns("<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckRedepositResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckRedepositResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckRedepositResponse actualEcheckRedepositResponse1 = actualLitleBatchResponse.NextEcheckRedepositResponse();
            EcheckRedepositResponse actualEcheckRedepositResponse2 = actualLitleBatchResponse.NextEcheckRedepositResponse();
            EcheckRedepositResponse nullEcheckRedepositResponse = actualLitleBatchResponse.NextEcheckRedepositResponse();

            Assert.AreEqual(123, actualEcheckRedepositResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckRedepositResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckRedepositResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckSale()
        {
            EcheckSale echecksale = new EcheckSale();
            echecksale.OrderId = "12345";
            echecksale.Amount = 123456;
            echecksale.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echecksale.Echeck = echeck;
            Contact contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echecksale.BillToAddress = contact;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckSalesResponse>")
                .Returns("<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckSalesResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckSalesResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckSale(echecksale);
            litleBatchRequest.AddEcheckSale(echecksale);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckSalesResponse actualEcheckSalesResponse1 = actualLitleBatchResponse.NextEcheckSalesResponse();
            EcheckSalesResponse actualEcheckSalesResponse2 = actualLitleBatchResponse.NextEcheckSalesResponse();
            EcheckSalesResponse nullEcheckSalesResponse = actualLitleBatchResponse.NextEcheckSalesResponse();

            Assert.AreEqual(123, actualEcheckSalesResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckSalesResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckSalesResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckVerification()
        {
            EcheckVerification echeckverification = new EcheckVerification();
            echeckverification.OrderId = "12345";
            echeckverification.Amount = 123456;
            echeckverification.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckverification.Echeck = echeck;
            Contact contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckverification.BillToAddress = contact;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckVerificationResponse>")
                .Returns("<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckVerificationResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckVerificationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckVerification(echeckverification);
            litleBatchRequest.AddEcheckVerification(echeckverification);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckVerificationResponse actualEcheckVerificationResponse1 = actualLitleBatchResponse.NextEcheckVerificationResponse();
            EcheckVerificationResponse actualEcheckVerificationResponse2 = actualLitleBatchResponse.NextEcheckVerificationResponse();
            EcheckVerificationResponse nullEcheckVerificationResponse = actualLitleBatchResponse.NextEcheckVerificationResponse();

            Assert.AreEqual(123, actualEcheckVerificationResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckVerificationResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckVerificationResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testForceCapture()
        {
            ForceCapture forcecapture = new ForceCapture();
            forcecapture.OrderId = "12344";
            forcecapture.Amount = 106;
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            forcecapture.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></forceCaptureResponse>")
                .Returns("<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></forceCaptureResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetForceCaptureResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddForceCapture(forcecapture);
            litleBatchRequest.AddForceCapture(forcecapture);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            ForceCaptureResponse actualForceCaptureResponse1 = actualLitleBatchResponse.NextForceCaptureResponse();
            ForceCaptureResponse actualForceCaptureResponse2 = actualLitleBatchResponse.NextForceCaptureResponse();
            ForceCaptureResponse nullForceCaptureResponse = actualLitleBatchResponse.NextForceCaptureResponse();

            Assert.AreEqual(123, actualForceCaptureResponse1.LitleTxnId);
            Assert.AreEqual(124, actualForceCaptureResponse2.LitleTxnId);
            Assert.IsNull(nullForceCaptureResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testSale()
        {
            Sale sale = new Sale();
            sale.OrderId = "12344";
            sale.Amount = 106;
            sale.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            sale.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></saleResponse>")
                .Returns("<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></saleResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetSaleResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddSale(sale);
            litleBatchRequest.AddSale(sale);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            SaleResponse actualSaleResponse1 = actualLitleBatchResponse.NextSaleResponse();
            SaleResponse actualSaleResponse2 = actualLitleBatchResponse.NextSaleResponse();
            SaleResponse nullSaleResponse = actualLitleBatchResponse.NextSaleResponse();

            Assert.AreEqual(123, actualSaleResponse1.LitleTxnId);
            Assert.AreEqual(124, actualSaleResponse2.LitleTxnId);
            Assert.IsNull(nullSaleResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testToken()
        {
            RegisterTokenRequestType token = new RegisterTokenRequestType();
            token.OrderId = "12344";
            token.AccountNumber = "1233456789103801";

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></registerTokenResponse>")
                .Returns("<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></registerTokenResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetRegisterTokenResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddRegisterTokenRequest(token);
            litleBatchRequest.AddRegisterTokenRequest(token);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            RegisterTokenResponse actualRegisterTokenResponse1 = actualLitleBatchResponse.NextRegisterTokenResponse();
            RegisterTokenResponse actualRegisterTokenResponse2 = actualLitleBatchResponse.NextRegisterTokenResponse();
            RegisterTokenResponse nullRegisterTokenResponse = actualLitleBatchResponse.NextRegisterTokenResponse();

            Assert.AreEqual(123, actualRegisterTokenResponse1.LitleTxnId);
            Assert.AreEqual(124, actualRegisterTokenResponse2.LitleTxnId);
            Assert.IsNull(nullRegisterTokenResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testUpdateCardValidationNumOnToken()
        {
            UpdateCardValidationNumOnToken updateCardValidationNumOnToken = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken.OrderId = "12344";
            updateCardValidationNumOnToken.LitleToken = "123";

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></updateCardValidationNumOnTokenResponse>")
                .Returns("<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></updateCardValidationNumOnTokenResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetUpdateCardValidationNumOnTokenResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);
            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            UpdateCardValidationNumOnTokenResponse actualUpdateCardValidationNumOnTokenResponse1 = actualLitleBatchResponse.NextUpdateCardValidationNumOnTokenResponse();
            UpdateCardValidationNumOnTokenResponse actualUpdateCardValidationNumOnTokenResponse2 = actualLitleBatchResponse.NextUpdateCardValidationNumOnTokenResponse();
            UpdateCardValidationNumOnTokenResponse nullUpdateCardValidationNumOnTokenResponse = actualLitleBatchResponse.NextUpdateCardValidationNumOnTokenResponse();

            Assert.AreEqual(123, actualUpdateCardValidationNumOnTokenResponse1.LitleTxnId);
            Assert.AreEqual(124, actualUpdateCardValidationNumOnTokenResponse2.LitleTxnId);
            Assert.IsNull(nullUpdateCardValidationNumOnTokenResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testLitleOnlineException()
        {
            Authorization authorization = new Authorization();
            authorization.ReportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleBatchResponse = new Mock<BatchResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            AuthorizationResponse mockAuthorizationResponse1 = new AuthorizationResponse();
            mockAuthorizationResponse1.LitleTxnId = 123;
            AuthorizationResponse mockAuthorizationResponse2 = new AuthorizationResponse();
            mockAuthorizationResponse2.LitleTxnId = 124;

            mockLitleBatchResponse.SetupSequence(litleBatchResponse => litleBatchResponse.NextAuthorizationResponse())
                .Returns(mockAuthorizationResponse1)
                .Returns(mockAuthorizationResponse2)
                .Returns((AuthorizationResponse)null);

            LitleResponse mockedLitleResponse = mockLitleResponse.Object;
            mockedLitleResponse.Message = "Error validating xml data against the schema";
            mockedLitleResponse.Response = "1";

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            try
            {
                litle.SetCommunication(mockedCommunications);
                litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
                litle.SetLitleFile(mockedLitleFile);
                litle.SetLitleTime(mockLitleTime.Object);
                BatchRequest litleBatchRequest = new BatchRequest();
                litleBatchRequest.SetLitleFile(mockedLitleFile);
                litleBatchRequest.SetLitleTime(mockLitleTime.Object);

                litleBatchRequest.AddAuthorization(authorization);
                litleBatchRequest.AddAuthorization(authorization);
                litle.AddBatch(litleBatchRequest);

                string batchFileName = litle.SendToLitle();
                LitleResponse litleResponse = litle.ReceiveFromLitle(batchFileName);
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void testInvalidOperationException()
        {
            Authorization authorization = new Authorization();
            authorization.ReportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            LitleResponse mockLitleResponse = null;

            var mockXml = new Mock<LitleXmlSerializer>();

            Communications mockedCommunications = mockCommunications.Object;

            mockXml.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockXml.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            try
            {
                litle.SetCommunication(mockedCommunications);
                litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
                litle.SetLitleFile(mockedLitleFile);
                litle.SetLitleTime(mockLitleTime.Object);
                BatchRequest litleBatchRequest = new BatchRequest();
                litleBatchRequest.SetLitleFile(mockedLitleFile);
                litleBatchRequest.SetLitleTime(mockLitleTime.Object);

                litleBatchRequest.AddAuthorization(authorization);
                litleBatchRequest.AddAuthorization(authorization);
                litle.AddBatch(litleBatchRequest);

                string batchFileName = litle.SendToLitle();
                LitleResponse litleResponse = litle.ReceiveFromLitle(batchFileName);
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void testDefaultReportGroup()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></authorizationResponse>")
                .Returns("<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></authorizationResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetAuthorizationResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);
            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddAuthorization(authorization);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            AuthorizationResponse actualAuthorizationResponse1 = actualLitleBatchResponse.NextAuthorizationResponse();
            AuthorizationResponse actualAuthorizationResponse2 = actualLitleBatchResponse.NextAuthorizationResponse();
            AuthorizationResponse nullAuthorizationResponse = actualLitleBatchResponse.NextAuthorizationResponse();

            Assert.AreEqual(123, actualAuthorizationResponse1.LitleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse1.ReportGroup);
            Assert.AreEqual(124, actualAuthorizationResponse2.LitleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse2.ReportGroup);
            Assert.IsNull(nullAuthorizationResponse);

            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, It.IsRegex(".*reportGroup=\"Default Report Group\".*", RegexOptions.Singleline)));
            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testSerialize()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card;

            LitleFile mockedLitleFile = mockLitleFile.Object;
            LitleTime mockedLitleTime = mockLitleTime.Object;

            litle.SetLitleTime(mockedLitleTime);
            litle.SetLitleFile(mockedLitleFile);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.AddAuthorization(authorization);
            litle.AddBatch(litleBatchRequest);

            string resultFile = litle.Serialize();

            Assert.IsTrue(resultFile.Equals(mockFilePath));

            mockLitleFile.Verify(litleFile => litleFile.AppendFileToFile(mockFilePath, It.IsAny<String>()));
        }

        [Test]
        public void testRFRRequest()
        {
            RfrRequest rfrRequest = new RfrRequest();
            rfrRequest.LitleSessionId = 123456789;

            var mockBatchXmlReader = new Mock<XmlReader>();
            mockBatchXmlReader.Setup(XmlReader => XmlReader.ReadState).Returns(ReadState.Closed);

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadState).Returns(ReadState.Interactive).Returns(ReadState.Closed);
            mockXmlReader.Setup(XmlReader => XmlReader.ReadOuterXml()).Returns("<RFRResponse response=\"1\" message=\"The account update file is not ready yet. Please try again later.\" xmlns='http://www.litle.com/schema'> </RFRResponse>");

            LitleResponse mockedLitleResponse = new LitleResponse();
            mockedLitleResponse.SetRfrResponseReader(mockXmlReader.Object);
            mockedLitleResponse.SetBatchResponseReader(mockBatchXmlReader.Object);

            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();
            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;
            LitleTime mockedLitleTime = mockLitleTime.Object;
            Communications mockedCommunications = mockCommunications.Object;

            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockedLitleTime);
            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            rfrRequest.SetLitleFile(mockedLitleFile);
            rfrRequest.SetLitleTime(mockedLitleTime);

            litle.AddRfrRequest(rfrRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse nullLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            RFRResponse actualRFRResponse = actualLitleResponse.NextRFRResponse();
            RFRResponse nullRFRResponse = actualLitleResponse.NextRFRResponse();

            Assert.IsNotNull(actualRFRResponse);
            Assert.AreEqual("1", actualRFRResponse.Response);
            Assert.AreEqual("The account update file is not ready yet. Please try again later.", actualRFRResponse.Message);
            Assert.IsNull(nullLitleBatchResponse);
            Assert.IsNull(nullRFRResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testCancelSubscription()
        {
            CancelSubscription cancel = new CancelSubscription();
            cancel.SubscriptionId = 12345;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></cancelSubscriptionResponse>")
                .Returns("<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></cancelSubscriptionResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetCancelSubscriptionResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCancelSubscription(cancel);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("12345", actualLitleBatchResponse.NextCancelSubscriptionResponse().SubscriptionId);
            Assert.AreEqual("54321", actualLitleBatchResponse.NextCancelSubscriptionResponse().SubscriptionId);
            Assert.IsNull(actualLitleBatchResponse.NextCancelSubscriptionResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testUpdateSubscription()
        {
            UpdateSubscription update = new UpdateSubscription();
            update.BillingDate = new DateTime(2002, 10, 9);
            Contact billToAddress = new Contact();
            billToAddress.Name = "Greg Dake";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "sdksupport@litle.com";
            update.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "4100000000000001";
            card.ExpDate = "1215";
            card.Type = MethodOfPaymentTypeEnum.VI;
            update.Card = card;
            update.PlanCode = "abcdefg";
            update.SubscriptionId = 12345;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></updateSubscriptionResponse>")
                .Returns("<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></updateSubscriptionResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetUpdateSubscriptionResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdateSubscription(update);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("12345", actualLitleBatchResponse.NextUpdateSubscriptionResponse().SubscriptionId);
            Assert.AreEqual("54321", actualLitleBatchResponse.NextUpdateSubscriptionResponse().SubscriptionId);
            Assert.IsNull(actualLitleBatchResponse.NextUpdateSubscriptionResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testCreatePlan()
        {
            CreatePlan createPlan = new CreatePlan();
            createPlan.PlanCode = "thePlanCode";
            createPlan.Name = "theName";
            createPlan.IntervalType = IntervalType.Annual;
            createPlan.Amount = 100;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></createPlanResponse>")
                .Returns("<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></createPlanResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetCreatePlanResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddCreatePlan(createPlan);
            litleBatchRequest.AddCreatePlan(createPlan);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.NextCreatePlanResponse().LitleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.NextCreatePlanResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextCreatePlanResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testUpdatePlan()
        {
            UpdatePlan updatePlan = new UpdatePlan();
            updatePlan.PlanCode = "thePlanCode";
            updatePlan.Active = true;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></updatePlanResponse>")
                .Returns("<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></updatePlanResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetUpdatePlanResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUpdatePlan(updatePlan);
            litleBatchRequest.AddUpdatePlan(updatePlan);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual("123", actualLitleBatchResponse.NextUpdatePlanResponse().LitleTxnId);
            Assert.AreEqual("124", actualLitleBatchResponse.NextUpdatePlanResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextUpdatePlanResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testActivate()
        {
            Activate activate = new Activate();
            activate.OrderId = "theOrderId";
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.Card = new CardType();

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></activateResponse>")
                .Returns("<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></activateResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetActivateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddActivate(activate);
            litleBatchRequest.AddActivate(activate);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextActivateResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextActivateResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextActivateResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testDeactivate()
        {
            Deactivate deactivate = new Deactivate();
            deactivate.OrderId = "theOrderId";
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></deactivateResponse>")
                .Returns("<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></deactivateResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetDeactivateResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddDeactivate(deactivate);
            litleBatchRequest.AddDeactivate(deactivate);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextDeactivateResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextDeactivateResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextDeactivateResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testLoad()
        {
            Load load = new Load();
            load.OrderId = "theOrderId";
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></loadResponse>")
                .Returns("<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></loadResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetLoadResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddLoad(load);
            litleBatchRequest.AddLoad(load);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextLoadResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextLoadResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextLoadResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testUnload()
        {
            Unload unload = new Unload();
            unload.OrderId = "theOrderId";
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></unloadResponse>")
                .Returns("<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></unloadResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetUnloadResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddUnload(unload);
            litleBatchRequest.AddUnload(unload);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextUnloadResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextUnloadResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextUnloadResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testBalanceInquiry()
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderId = "theOrderId";
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></balanceInquiryResponse>")
                .Returns("<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></balanceInquiryResponse>");

            BatchResponse mockLitleBatchResponse = new BatchResponse();
            mockLitleBatchResponse.SetBalanceInquiryResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);

            Communications mockedCommunication = mockCommunications.Object;
            litle.SetCommunication(mockedCommunication);

            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);

            LitleFile mockedLitleFile = mockLitleFile.Object;
            litle.SetLitleFile(mockedLitleFile);

            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddBalanceInquiry(balanceInquiry);
            litleBatchRequest.AddBalanceInquiry(balanceInquiry);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();
            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();

            Assert.AreSame(mockLitleBatchResponse, actualLitleBatchResponse);
            Assert.AreEqual(123, actualLitleBatchResponse.NextBalanceInquiryResponse().LitleTxnId);
            Assert.AreEqual(124, actualLitleBatchResponse.NextBalanceInquiryResponse().LitleTxnId);
            Assert.IsNull(actualLitleBatchResponse.NextBalanceInquiryResponse());

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckPreNoteSale()
        {
            EcheckPreNoteSale echeckPreNoteSale = new EcheckPreNoteSale();
            echeckPreNoteSale.OrderId = "12345";
            echeckPreNoteSale.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckPreNoteSale.Echeck = echeck;
            Contact contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckPreNoteSale.BillToAddress = contact;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteSaleResponse>")
                .Returns("<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteSaleResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckPreNoteSaleResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSale);
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSale);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckPreNoteSaleResponse actualEcheckPreNoteSaleResponse1 = actualLitleBatchResponse.NextEcheckPreNoteSaleResponse();
            EcheckPreNoteSaleResponse actualEcheckPreNoteSaleResponse2 = actualLitleBatchResponse.NextEcheckPreNoteSaleResponse();
            EcheckPreNoteSaleResponse nullEcheckPreNoteSalesResponse = actualLitleBatchResponse.NextEcheckPreNoteSaleResponse();

            Assert.AreEqual(123, actualEcheckPreNoteSaleResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckPreNoteSaleResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckPreNoteSalesResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }

        [Test]
        public void testEcheckPreNoteCredit()
        {
            EcheckPreNoteCredit echeckPreNoteCredit = new EcheckPreNoteCredit();
            echeckPreNoteCredit.OrderId = "12345";
            echeckPreNoteCredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.CorpSavings;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckPreNoteCredit.Echeck = echeck;
            Contact contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email = "litle.com";
            echeckPreNoteCredit.BillToAddress = contact;

            var mockLitleResponse = new Mock<LitleResponse>();
            var mockLitleXmlSerializer = new Mock<LitleXmlSerializer>();

            mockXmlReader.SetupSequence(XmlReader => XmlReader.ReadOuterXml())
                .Returns("<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteCreditResponse>")
                .Returns("<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteCreditResponse>");

            BatchResponse mockedLitleBatchResponse = new BatchResponse();
            mockedLitleBatchResponse.SetEcheckPreNoteCreditResponseReader(mockXmlReader.Object);

            mockLitleResponse.Setup(litleResponse => litleResponse.NextBatchResponse()).Returns(mockedLitleBatchResponse);
            LitleResponse mockedLitleResponse = mockLitleResponse.Object;

            Communications mockedCommunications = mockCommunications.Object;

            mockLitleXmlSerializer.Setup(litleXmlSerializer => litleXmlSerializer.DeserializeObjectFromFile(It.IsAny<String>())).Returns(mockedLitleResponse);
            LitleXmlSerializer mockedLitleXmlSerializer = mockLitleXmlSerializer.Object;

            LitleFile mockedLitleFile = mockLitleFile.Object;

            litle.SetCommunication(mockedCommunications);
            litle.SetLitleXmlSerializer(mockedLitleXmlSerializer);
            litle.SetLitleFile(mockedLitleFile);
            litle.SetLitleTime(mockLitleTime.Object);

            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.SetLitleFile(mockedLitleFile);
            litleBatchRequest.SetLitleTime(mockLitleTime.Object);
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCredit);
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCredit);
            litle.AddBatch(litleBatchRequest);

            string batchFileName = litle.SendToLitle();

            LitleResponse actualLitleResponse = litle.ReceiveFromLitle(batchFileName);
            BatchResponse actualLitleBatchResponse = actualLitleResponse.NextBatchResponse();
            EcheckPreNoteCreditResponse actualEcheckPreNoteCreditResponse1 = actualLitleBatchResponse.NextEcheckPreNoteCreditResponse();
            EcheckPreNoteCreditResponse actualEcheckPreNoteCreditResponse2 = actualLitleBatchResponse.NextEcheckPreNoteCreditResponse();
            EcheckPreNoteCreditResponse nullEcheckPreNoteCreditsResponse = actualLitleBatchResponse.NextEcheckPreNoteCreditResponse();

            Assert.AreEqual(123, actualEcheckPreNoteCreditResponse1.LitleTxnId);
            Assert.AreEqual(124, actualEcheckPreNoteCreditResponse2.LitleTxnId);
            Assert.IsNull(nullEcheckPreNoteCreditsResponse);

            mockCommunications.Verify(Communications => Communications.FtpDropOff(It.IsAny<String>(), mockFileName, It.IsAny<Dictionary<String, String>>()));
            mockCommunications.Verify(Communications => Communications.FtpPickUp(It.IsAny<String>(), It.IsAny<Dictionary<String, String>>(), mockFileName));
        }
    }
}

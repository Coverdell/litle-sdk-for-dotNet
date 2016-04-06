using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestBatch : LitleRequestTestBase
    {
        #region Setup

        private const string TimeFormat = "MM-dd-yyyy_HH-mm-ss-ffff_",
            MockFileName = "TheRainbow.xml",
            MockFilePath = "C:\\Somewhere\\Over\\" + MockFileName;

        private Mock<litleTime> _mockLitleTime;
        private Mock<litleFile> _mockLitleFile;
        private Mock<Communications> _mockCommunications;
        private Mock<XmlReader> _mockXmlReader;
        private Mock<IDictionary<string, StringBuilder>> _mockCache;

        [SetUp]
        public override void SetUp()
        {
            _mockCache = new Mock<IDictionary<string, StringBuilder>>();

            base.SetUp();
            _mockCache.Setup(x => x[Config["responseDirectory"] + "\\Responses\\" + MockFileName])
                .Returns(new StringBuilder());
            _mockLitleTime = new Mock<litleTime>();
            _mockLitleTime.Setup(litleTime =>
                litleTime.getCurrentTime(It.Is<string>(resultFormat => resultFormat == TimeFormat)))
                .Returns("01-01-1960_01-22-30-1234_");

            _mockLitleFile = new Mock<litleFile>(_mockCache.Object);
            _mockLitleFile.Setup(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object))
                .Returns(MockFilePath);
            _mockLitleFile.Setup(litleFile => litleFile.AppendFileToFile(MockFilePath, It.IsAny<string>()))
                .Returns(MockFilePath);
            _mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(MockFilePath, It.IsAny<string>()))
                .Returns(MockFilePath);

            _mockCommunications = new Mock<Communications>(_mockCache.Object);

            _mockXmlReader = new Mock<XmlReader>();
            _mockXmlReader.SetupSequence(xmlReader => xmlReader.ReadToFollowing(It.IsAny<string>()))
                .Returns(true)
                .Returns(true)
                .Returns(false);
            _mockXmlReader.SetupSequence(xmlReader => xmlReader.ReadState)
                .Returns(ReadState.Initial)
                .Returns(ReadState.Interactive)
                .Returns(ReadState.Closed);
        }

        protected override Dictionary<string, string> SetupConfig() => new Dictionary<string, string>
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
        };

        protected override IDictionary<string, StringBuilder> SetupCache() => _mockCache.Object;

        #endregion Setup

        [Test]
        public void TestInitialization()
        {
            var litle = new litleRequest(_mockCache.Object, Config);

            Assert.AreEqual("C:\\MockRequests\\Requests\\", litle.getRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", litle.getResponseDirectory());

            Assert.NotNull(litle.getCommunication());
            Assert.NotNull(litle.getLitleTime());
            Assert.NotNull(litle.getLitleFile());
            Assert.NotNull(litle.getLitleXmlSerializer());
        }

        [Test]
        public void TestAccountUpdate()
        {
            SetupBatch(
                batchRequest => batchRequest.setAccountUpdateResponseReader,
                batchRequest => batchRequest.addAccountUpdate,
                new accountUpdate
                {
                    reportGroup = "Planets",
                    orderId = "12344",
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                },
                "<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>",
                "<accountUpdateResponse reportGroup=\"Merch01ReportGrp\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>MERCH01-0002</orderId><response>000</response><responseTime>2010-04-11T15:44:26</responseTime><message>Approved</message></accountUpdateResponse>");

            var actualLitleBatchResponse = GetLitleBatchResponse();
            var actualAccountUpdateResponse1 = actualLitleBatchResponse.nextAccountUpdateResponse();
            var actualAccountUpdateResponse2 = actualLitleBatchResponse.nextAccountUpdateResponse();
            var nullAccountUpdateResponse = actualLitleBatchResponse.nextAccountUpdateResponse();

            Assert.AreEqual(123, actualAccountUpdateResponse1.litleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse1.response);
            Assert.AreEqual(124, actualAccountUpdateResponse2.litleTxnId);
            Assert.AreEqual("000", actualAccountUpdateResponse2.response);
            Assert.IsNull(nullAccountUpdateResponse);
            VerifyCommunications();
        }

        [Test]
        public void TestAuth()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setAuthorizationResponseReader,
                batchRequest => batchRequest.addAuthorization,
                new authorization
                {
                    reportGroup = "Planets",
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                }, 
                "<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>123</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>",
                "<authorizationResponse id=\"\" reportGroup=\"Planets\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>124</orderId><response>000</response><responseTime>2013-06-19T19:54:42</responseTime><message>Approved</message><authCode>123457</authCode><fraudResult><avsResult>00</avsResult></fraudResult><tokenResponse><litleToken>1711000103054242</litleToken><tokenResponseCode>802</tokenResponseCode><tokenMessage>Account number was previously registered</tokenMessage><type>VI</type><bin>424242</bin></tokenResponse></authorizationResponse>");

            AssertResponsesMatch(mockLitleBatchResponse, 
                actualBatchResponse => actualBatchResponse.nextAuthorizationResponse(), 
                authorizationResponse => authorizationResponse.litleTxnId, 
                123, 124);
        }

        [Test]
        public void TestAuthReversal()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setAuthReversalResponseReader,
                batchRequest => batchRequest.addAuthReversal,
                new authReversal
                {
                    litleTxnId = 12345678000,
                    amount = 106,
                    payPalNotes = "Notes"
                }, 
                "<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>",
                "<authReversalResponse id=\"123\" customerId=\"Customer Id\" reportGroup=\"Auth Reversals\" xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId><orderId>abc123</orderId><response>000</response><responseTime>2011-08-30T13:15:43</responseTime><message>Approved</message></authReversalResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextAuthReversalResponse(), 
                authReversalResponse => authReversalResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestCapture()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setCaptureResponseReader,
                batchRequest => batchRequest.addCapture,
                new capture
                {
                    litleTxnId = 12345678000,
                    amount = 106
                }, 
                "<captureResponse id=\"123\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>123</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>",
                "<captureResponse id=\"124\" reportGroup=\"RG27\" xmlns=\"http://www.litle.com/schema\"> <litleTxnId>124</litleTxnId> <orderId>12z58743y1</orderId> <response>000</response> <responseTime>2011-09-01T10:24:31</responseTime> <message>message</message> </captureResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextCaptureResponse(), 
                captureResponse => captureResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestCaptureGivenAuth()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setCaptureGivenAuthResponseReader,
                batchRequest => batchRequest.addCaptureGivenAuth,
                new captureGivenAuth
                {
                    orderId = "12344",
                    amount = 106,
                    authInformation = new authInformation
                    {
                        authDate = new DateTime(2002, 10, 9),
                        authCode = "543216",
                        authAmount = 12345
                    },
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000001",
                        expDate = "1210"
                    }
                }, 
                "<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></captureGivenAuthResponse>",
                "<captureGivenAuthResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></captureGivenAuthResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextCaptureGivenAuthResponse(), 
                captureGivenAuthResponse => captureGivenAuthResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestCredit()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setCreditResponseReader,
                batchRequest => batchRequest.addCredit,
                new credit
                {
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000001",
                        expDate = "1210"
                    }
                },
                "<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></creditResponse>",
                "<creditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></creditResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextCreditResponse(), 
                creditResponse => creditResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestEcheckCredit()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setEcheckCreditResponseReader,
                batchRequest => batchRequest.addEcheckCredit,
                new echeckCredit
                {
                    amount = 12,
                    litleTxnId = 123456789101112
                }, 
                "<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckCreditResponse>",
                "<echeckCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckCreditResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckCreditResponse(), 
                echeckCreditResponse => echeckCreditResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestEcheckRedeposit()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setEcheckRedepositResponseReader,
                batchRequest => batchRequest.addEcheckRedeposit,
                new echeckRedeposit {litleTxnId = 123456}, 
                "<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckRedepositResponse>",
                "<echeckRedepositResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckRedepositResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckRedepositResponse(), 
                echeckRedepositResponse => echeckRedepositResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestEcheckSale()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setEcheckSalesResponseReader,
                batchRequest => batchRequest.addEcheckSale,
                new echeckSale
                {
                    orderId = "12345",
                    amount = 123456,
                    orderSource = orderSourceType.ecommerce,
                    echeck = new echeckType
                    {
                        accType = echeckAccountTypeEnum.Checking,
                        accNum = "12345657890",
                        routingNum = "123456789",
                        checkNum = "123455"
                    },
                    billToAddress = new contact
                    {
                        name = "Bob",
                        city = "lowell",
                        state = "MA",
                        email = "litle.com"
                    }
                }, 
                "<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckSalesResponse>",
                "<echeckSalesResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckSalesResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckSalesResponse(), 
                echeckSalesResponse => echeckSalesResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestEcheckVerification()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setEcheckVerificationResponseReader,
                batchRequest => batchRequest.addEcheckVerification,
                new echeckVerification
                {
                    orderId = "12345",
                    amount = 123456,
                    orderSource = orderSourceType.ecommerce,
                    echeck = new echeckType
                    {
                        accType = echeckAccountTypeEnum.Checking,
                        accNum = "12345657890",
                        routingNum = "123456789",
                        checkNum = "123455"
                    },
                    billToAddress = new contact
                    {
                        name = "Bob",
                        city = "lowell",
                        state = "MA",
                        email = "litle.com"
                    }
                }, 
                "<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckVerificationResponse>",
                "<echeckVerificationResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckVerificationResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckVerificationResponse(), 
                echeckVerificationResponse => echeckVerificationResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestForceCapture()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setForceCaptureResponseReader,
                batchRequest => batchRequest.addForceCapture,
                new forceCapture
                {
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000001",
                        expDate = "1210"
                    }
                }, 
                "<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></forceCaptureResponse>",
                "<forceCaptureResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></forceCaptureResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextForceCaptureResponse(), 
                forceCaptureResponse => forceCaptureResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestSale()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setSaleResponseReader,
                batchRequest => batchRequest.addSale,
                new sale
                {
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                }, 
                "<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></saleResponse>",
                "<saleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></saleResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextSaleResponse(), 
                batchResponse => batchResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestToken()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setRegisterTokenResponseReader,
                batchRequest => batchRequest.addRegisterTokenRequest,
                new registerTokenRequestType
                {
                    orderId = "12344",
                    accountNumber = "1233456789103801"
                }, 
                "<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></registerTokenResponse>",
                "<registerTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></registerTokenResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextRegisterTokenResponse(), 
                registerTokenResponse => registerTokenResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestUpdateCardValidationNumOnToken()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setUpdateCardValidationNumOnTokenResponseReader,
                batchRequest => batchRequest.addUpdateCardValidationNumOnToken,
                new updateCardValidationNumOnToken
                {
                    orderId = "12344",
                    litleToken = "123"
                }, 
                "<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></updateCardValidationNumOnTokenResponse>",
                "<updateCardValidationNumOnTokenResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></updateCardValidationNumOnTokenResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextUpdateCardValidationNumOnTokenResponse(), 
                updateCardValidationNumOnTokenResponse => updateCardValidationNumOnTokenResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestLitleOnlineException()
        {
            var authorization = new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            };

            var mockLitleResponse = new Mock<litleResponse>();
            mockLitleResponse.Object.message = "Error validating xml data against the schema";
            mockLitleResponse.Object.response = "1";

            try //TODO: Should the test fail after successfully executing the concern?
            {
                SetupLitleXml(mockLitleResponse.Object);
                SetupBatchRequest(batchRequest => batchRequest.addAuthorization,
                    authorization, authorization);

                GetLitleResponse();
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void TestInvalidOperationException()
        {
            var authorization = new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            };

            try //TODO: Should the test fail after successfully executing the concern?
            {
                SetupLitleXml(null);
                SetupBatchRequest(batchRequest => batchRequest.addAuthorization,
                    authorization, authorization);

                GetLitleResponse();
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void TestDefaultReportGroup()
        {
            SetupBatch(
                batchRequest => batchRequest.setAuthorizationResponseReader,
                batchRequest => batchRequest.addAuthorization,
                new authorization
                {
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                }, 
                "<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></authorizationResponse>",
                "<authorizationResponse reportGroup=\"Default Report Group\" xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></authorizationResponse>");

            var actualLitleBatchResponse = GetLitleBatchResponse();
            var actualAuthorizationResponse1 = actualLitleBatchResponse.nextAuthorizationResponse();
            var actualAuthorizationResponse2 = actualLitleBatchResponse.nextAuthorizationResponse();
            var nullAuthorizationResponse = actualLitleBatchResponse.nextAuthorizationResponse();

            Assert.AreEqual(123, actualAuthorizationResponse1.litleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse1.reportGroup);
            Assert.AreEqual(124, actualAuthorizationResponse2.litleTxnId);
            Assert.AreEqual("Default Report Group", actualAuthorizationResponse2.reportGroup);
            Assert.IsNull(nullAuthorizationResponse);

            _mockLitleFile.Verify(litleFile =>
                litleFile.AppendLineToFile(MockFilePath,
                    It.IsRegex(".*reportGroup=\"Default Report Group\".*", RegexOptions.Singleline)));
            VerifyCommunications();
        }

        [Test]
        public void TestSerialize()
        {
            SetupLitle();
            SetupBatchRequest(batchRequest => batchRequest.addAuthorization, new authorization
            {
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(MockFilePath, Litle.Serialize());

            _mockLitleFile.Verify(litleFile => litleFile.AppendFileToFile(MockFilePath, It.IsAny<string>()));
        }

        [Test]
        public void TestRfrRequest()
        {
            var rfrRequest = new RFRRequest(_mockCache.Object) {litleSessionId = 123456789};

            var mockBatchXmlReader = new Mock<XmlReader>();
            mockBatchXmlReader.Setup(xmlReader => xmlReader.ReadState).Returns(ReadState.Closed);

            _mockXmlReader.SetupSequence(xmlReader => xmlReader.ReadState)
                .Returns(ReadState.Interactive)
                .Returns(ReadState.Closed);
            _mockXmlReader.Setup(xmlReader => xmlReader.ReadOuterXml())
                .Returns(
                    "<RFRResponse response=\"1\" message=\"The account update file is not ready yet. Please try again later.\" xmlns='http://www.litle.com/schema'> </RFRResponse>");

            var mockedLitleResponse = new litleResponse();
            mockedLitleResponse.setRfrResponseReader(_mockXmlReader.Object);
            mockedLitleResponse.setBatchResponseReader(mockBatchXmlReader.Object);

            SetupLitleXml(mockedLitleResponse);
            rfrRequest.setLitleFile(_mockLitleFile.Object);
            rfrRequest.setLitleTime(_mockLitleTime.Object);

            Litle.addRFRRequest(rfrRequest);
            
            var actualLitleResponse = GetLitleResponse();
            var nullLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            var actualRfrResponse = actualLitleResponse.nextRFRResponse();
            var nullRfrResponse = actualLitleResponse.nextRFRResponse();

            Assert.IsNotNull(actualRfrResponse);
            Assert.AreEqual("1", actualRfrResponse.response);
            Assert.AreEqual("The account update file is not ready yet. Please try again later.",
                actualRfrResponse.message);
            Assert.IsNull(nullLitleBatchResponse);
            Assert.IsNull(nullRfrResponse);
            VerifyCommunications();
        }

        [Test]
        public void TestCancelSubscription()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setCancelSubscriptionResponseReader,
                batchRequest => batchRequest.addCancelSubscription,
                new cancelSubscription {subscriptionId = 12345}, 
                "<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></cancelSubscriptionResponse>",
                "<cancelSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></cancelSubscriptionResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextCancelSubscriptionResponse(), 
                cancelSubscriptionResponse => cancelSubscriptionResponse.subscriptionId,
                "12345", "54321");
        }

        [Test]
        public void TestUpdateSubscription()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setUpdateSubscriptionResponseReader,
                batchRequest => batchRequest.addUpdateSubscription,
                new updateSubscription
                {
                    billingDate = new DateTime(2002, 10, 9),
                    billToAddress = new contact
                    {
                        name = "Greg Dake",
                        city = "Lowell",
                        state = "MA",
                        email = "sdksupport@litle.com"
                    },
                    card = new cardType
                    {
                        number = "4100000000000001",
                        expDate = "1215",
                        type = methodOfPaymentTypeEnum.VI
                    },
                    planCode = "abcdefg",
                    subscriptionId = 12345
                }, 
                "<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>54321</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>12345</subscriptionId></updateSubscriptionResponse>",
                "<updateSubscriptionResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>12345</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04T21:55:14</responseTime><subscriptionId>54321</subscriptionId></updateSubscriptionResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextUpdateSubscriptionResponse(), 
                updateSubscriptionResponse => updateSubscriptionResponse.subscriptionId,
                "12345", "54321");
        }

        [Test]
        public void TestCreatePlan()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setCreatePlanResponseReader,
                batchRequest => batchRequest.addCreatePlan,
                new createPlan
                {
                    planCode = "thePlanCode",
                    name = "theName",
                    intervalType = intervalType.ANNUAL,
                    amount = 100
                }, 
                "<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></createPlanResponse>",
                "<createPlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></createPlanResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextCreatePlanResponse(), 
                createPlanResponse => createPlanResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestUpdatePlan()
        {
            var updatePlan = new updatePlan
            {
                planCode = "thePlanCode",
                active = true
            };
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setUpdatePlanResponseReader,
                batchRequest => batchRequest.addUpdatePlan,
                updatePlan, 
                "<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></updatePlanResponse>",
                "<updatePlanResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></updatePlanResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextUpdatePlanResponse(), 
                updatePlanResponse => updatePlanResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestActivate()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setActivateResponseReader,
                batchRequest => batchRequest.addActivate,
                new activate
                {
                    orderId = "theOrderId",
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType()
                }, 
                "<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></activateResponse>",
                "<activateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></activateResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextActivateResponse(), 
                activateResponse => activateResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestDeactivate()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setDeactivateResponseReader,
                batchRequest => batchRequest.addDeactivate,
                new deactivate
                {
                    orderId = "theOrderId",
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType()
                }, 
                "<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></deactivateResponse>",
                "<deactivateResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></deactivateResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextDeactivateResponse(), 
                deactivateResponse => deactivateResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestLoad()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setLoadResponseReader,
                batchRequest => batchRequest.addLoad,
                new load
                {
                    orderId = "theOrderId",
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType()
                }, 
                "<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></loadResponse>",
                "<loadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></loadResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextLoadResponse(), 
                batchResponse => batchResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestUnload()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setUnloadResponseReader,
                batchRequest => batchRequest.addUnload,
                new unload
                {
                    orderId = "theOrderId",
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType()
                }, 
                "<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></unloadResponse>",
                "<unloadResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></unloadResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextUnloadResponse(), 
                unloadResponse => unloadResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestBalanceInquiry()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setBalanceInquiryResponseReader,
                batchRequest => batchRequest.addBalanceInquiry,
                new balanceInquiry
                {
                    orderId = "theOrderId",
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType()
                },
                "<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>123</litleTxnId></balanceInquiryResponse>",
                "<balanceInquiryResponse xmlns=\"http://www.litle.com/schema\"><litleTxnId>124</litleTxnId></balanceInquiryResponse>");

            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextBalanceInquiryResponse(), 
                balanceInquiryResponse => balanceInquiryResponse.litleTxnId,
                "123", "124");
        }

        [Test]
        public void TestEcheckPreNoteSale()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchRequest => batchRequest.setEcheckPreNoteSaleResponseReader,
                batchRequest => batchRequest.addEcheckPreNoteSale,
                new echeckPreNoteSale
                {
                    orderId = "12345",
                    orderSource = orderSourceType.ecommerce,
                    echeck = new echeckType
                    {
                        accType = echeckAccountTypeEnum.Checking,
                        accNum = "12345657890",
                        routingNum = "123456789",
                        checkNum = "123455"
                    },
                    billToAddress = new contact
                    {
                        name = "Bob",
                        city = "lowell",
                        state = "MA",
                        email = "litle.com"
                    }
                },
                "<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteSaleResponse>",
                "<echeckPreNoteSaleResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteSaleResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckPreNoteSaleResponse(), 
                echeckPreNoteSaleResponse => echeckPreNoteSaleResponse.litleTxnId,
                123, 124);
        }

        [Test]
        public void TestEcheckPreNoteCredit()
        {
            var mockLitleBatchResponse = SetupBatch(
                batchResponse => batchResponse.setEcheckPreNoteCreditResponseReader,
                batchRequest => batchRequest.addEcheckPreNoteCredit,
                new echeckPreNoteCredit
                {
                    orderId = "12345",
                    orderSource = orderSourceType.ecommerce,
                    echeck = new echeckType
                    {
                        accType = echeckAccountTypeEnum.CorpSavings,
                        accNum = "12345657890",
                        routingNum = "123456789",
                        checkNum = "123455"
                    },
                    billToAddress = new contact
                    {
                        name = "Bob",
                        city = "lowell",
                        state = "MA",
                        email = "litle.com"
                    }
                },
                "<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>123</litleTxnId></echeckPreNoteCreditResponse>",
                "<echeckPreNoteCreditResponse xmlns='http://www.litle.com/schema'><litleTxnId>124</litleTxnId></echeckPreNoteCreditResponse>");
            
            AssertResponsesMatch(mockLitleBatchResponse,
                actualBatchResponse => actualBatchResponse.nextEcheckPreNoteCreditResponse(), 
                echeckPreNoteCreditResponse => echeckPreNoteCreditResponse.litleTxnId,
                123, 124);
        }

        #region Helper Methods

        private batchResponse SetupBatch<TRequest>(Func<batchResponse, Action<XmlReader>> responseReader,
            Func<batchRequest, Action<TRequest>> unit, TRequest request, params string[] responses)
        {
            var sequence = _mockXmlReader.SetupSequence(xmlReader => xmlReader.ReadOuterXml());
            foreach (var result in responses)
            {
                sequence.Returns(result);
            }
            var litleBatchResponse = new batchResponse();
            var mockLitleResponse = new Mock<litleResponse>();
            mockLitleResponse.Setup(litleResponse => litleResponse.nextBatchResponse())
                .Returns(litleBatchResponse);

            SetupLitleXml(mockLitleResponse.Object);
            var mockLitleBatchResponse = litleBatchResponse;
            var readerResult = responseReader(mockLitleBatchResponse);
            readerResult(_mockXmlReader.Object);

            SetupBatchRequest(unit, Enumerable.Repeat(request, responses.Length).ToArray());
            return mockLitleBatchResponse;
        }

        private void SetupBatchRequest<T>(Func<batchRequest, Action<T>> unit, params T[] inputs)
        {
            var batchRequest = new batchRequest(_mockCache.Object);
            batchRequest.setLitleFile(_mockLitleFile.Object);
            batchRequest.setLitleTime(_mockLitleTime.Object);
            var unitResult = unit(batchRequest);
            foreach (var input in inputs)
            {
                unitResult(input);
            }
            Litle.addBatch(batchRequest);
        }

        private void AssertResponsesMatch<TResponse, TProperty>(batchResponse expectedResponse,
            Func<batchResponse, TResponse> nextResponse, Func<TResponse, TProperty> selectTransactionId,
            params TProperty[] transactionIds)
        {
            var actualLitleBatchResponse = GetLitleBatchResponse();
            Assert.AreSame(expectedResponse, actualLitleBatchResponse);
            foreach (var transactionId in transactionIds)
            {
                var response = nextResponse(actualLitleBatchResponse);
                var actual = selectTransactionId(response);
                Assert.AreEqual(transactionId, actual);
            }
            Assert.IsNull(nextResponse(actualLitleBatchResponse));
            VerifyCommunications();
        }

        private batchResponse GetLitleBatchResponse()
        {
            var actualLitleResponse = GetLitleResponse();
            var actualLitleBatchResponse = actualLitleResponse.nextBatchResponse();
            return actualLitleBatchResponse;
        }

        private litleResponse GetLitleResponse()
        {
            var batchFileName = Litle.sendToLitle();
            var actualLitleResponse = Litle.receiveFromLitle(batchFileName);
            return actualLitleResponse;
        }

        private void SetupLitle()
        {
            Litle.setCommunication(_mockCommunications.Object);
            Litle.setLitleFile(_mockLitleFile.Object);
            Litle.setLitleTime(_mockLitleTime.Object);
        }

        private void VerifyCommunications()
        {
            _mockCommunications.Verify(communications =>
                communications.FtpDropOff(It.IsAny<string>(), MockFileName, It.IsAny<Dictionary<string, string>>()));
            _mockCommunications.Verify(communications =>
                communications.FtpPickUp(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), MockFileName));
        }

        private void SetupLitleXml(litleResponse mockedLitleResponse)
        {
            var mockLitleXmlSerializer = new Mock<litleXmlSerializer>();
            mockLitleXmlSerializer.Setup(litleXmlSerializer =>
                litleXmlSerializer.DeserializeObjectFromString(It.IsAny<string>()))
                .Returns(mockedLitleResponse);

            Litle.setLitleXmlSerializer(mockLitleXmlSerializer.Object);
            SetupLitle();
        }

        #endregion Helper Methods
    }
}
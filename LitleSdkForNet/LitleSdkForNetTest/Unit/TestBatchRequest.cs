using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestBatchRequest
    {
        #region Setup

        private batchRequest _batchRequest;

        private const string MockFileName = "TheRainbow.xml",
            MockFilePath = "C:\\Somewhere\\\\Over\\\\" + MockFileName;

        private Mock<litleFile> _mockLitleFile;
        private Mock<litleTime> _mockLitleTime;
        private IDictionary<string, StringBuilder> _memoryStreams;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _memoryStreams = new Dictionary<string, StringBuilder>();
            _mockLitleFile = new Mock<litleFile>(new Dictionary<string, StringBuilder>());
            _mockLitleTime = new Mock<litleTime>();

            _mockLitleFile.Setup(litleFile =>
                    litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object))
                .Returns(MockFilePath);
            _mockLitleFile.Setup(litleFile => litleFile.AppendLineToFile(MockFilePath, It.IsAny<string>()))
                .Returns(MockFilePath);
        }

        [SetUp]
        public void BeforeTestSetup()
        {
            _batchRequest = new batchRequest(_memoryStreams);
            _batchRequest.setLitleFile(_mockLitleFile.Object);
            _batchRequest.setLitleTime(_mockLitleTime.Object);
        }

        #endregion Setup

        [Test]
        public void TestBatchRequestContainsMerchantSdkAttribute()
        {
            _batchRequest = new batchRequest(_memoryStreams, new Dictionary<string, string>
            {
                ["merchantId"] = "01234",
                ["requestDirectory"] = "C:\\MockRequests",
                ["responseDirectory"] = "C:\\MockResponses"
            });

            const string expected = @"
<batchRequest id=""""
merchantSdk=""DotNet;9.3.2""
merchantId=""01234"">
";
            Assert.AreEqual(expected, _batchRequest.generateXmlHeader());
        }

        [Test]
        public void TestInitialization()
        {
            _batchRequest = new batchRequest(_memoryStreams, new Dictionary<string, string>
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

            Assert.AreEqual("C:\\MockRequests\\Requests\\", _batchRequest.getRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", _batchRequest.getResponseDirectory());
            Assert.NotNull(_batchRequest.getLitleTime());
            Assert.NotNull(_batchRequest.getLitleFile());
        }

        [Test]
        public void TestAddAuthorization()
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

            _batchRequest.addAuthorization(authorization);

            Assert.AreEqual(1, _batchRequest.getNumAuthorization());
            Assert.AreEqual(authorization.amount, _batchRequest.getSumOfAuthorization());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, authorization.Serialize()));
        }

        [Test]
        public void TestAddAccountUpdate()
        {
            var accountUpdate = new accountUpdate
            {
                reportGroup = "Planets",
                orderId = "12344",
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            };

            _batchRequest.addAccountUpdate(accountUpdate);

            Assert.AreEqual(1, _batchRequest.getNumAccountUpdates());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, accountUpdate.Serialize()));
        }

        [Test]
        public void TestAuthReversal()
        {
            var authreversal = new authReversal
            {
                litleTxnId = 12345678000,
                amount = 106,
                payPalNotes = "Notes"
            };

            _batchRequest.addAuthReversal(authreversal);

            Assert.AreEqual(1, _batchRequest.getNumAuthReversal());
            Assert.AreEqual(authreversal.amount, _batchRequest.getSumOfAuthReversal());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, authreversal.Serialize()));
        }

        [Test]
        public void TestCapture()
        {
            var capture = new capture
            {
                litleTxnId = 12345678000,
                amount = 106
            };

            _batchRequest.addCapture(capture);

            Assert.AreEqual(1, _batchRequest.getNumCapture());
            Assert.AreEqual(capture.amount, _batchRequest.getSumOfCapture());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, capture.Serialize()));
        }

        [Test]
        public void TestCaptureGivenAuth()
        {
            var capturegivenauth = new captureGivenAuth
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
            };

            _batchRequest.addCaptureGivenAuth(capturegivenauth);

            Assert.AreEqual(1, _batchRequest.getNumCaptureGivenAuth());
            Assert.AreEqual(capturegivenauth.amount, _batchRequest.getSumOfCaptureGivenAuth());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, capturegivenauth.Serialize()));
        }

        [Test]
        public void TestCredit()
        {
            var credit = new credit
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
            };

            _batchRequest.addCredit(credit);

            Assert.AreEqual(1, _batchRequest.getNumCredit());
            Assert.AreEqual(credit.amount, _batchRequest.getSumOfCredit());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, credit.Serialize()));
        }

        [Test]
        public void TestEcheckCredit()
        {
            var echeckcredit = new echeckCredit
            {
                amount = 12,
                litleTxnId = 123456789101112
            };

            _batchRequest.addEcheckCredit(echeckcredit);

            Assert.AreEqual(1, _batchRequest.getNumEcheckCredit());
            Assert.AreEqual(echeckcredit.amount, _batchRequest.getSumOfEcheckCredit());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echeckcredit.Serialize()));
        }

        [Test]
        public void TestEcheckRedeposit()
        {
            var echeckredeposit = new echeckRedeposit {litleTxnId = 123456};

            _batchRequest.addEcheckRedeposit(echeckredeposit);

            Assert.AreEqual(1, _batchRequest.getNumEcheckRedeposit());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echeckredeposit.Serialize()));
        }

        [Test]
        public void TestEcheckSale()
        {
            var echecksale = new echeckSale
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
            };

            _batchRequest.addEcheckSale(echecksale);

            Assert.AreEqual(1, _batchRequest.getNumEcheckSale());
            Assert.AreEqual(echecksale.amount, _batchRequest.getSumOfEcheckSale());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echecksale.Serialize()));
        }

        [Test]
        public void TestEcheckVerification()
        {
            var echeckverification = new echeckVerification
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
            };

            _batchRequest.addEcheckVerification(echeckverification);

            Assert.AreEqual(1, _batchRequest.getNumEcheckVerification());
            Assert.AreEqual(echeckverification.amount, _batchRequest.getSumOfEcheckVerification());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echeckverification.Serialize()));
        }

        [Test]
        public void TestForceCapture()
        {
            var forcecapture = new forceCapture
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
            };

            _batchRequest.addForceCapture(forcecapture);

            Assert.AreEqual(1, _batchRequest.getNumForceCapture());
            Assert.AreEqual(forcecapture.amount, _batchRequest.getSumOfForceCapture());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, forcecapture.Serialize()));
        }

        [Test]
        public void TestSale()
        {
            var sale = new sale
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
            };

            _batchRequest.addSale(sale);

            Assert.AreEqual(1, _batchRequest.getNumSale());
            Assert.AreEqual(sale.amount, _batchRequest.getSumOfSale());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, sale.Serialize()));
        }

        [Test]
        public void TestToken()
        {
            var token = new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801"
            };

            _batchRequest.addRegisterTokenRequest(token);

            Assert.AreEqual(1, _batchRequest.getNumRegisterTokenRequest());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, token.Serialize()));
        }

        [Test]
        public void TestUpdateCardValidationNumOnToken()
        {
            var updateCardValidationNumOnToken = new updateCardValidationNumOnToken
            {
                orderId = "12344",
                litleToken = "123"
            };

            _batchRequest.addUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);

            Assert.AreEqual(1, _batchRequest.getNumUpdateCardValidationNumOnToken());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile =>
                litleFile.AppendLineToFile(MockFilePath, updateCardValidationNumOnToken.Serialize()));
        }

        [Test]
        public void TestUpdateSubscription()
        {
            var update = new updateSubscription
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
            };

            _batchRequest.addUpdateSubscription(update);

            Assert.AreEqual(1, _batchRequest.getNumUpdateSubscriptions());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, update.Serialize()));
        }

        [Test]
        public void TestCreatePlan()
        {
            var createPlan = new createPlan();

            _batchRequest.addCreatePlan(createPlan);

            Assert.AreEqual(1, _batchRequest.getNumCreatePlans());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, createPlan.Serialize()));
        }

        [Test]
        public void TestUpdatePlan()
        {
            var updatePlan = new updatePlan();

            _batchRequest.addUpdatePlan(updatePlan);

            Assert.AreEqual(1, _batchRequest.getNumUpdatePlans());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, updatePlan.Serialize()));
        }

        [Test]
        public void TestActivate()
        {
            var activate = new activate
            {
                amount = 500,
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            };

            _batchRequest.addActivate(activate);

            Assert.AreEqual(1, _batchRequest.getNumActivates());
            Assert.AreEqual(500, _batchRequest.getActivateAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, activate.Serialize()));
        }

        [Test]
        public void TestDeactivate()
        {
            var deactivate = new deactivate
            {
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            };

            _batchRequest.addDeactivate(deactivate);

            Assert.AreEqual(1, _batchRequest.getNumDeactivates());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, deactivate.Serialize()));
        }

        [Test]
        public void TestLoad()
        {
            var load = new load
            {
                amount = 600,
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            };

            _batchRequest.addLoad(load);

            Assert.AreEqual(1, _batchRequest.getNumLoads());
            Assert.AreEqual(600, _batchRequest.getLoadAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, load.Serialize()));
        }

        [Test]
        public void TestUnload()
        {
            var unload = new unload
            {
                amount = 700,
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            };

            _batchRequest.addUnload(unload);

            Assert.AreEqual(1, _batchRequest.getNumUnloads());
            Assert.AreEqual(700, _batchRequest.getUnloadAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, unload.Serialize()));
        }

        [Test]
        public void TestBalanceInquiry()
        {
            var balanceInquiry = new balanceInquiry
            {
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            };

            _batchRequest.addBalanceInquiry(balanceInquiry);

            Assert.AreEqual(1, _batchRequest.getNumBalanceInquiries());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, balanceInquiry.Serialize()));
        }

        [Test]
        public void TestCancelSubscription()
        {
            var cancel = new cancelSubscription {subscriptionId = 12345};

            _batchRequest.addCancelSubscription(cancel);

            Assert.AreEqual(1, _batchRequest.getNumCancelSubscriptions());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, cancel.Serialize()));
        }

        [Test]
        public void TestAddEcheckPreNoteSale()
        {
            var echeckPreNoteSale = new echeckPreNoteSale
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
            };

            _batchRequest.addEcheckPreNoteSale(echeckPreNoteSale);

            Assert.AreEqual(1, _batchRequest.getNumEcheckPreNoteSale());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echeckPreNoteSale.Serialize()));
        }

        [Test]
        public void TestAddEcheckPreNoteCredit()
        {
            var echeckPreNoteCredit = new echeckPreNoteCredit
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
            };

            _batchRequest.addEcheckPreNoteCredit(echeckPreNoteCredit);

            Assert.AreEqual(1, _batchRequest.getNumEcheckPreNoteCredit());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, echeckPreNoteCredit.Serialize()));
        }

        [Test]
        public void TestAddSubmerchantCredit()
        {
            var submerchantCredit = new submerchantCredit
            {
                fundingSubmerchantId = "123456",
                submerchantName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                }
            };

            _batchRequest.addSubmerchantCredit(submerchantCredit);

            Assert.AreEqual(1, _batchRequest.getNumSubmerchantCredit());
            Assert.AreEqual(106L, _batchRequest.getSubmerchantCreditAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, submerchantCredit.Serialize()));
        }

        [Test]
        public void TestAddPayFacCredit()
        {
            var payFacCredit = new payFacCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addPayFacCredit(payFacCredit);

            Assert.AreEqual(1, _batchRequest.getNumPayFacCredit());
            Assert.AreEqual(107L, _batchRequest.getPayFacCreditAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, payFacCredit.Serialize()));
        }

        [Test]
        public void TestAddReserveCredit()
        {
            var reserveCredit = new reserveCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addReserveCredit(reserveCredit);

            Assert.AreEqual(1, _batchRequest.getNumReserveCredit());
            Assert.AreEqual(107L, _batchRequest.getReserveCreditAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, reserveCredit.Serialize()));
        }

        [Test]
        public void TestAddVendorCredit()
        {
            var vendorCredit = new vendorCredit
            {
                fundingSubmerchantId = "123456",
                vendorName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                }
            };

            _batchRequest.addVendorCredit(vendorCredit);

            Assert.AreEqual(1, _batchRequest.getNumVendorCredit());
            Assert.AreEqual(106L, _batchRequest.getVendorCreditAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, vendorCredit.Serialize()));
        }

        [Test]
        public void TestAddPhysicalCheckCredit()
        {
            var physicalCheckCredit = new physicalCheckCredit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addPhysicalCheckCredit(physicalCheckCredit);

            Assert.AreEqual(1, _batchRequest.getNumPhysicalCheckCredit());
            Assert.AreEqual(107L, _batchRequest.getPhysicalCheckCreditAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, physicalCheckCredit.Serialize()));
        }

        [Test]
        public void TestAddSubmerchantDebit()
        {
            var submerchantDebit = new submerchantDebit
            {
                fundingSubmerchantId = "123456",
                submerchantName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                }
            };

            _batchRequest.addSubmerchantDebit(submerchantDebit);

            Assert.AreEqual(1, _batchRequest.getNumSubmerchantDebit());
            Assert.AreEqual(106L, _batchRequest.getSubmerchantDebitAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, submerchantDebit.Serialize()));
        }

        [Test]
        public void TestAddPayFacDebit()
        {
            var payFacDebit = new payFacDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addPayFacDebit(payFacDebit);

            Assert.AreEqual(1, _batchRequest.getNumPayFacDebit());
            Assert.AreEqual(107L, _batchRequest.getPayFacDebitAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, payFacDebit.Serialize()));
        }

        [Test]
        public void TestAddReserveDebit()
        {
            var reserveDebit = new reserveDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addReserveDebit(reserveDebit);

            Assert.AreEqual(1, _batchRequest.getNumReserveDebit());
            Assert.AreEqual(107L, _batchRequest.getReserveDebitAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, reserveDebit.Serialize()));
        }

        [Test]
        public void TestAddVendorDebit()
        {
            var vendorDebit = new vendorDebit
            {
                fundingSubmerchantId = "123456",
                vendorName = "merchant",
                fundsTransferId = "123467",
                amount = 106L,
                accountInfo = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                }
            };

            _batchRequest.addVendorDebit(vendorDebit);

            Assert.AreEqual(1, _batchRequest.getNumVendorDebit());
            Assert.AreEqual(106L, _batchRequest.getVendorDebitAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, vendorDebit.Serialize()));
        }

        [Test]
        public void TestAddPhysicalCheckDebit()
        {
            var physicalCheckDebit = new physicalCheckDebit
            {
                fundingSubmerchantId = "123456",
                fundsTransferId = "123467",
                amount = 107L
            };

            _batchRequest.addPhysicalCheckDebit(physicalCheckDebit);

            Assert.AreEqual(1, _batchRequest.getNumPhysicalCheckDebit());
            Assert.AreEqual(107L, _batchRequest.getPhysicalCheckDebitAmount());

            _mockLitleFile.Verify(litleFile =>
                litleFile.createRandomFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    _mockLitleTime.Object));
            _mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(MockFilePath, physicalCheckDebit.Serialize()));
        }
    }
}
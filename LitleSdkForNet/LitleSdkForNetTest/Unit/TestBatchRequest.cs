using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;
using Moq.Language.Flow;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestBatchRequest
    {
        private BatchRequest batchRequest;
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
        public void beforeTestSetup()
        {
            batchRequest = new BatchRequest();
            batchRequest.SetLitleFile(mockLitleFile.Object);
            batchRequest.SetLitleTime(mockLitleTime.Object);
        }

        [Test]
        public void testBatchRequestContainsMerchantSdkAttribute()
        {
            Dictionary<String, String> mockConfig = new Dictionary<string, string>();

            mockConfig["merchantId"] = "01234";
            mockConfig["requestDirectory"] = "C:\\MockRequests";
            mockConfig["responseDirectory"] = "C:\\MockResponses";

            batchRequest = new BatchRequest(mockConfig);

            String actual = batchRequest.GenerateXmlHeader();
            String expected = @"
<batchRequest id=""""
merchantSdk=""DotNet;9.3.2""
merchantId=""01234"">
";
            Assert.AreEqual(expected, actual);
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

            batchRequest = new BatchRequest(mockConfig);

            Assert.AreEqual("C:\\MockRequests\\Requests\\", batchRequest.GetRequestDirectory());
            Assert.AreEqual("C:\\MockResponses\\Responses\\", batchRequest.GetResponseDirectory());

            Assert.NotNull(batchRequest.GetLitleTime());
            Assert.NotNull(batchRequest.GetLitleFile());
        }

        [Test]
        public void testAddAuthorization()
        {
            authorization authorization = new authorization();
            authorization.reportGroup = "Planets";
            authorization.orderId = "12344";
            authorization.amount = 106;
            authorization.orderSource = orderSourceType.ecommerce;
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000002";
            card.expDate = "1210";
            authorization.card = card;

            batchRequest.AddAuthorization(authorization);

            Assert.AreEqual(1, batchRequest.GetNumAuthorization());
            Assert.AreEqual(authorization.amount, batchRequest.GetSumOfAuthorization());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, authorization.Serialize()));
        }

        [Test]
        public void testAddAccountUpdate()
        {
            accountUpdate accountUpdate = new accountUpdate();
            accountUpdate.reportGroup = "Planets";
            accountUpdate.orderId = "12344";
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000002";
            card.expDate = "1210";
            accountUpdate.card = card;

            batchRequest.AddAccountUpdate(accountUpdate);

            Assert.AreEqual(1, batchRequest.GetNumAccountUpdates());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, accountUpdate.Serialize()));
        }

        [Test]
        public void testAuthReversal()
        {
            authReversal authreversal = new authReversal();
            authreversal.litleTxnId = 12345678000;
            authreversal.amount = 106;
            authreversal.payPalNotes = "Notes";

            batchRequest.AddAuthReversal(authreversal);

            Assert.AreEqual(1, batchRequest.GetNumAuthReversal());
            Assert.AreEqual(authreversal.amount, batchRequest.GetSumOfAuthReversal());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, authreversal.Serialize()));
        }

        [Test]
        public void testCapture()
        {
            capture capture = new capture();
            capture.litleTxnId = 12345678000;
            capture.amount = 106;

            batchRequest.AddCapture(capture);

            Assert.AreEqual(1, batchRequest.GetNumCapture());
            Assert.AreEqual(capture.amount, batchRequest.GetSumOfCapture());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, capture.Serialize()));
        }

        [Test]
        public void testCaptureGivenAuth()
        {
            captureGivenAuth capturegivenauth = new captureGivenAuth();
            capturegivenauth.orderId = "12344";
            capturegivenauth.amount = 106;
            authInformation authinfo = new authInformation();
            authinfo.authDate = new DateTime(2002, 10, 9);
            authinfo.authCode = "543216";
            authinfo.authAmount = 12345;
            capturegivenauth.authInformation = authinfo;
            capturegivenauth.orderSource = orderSourceType.ecommerce;
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000001";
            card.expDate = "1210";
            capturegivenauth.card = card;

            batchRequest.AddCaptureGivenAuth(capturegivenauth);

            Assert.AreEqual(1, batchRequest.GetNumCaptureGivenAuth());
            Assert.AreEqual(capturegivenauth.amount, batchRequest.GetSumOfCaptureGivenAuth());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, capturegivenauth.Serialize()));
        }

        [Test]
        public void testCredit()
        {
            credit credit = new credit();
            credit.orderId = "12344";
            credit.amount = 106;
            credit.orderSource = orderSourceType.ecommerce;
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000001";
            card.expDate = "1210";
            credit.card = card;

            batchRequest.AddCredit(credit);

            Assert.AreEqual(1, batchRequest.GetNumCredit());
            Assert.AreEqual(credit.amount, batchRequest.GetSumOfCredit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, credit.Serialize()));
        }

        [Test]
        public void testEcheckCredit()
        {
            echeckCredit echeckcredit = new echeckCredit();
            echeckcredit.amount = 12;
            echeckcredit.litleTxnId = 123456789101112;

            batchRequest.AddEcheckCredit(echeckcredit);

            Assert.AreEqual(1, batchRequest.GetNumEcheckCredit());
            Assert.AreEqual(echeckcredit.amount, batchRequest.GetSumOfEcheckCredit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckcredit.Serialize()));
        }

        [Test]
        public void testEcheckRedeposit()
        {
            echeckRedeposit echeckredeposit = new echeckRedeposit();
            echeckredeposit.litleTxnId = 123456;

            batchRequest.AddEcheckRedeposit(echeckredeposit);

            Assert.AreEqual(1, batchRequest.GetNumEcheckRedeposit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckredeposit.Serialize()));
        }

        [Test]
        public void testEcheckSale()
        {
            echeckSale echecksale = new echeckSale();
            echecksale.orderId = "12345";
            echecksale.amount = 123456;
            echecksale.orderSource = orderSourceType.ecommerce;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            echecksale.echeck = echeck;
            contact contact = new contact();
            contact.name = "Bob";
            contact.city = "lowell";
            contact.state = "MA";
            contact.email = "litle.com";
            echecksale.billToAddress = contact;

            batchRequest.AddEcheckSale(echecksale);

            Assert.AreEqual(1, batchRequest.GetNumEcheckSale());
            Assert.AreEqual(echecksale.amount, batchRequest.GetSumOfEcheckSale());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echecksale.Serialize()));
        }

        [Test]
        public void testEcheckVerification()
        {
            echeckVerification echeckverification = new echeckVerification();
            echeckverification.orderId = "12345";
            echeckverification.amount = 123456;
            echeckverification.orderSource = orderSourceType.ecommerce;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            echeckverification.echeck = echeck;
            contact contact = new contact();
            contact.name = "Bob";
            contact.city = "lowell";
            contact.state = "MA";
            contact.email = "litle.com";
            echeckverification.billToAddress = contact;

            batchRequest.AddEcheckVerification(echeckverification);

            Assert.AreEqual(1, batchRequest.GetNumEcheckVerification());
            Assert.AreEqual(echeckverification.amount, batchRequest.GetSumOfEcheckVerification());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckverification.Serialize()));
        }

        [Test]
        public void testForceCapture()
        {
            forceCapture forcecapture = new forceCapture();
            forcecapture.orderId = "12344";
            forcecapture.amount = 106;
            forcecapture.orderSource = orderSourceType.ecommerce;
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000001";
            card.expDate = "1210";
            forcecapture.card = card;

            batchRequest.AddForceCapture(forcecapture);

            Assert.AreEqual(1, batchRequest.GetNumForceCapture());
            Assert.AreEqual(forcecapture.amount, batchRequest.GetSumOfForceCapture());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, forcecapture.Serialize()));
        }

        [Test]
        public void testSale()
        {
            sale sale = new sale();
            sale.orderId = "12344";
            sale.amount = 106;
            sale.orderSource = orderSourceType.ecommerce;
            cardType card = new cardType();
            card.type = methodOfPaymentTypeEnum.VI;
            card.number = "4100000000000002";
            card.expDate = "1210";
            sale.card = card;

            batchRequest.AddSale(sale);

            Assert.AreEqual(1, batchRequest.GetNumSale());
            Assert.AreEqual(sale.amount, batchRequest.GetSumOfSale());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, sale.Serialize()));
        }

        [Test]
        public void testToken()
        {
            registerTokenRequestType token = new registerTokenRequestType();
            token.orderId = "12344";
            token.accountNumber = "1233456789103801";

            batchRequest.AddRegisterTokenRequest(token);

            Assert.AreEqual(1, batchRequest.GetNumRegisterTokenRequest());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, token.Serialize()));
        }

        [Test]
        public void testUpdateCardValidationNumOnToken()
        {
            updateCardValidationNumOnToken updateCardValidationNumOnToken = new updateCardValidationNumOnToken();
            updateCardValidationNumOnToken.orderId = "12344";
            updateCardValidationNumOnToken.litleToken = "123";

            batchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);

            Assert.AreEqual(1, batchRequest.GetNumUpdateCardValidationNumOnToken());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, updateCardValidationNumOnToken.Serialize()));
        }

        [Test]
        public void testUpdateSubscription()
        {
            updateSubscription update = new updateSubscription();
            update.billingDate = new DateTime(2002, 10, 9);
            contact billToAddress = new contact();
            billToAddress.name = "Greg Dake";
            billToAddress.city = "Lowell";
            billToAddress.state = "MA";
            billToAddress.email = "sdksupport@litle.com";
            update.billToAddress = billToAddress;
            cardType card = new cardType();
            card.number = "4100000000000001";
            card.expDate = "1215";
            card.type = methodOfPaymentTypeEnum.VI;
            update.card = card;
            update.planCode = "abcdefg";
            update.subscriptionId = 12345;

            batchRequest.AddUpdateSubscription(update);

            Assert.AreEqual(1, batchRequest.GetNumUpdateSubscriptions());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, update.Serialize()));
        }

        [Test]
        public void testCreatePlan()
        {
            createPlan createPlan = new createPlan();

            batchRequest.AddCreatePlan(createPlan);

            Assert.AreEqual(1, batchRequest.GetNumCreatePlans());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, createPlan.Serialize()));
        }

        [Test]
        public void testUpdatePlan()
        {
            updatePlan updatePlan = new updatePlan();

            batchRequest.AddUpdatePlan(updatePlan);

            Assert.AreEqual(1, batchRequest.GetNumUpdatePlans());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, updatePlan.Serialize()));
        }

        [Test]
        public void testActivate()
        {
            activate activate = new activate();
            activate.amount = 500;
            activate.orderSource = orderSourceType.ecommerce;
            activate.card = new cardType();

            batchRequest.AddActivate(activate);

            Assert.AreEqual(1, batchRequest.GetNumActivates());
            Assert.AreEqual(500, batchRequest.GetActivateAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, activate.Serialize()));
        }

        [Test]
        public void testDeactivate()
        {
            deactivate deactivate = new deactivate();
            deactivate.orderSource = orderSourceType.ecommerce;
            deactivate.card = new cardType();

            batchRequest.AddDeactivate(deactivate);

            Assert.AreEqual(1, batchRequest.GetNumDeactivates());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, deactivate.Serialize()));
        }

        [Test]
        public void testLoad()
        {
            load load = new load();
            load.amount = 600;
            load.orderSource = orderSourceType.ecommerce;
            load.card = new cardType();

            batchRequest.AddLoad(load);

            Assert.AreEqual(1, batchRequest.GetNumLoads());
            Assert.AreEqual(600, batchRequest.GetLoadAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, load.Serialize()));
        }

        [Test]
        public void testUnload()
        {
            unload unload = new unload();
            unload.amount = 700;
            unload.orderSource = orderSourceType.ecommerce;
            unload.card = new cardType();

            batchRequest.AddUnload(unload);

            Assert.AreEqual(1, batchRequest.GetNumUnloads());
            Assert.AreEqual(700, batchRequest.GetUnloadAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, unload.Serialize()));
        }

        [Test]
        public void testBalanceInquiry()
        {
            balanceInquiry balanceInquiry = new balanceInquiry();
            balanceInquiry.orderSource = orderSourceType.ecommerce;
            balanceInquiry.card = new cardType();

            batchRequest.AddBalanceInquiry(balanceInquiry);

            Assert.AreEqual(1, batchRequest.GetNumBalanceInquiries());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, balanceInquiry.Serialize()));
        }

        [Test]
        public void testCancelSubscription()
        {
            cancelSubscription cancel = new cancelSubscription();
            cancel.subscriptionId = 12345;

            batchRequest.AddCancelSubscription(cancel);

            Assert.AreEqual(1, batchRequest.GetNumCancelSubscriptions());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, cancel.Serialize()));
        }

        [Test]
        public void testAddEcheckPreNoteSale()
        {
            EcheckPreNoteSale echeckPreNoteSale = new EcheckPreNoteSale();
            echeckPreNoteSale.OrderId = "12345";
            echeckPreNoteSale.OrderSource = orderSourceType.ecommerce;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            echeckPreNoteSale.Echeck = echeck;
            contact contact = new contact();
            contact.name = "Bob";
            contact.city = "lowell";
            contact.state = "MA";
            contact.email = "litle.com";
            echeckPreNoteSale.BillToAddress = contact;

            batchRequest.AddEcheckPreNoteSale(echeckPreNoteSale);

            Assert.AreEqual(1, batchRequest.GetNumEcheckPreNoteSale());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckPreNoteSale.Serialize()));
        }

        [Test]
        public void testAddEcheckPreNoteCredit()
        {
            EcheckPreNoteCredit echeckPreNoteCredit = new EcheckPreNoteCredit();
            echeckPreNoteCredit.OrderId = "12345";
            echeckPreNoteCredit.OrderSource = orderSourceType.ecommerce;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            echeckPreNoteCredit.Echeck = echeck;
            contact contact = new contact();
            contact.name = "Bob";
            contact.city = "lowell";
            contact.state = "MA";
            contact.email = "litle.com";
            echeckPreNoteCredit.BillToAddress = contact;

            batchRequest.AddEcheckPreNoteCredit(echeckPreNoteCredit);

            Assert.AreEqual(1, batchRequest.GetNumEcheckPreNoteCredit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckPreNoteCredit.Serialize()));
        }

        [Test]
        public void testAddSubmerchantCredit()
        {
            SubmerchantCredit submerchantCredit = new SubmerchantCredit();
            submerchantCredit.FundingSubmerchantId = "123456";
            submerchantCredit.SubmerchantName = "merchant";
            submerchantCredit.FundsTransferId = "123467";
            submerchantCredit.Amount = 106L;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            submerchantCredit.AccountInfo = echeck;

            batchRequest.AddSubmerchantCredit(submerchantCredit);

            Assert.AreEqual(1, batchRequest.GetNumSubmerchantCredit());
            Assert.AreEqual(106L, batchRequest.GetSubmerchantCreditAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, submerchantCredit.Serialize()));
        }

        [Test]
        public void testAddPayFacCredit()
        {
            PayFacCredit payFacCredit = new PayFacCredit();
            payFacCredit.FundingSubmerchantId = "123456";
            payFacCredit.FundsTransferId = "123467";
            payFacCredit.Amount = 107L;

            batchRequest.AddPayFacCredit(payFacCredit);

            Assert.AreEqual(1, batchRequest.GetNumPayFacCredit());
            Assert.AreEqual(107L, batchRequest.GetPayFacCreditAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, payFacCredit.Serialize()));
        }

        [Test]
        public void testAddReserveCredit()
        {
            ReserveCredit reserveCredit = new ReserveCredit();
            reserveCredit.FundingSubmerchantId = "123456";
            reserveCredit.FundsTransferId = "123467";
            reserveCredit.Amount = 107L;

            batchRequest.AddReserveCredit(reserveCredit);

            Assert.AreEqual(1, batchRequest.GetNumReserveCredit());
            Assert.AreEqual(107L, batchRequest.GetReserveCreditAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, reserveCredit.Serialize()));
        }

        [Test]
        public void testAddVendorCredit()
        {
            VendorCredit vendorCredit = new VendorCredit();
            vendorCredit.FundingSubmerchantId = "123456";
            vendorCredit.VendorName = "merchant";
            vendorCredit.FundsTransferId = "123467";
            vendorCredit.Amount = 106L;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            vendorCredit.AccountInfo = echeck;

            batchRequest.AddVendorCredit(vendorCredit);

            Assert.AreEqual(1, batchRequest.GetNumVendorCredit());
            Assert.AreEqual(106L, batchRequest.GetVendorCreditAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, vendorCredit.Serialize()));
        }

        [Test]
        public void testAddPhysicalCheckCredit()
        {
            PhysicalCheckCredit physicalCheckCredit = new PhysicalCheckCredit();
            physicalCheckCredit.FundingSubmerchantId = "123456";
            physicalCheckCredit.FundsTransferId = "123467";
            physicalCheckCredit.Amount = 107L;

            batchRequest.AddPhysicalCheckCredit(physicalCheckCredit);

            Assert.AreEqual(1, batchRequest.GetNumPhysicalCheckCredit());
            Assert.AreEqual(107L, batchRequest.GetPhysicalCheckCreditAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, physicalCheckCredit.Serialize()));
        }

        [Test]
        public void testAddSubmerchantDebit()
        {
            SubmerchantDebit submerchantDebit = new SubmerchantDebit();
            submerchantDebit.FundingSubmerchantId = "123456";
            submerchantDebit.SubmerchantName = "merchant";
            submerchantDebit.FundsTransferId = "123467";
            submerchantDebit.Amount = 106L;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            submerchantDebit.AccountInfo = echeck;

            batchRequest.AddSubmerchantDebit(submerchantDebit);

            Assert.AreEqual(1, batchRequest.GetNumSubmerchantDebit());
            Assert.AreEqual(106L, batchRequest.GetSubmerchantDebitAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, submerchantDebit.Serialize()));
        }

        [Test]
        public void testAddPayFacDebit()
        {
            PayFacDebit payFacDebit = new PayFacDebit();
            payFacDebit.FundingSubmerchantId = "123456";
            payFacDebit.FundsTransferId = "123467";
            payFacDebit.Amount = 107L;

            batchRequest.AddPayFacDebit(payFacDebit);

            Assert.AreEqual(1, batchRequest.GetNumPayFacDebit());
            Assert.AreEqual(107L, batchRequest.GetPayFacDebitAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, payFacDebit.Serialize()));
        }

        [Test]
        public void testAddReserveDebit()
        {
            ReserveDebit reserveDebit = new ReserveDebit();
            reserveDebit.FundingSubmerchantId = "123456";
            reserveDebit.FundsTransferId = "123467";
            reserveDebit.Amount = 107L;

            batchRequest.AddReserveDebit(reserveDebit);

            Assert.AreEqual(1, batchRequest.GetNumReserveDebit());
            Assert.AreEqual(107L, batchRequest.GetReserveDebitAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, reserveDebit.Serialize()));
        }

        [Test]
        public void testAddVendorDebit()
        {
            VendorDebit vendorDebit = new VendorDebit();
            vendorDebit.FundingSubmerchantId = "123456";
            vendorDebit.VendorName = "merchant";
            vendorDebit.FundsTransferId = "123467";
            vendorDebit.Amount = 106L;
            echeckType echeck = new echeckType();
            echeck.accType = echeckAccountTypeEnum.Checking;
            echeck.accNum = "12345657890";
            echeck.routingNum = "123456789";
            echeck.checkNum = "123455";
            vendorDebit.AccountInfo = echeck;

            batchRequest.AddVendorDebit(vendorDebit);

            Assert.AreEqual(1, batchRequest.GetNumVendorDebit());
            Assert.AreEqual(106L, batchRequest.GetVendorDebitAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, vendorDebit.Serialize()));
        }

        [Test]
        public void testAddPhysicalCheckDebit()
        {
            PhysicalCheckDebit physicalCheckDebit = new PhysicalCheckDebit();
            physicalCheckDebit.FundingSubmerchantId = "123456";
            physicalCheckDebit.FundsTransferId = "123467";
            physicalCheckDebit.Amount = 107L;

            batchRequest.AddPhysicalCheckDebit(physicalCheckDebit);

            Assert.AreEqual(1, batchRequest.GetNumPhysicalCheckDebit());
            Assert.AreEqual(107L, batchRequest.GetPhysicalCheckDebitAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, physicalCheckDebit.Serialize()));
        }
    }
}

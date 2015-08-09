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
using Capture = Litle.Sdk.Requests.Capture;


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

            batchRequest.AddAuthorization(authorization);

            Assert.AreEqual(1, batchRequest.GetNumAuthorization());
            Assert.AreEqual(authorization.Amount, batchRequest.GetSumOfAuthorization());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, authorization.Serialize()));
        }

        [Test]
        public void testAddAccountUpdate()
        {
            AccountUpdate accountUpdate = new AccountUpdate();
            accountUpdate.ReportGroup = "Planets";
            accountUpdate.OrderId = "12344";
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            accountUpdate.Card = card;

            batchRequest.AddAccountUpdate(accountUpdate);

            Assert.AreEqual(1, batchRequest.GetNumAccountUpdates());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, accountUpdate.Serialize()));
        }

        [Test]
        public void testAuthReversal()
        {
            AuthReversal authreversal = new AuthReversal();
            authreversal.LitleTxnId = 12345678000;
            authreversal.Amount = 106;
            authreversal.PayPalNotes = "Notes";

            batchRequest.AddAuthReversal(authreversal);

            Assert.AreEqual(1, batchRequest.GetNumAuthReversal());
            Assert.AreEqual(authreversal.Amount, batchRequest.GetSumOfAuthReversal());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, authreversal.Serialize()));
        }

        [Test]
        public void testCapture()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 12345678000;
            capture.Amount = 106;

            batchRequest.AddCapture(capture);

            Assert.AreEqual(1, batchRequest.GetNumCapture());
            Assert.AreEqual(capture.Amount, batchRequest.GetSumOfCapture());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, capture.Serialize()));
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

            batchRequest.AddCaptureGivenAuth(capturegivenauth);

            Assert.AreEqual(1, batchRequest.GetNumCaptureGivenAuth());
            Assert.AreEqual(capturegivenauth.Amount, batchRequest.GetSumOfCaptureGivenAuth());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, capturegivenauth.Serialize()));
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

            batchRequest.AddCredit(credit);

            Assert.AreEqual(1, batchRequest.GetNumCredit());
            Assert.AreEqual(credit.Amount, batchRequest.GetSumOfCredit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, credit.Serialize()));
        }

        [Test]
        public void testEcheckCredit()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12;
            echeckcredit.LitleTxnId = 123456789101112;

            batchRequest.AddEcheckCredit(echeckcredit);

            Assert.AreEqual(1, batchRequest.GetNumEcheckCredit());
            Assert.AreEqual(echeckcredit.Amount, batchRequest.GetSumOfEcheckCredit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckcredit.Serialize()));
        }

        [Test]
        public void testEcheckRedeposit()
        {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.LitleTxnId = 123456;

            batchRequest.AddEcheckRedeposit(echeckredeposit);

            Assert.AreEqual(1, batchRequest.GetNumEcheckRedeposit());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckredeposit.Serialize()));
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

            batchRequest.AddEcheckSale(echecksale);

            Assert.AreEqual(1, batchRequest.GetNumEcheckSale());
            Assert.AreEqual(echecksale.Amount, batchRequest.GetSumOfEcheckSale());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echecksale.Serialize()));
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

            batchRequest.AddEcheckVerification(echeckverification);

            Assert.AreEqual(1, batchRequest.GetNumEcheckVerification());
            Assert.AreEqual(echeckverification.Amount, batchRequest.GetSumOfEcheckVerification());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, echeckverification.Serialize()));
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

            batchRequest.AddForceCapture(forcecapture);

            Assert.AreEqual(1, batchRequest.GetNumForceCapture());
            Assert.AreEqual(forcecapture.Amount, batchRequest.GetSumOfForceCapture());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, forcecapture.Serialize()));
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

            batchRequest.AddSale(sale);

            Assert.AreEqual(1, batchRequest.GetNumSale());
            Assert.AreEqual(sale.Amount, batchRequest.GetSumOfSale());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, sale.Serialize()));
        }

        [Test]
        public void testToken()
        {
            RegisterTokenRequestType token = new RegisterTokenRequestType();
            token.OrderId = "12344";
            token.AccountNumber = "1233456789103801";

            batchRequest.AddRegisterTokenRequest(token);

            Assert.AreEqual(1, batchRequest.GetNumRegisterTokenRequest());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, token.Serialize()));
        }

        [Test]
        public void testUpdateCardValidationNumOnToken()
        {
            UpdateCardValidationNumOnToken updateCardValidationNumOnToken = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken.OrderId = "12344";
            updateCardValidationNumOnToken.LitleToken = "123";

            batchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);

            Assert.AreEqual(1, batchRequest.GetNumUpdateCardValidationNumOnToken());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, updateCardValidationNumOnToken.Serialize()));
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

            batchRequest.AddUpdateSubscription(update);

            Assert.AreEqual(1, batchRequest.GetNumUpdateSubscriptions());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, update.Serialize()));
        }

        [Test]
        public void testCreatePlan()
        {
            CreatePlan createPlan = new CreatePlan();

            batchRequest.AddCreatePlan(createPlan);

            Assert.AreEqual(1, batchRequest.GetNumCreatePlans());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, createPlan.Serialize()));
        }

        [Test]
        public void testUpdatePlan()
        {
            UpdatePlan updatePlan = new UpdatePlan();

            batchRequest.AddUpdatePlan(updatePlan);

            Assert.AreEqual(1, batchRequest.GetNumUpdatePlans());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, updatePlan.Serialize()));
        }

        [Test]
        public void testActivate()
        {
            Activate activate = new Activate();
            activate.Amount = 500;
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.Card = new CardType();

            batchRequest.AddActivate(activate);

            Assert.AreEqual(1, batchRequest.GetNumActivates());
            Assert.AreEqual(500, batchRequest.GetActivateAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, activate.Serialize()));
        }

        [Test]
        public void testDeactivate()
        {
            Deactivate deactivate = new Deactivate();
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();

            batchRequest.AddDeactivate(deactivate);

            Assert.AreEqual(1, batchRequest.GetNumDeactivates());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, deactivate.Serialize()));
        }

        [Test]
        public void testLoad()
        {
            Load load = new Load();
            load.Amount = 600;
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();

            batchRequest.AddLoad(load);

            Assert.AreEqual(1, batchRequest.GetNumLoads());
            Assert.AreEqual(600, batchRequest.GetLoadAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, load.Serialize()));
        }

        [Test]
        public void testUnload()
        {
            Unload unload = new Unload();
            unload.Amount = 700;
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();

            batchRequest.AddUnload(unload);

            Assert.AreEqual(1, batchRequest.GetNumUnloads());
            Assert.AreEqual(700, batchRequest.GetUnloadAmount());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, unload.Serialize()));
        }

        [Test]
        public void testBalanceInquiry()
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();

            batchRequest.AddBalanceInquiry(balanceInquiry);

            Assert.AreEqual(1, batchRequest.GetNumBalanceInquiries());

            mockLitleFile.Verify(litleFile => litleFile.CreateRandomFile(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<String>(), mockLitleTime.Object));
            mockLitleFile.Verify(litleFile => litleFile.AppendLineToFile(mockFilePath, balanceInquiry.Serialize()));
        }

        [Test]
        public void testCancelSubscription()
        {
            CancelSubscription cancel = new CancelSubscription();
            cancel.SubscriptionId = 12345;

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
            echeckPreNoteCredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
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
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
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
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
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
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
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
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
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

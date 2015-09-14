using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;
using Capture = Litle.Sdk.Requests.Capture;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestLitleOnline
    {
        
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestAuth()
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
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleOnlineRequest.*<authorization.*<card>.*<number>4100000000000002</number>.*</card>.*</authorization>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            AuthorizationResponse authorize = litle.Authorize(authorization);
            Assert.AreEqual(123, authorize.LitleTxnId);
        }

        [Test]
        public void testAuthReversal()
        {
            AuthReversal authreversal = new AuthReversal();
            authreversal.LitleTxnId = 12345678000;
            authreversal.Amount = 106;
            authreversal.PayPalNotes = "Notes";
            

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<authReversal.*?<litleTxnId>12345678000</litleTxnId>.*?</authReversal>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authReversalResponse><litleTxnId>123</litleTxnId></authReversalResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            AuthReversalResponse authreversalresponse = litle.AuthReversal(authreversal);
            Assert.AreEqual(123, authreversalresponse.LitleTxnId);
        }

        [Test]
        public void testCapture()
        {
            Capture caputure = new Capture();
            caputure.LitleTxnId = 123456000;
            caputure.Amount = 106;
            caputure.PayPalNotes = "Notes";


            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<capture.*?<litleTxnId>123456000</litleTxnId>.*?</capture>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureResponse><litleTxnId>123</litleTxnId></captureResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            CaptureResponse captureresponse = litle.Capture(caputure);
            Assert.AreEqual(123, captureresponse.LitleTxnId);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<captureGivenAuth.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</captureGivenAuth>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            CaptureGivenAuthResponse caputregivenauthresponse = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual(123, caputregivenauthresponse.LitleTxnId);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<credit.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</credit>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            CreditResponse creditresponse = litle.Credit(credit);
            Assert.AreEqual(123, creditresponse.LitleTxnId);
        }

        [Test]
        public void testEcheckCredit()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12;
            echeckcredit.LitleTxnId = 123456789101112;

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<echeckCredit.*?<litleTxnId>123456789101112</litleTxnId>.*?</echeckCredit>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckCreditResponse><litleTxnId>123</litleTxnId></echeckCreditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            EcheckCreditResponse echeckcreditresponse = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual(123, echeckcreditresponse.LitleTxnId);
        }

        [Test]
        public void testEcheckRedeposit()
        {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.LitleTxnId = 123456;

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex("<litleOnlineRequest.*?<echeckRedeposit.*?<litleTxnId>123456</litleTxnId>.*?</echeckRedeposit>", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            EcheckRedepositResponse echeckredepositresponse = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual(123, echeckredepositresponse.LitleTxnId);
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
            

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex("<litleOnlineRequest.*?<echeckSale.*?<echeck>.*?<accNum>12345657890</accNum>.*?</echeck>.*?</echeckSale>", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckSalesResponse><litleTxnId>123</litleTxnId></echeckSalesResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            EcheckSalesResponse echecksaleresponse = litle.EcheckSale(echecksale);
            Assert.AreEqual(123, echecksaleresponse.LitleTxnId);
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


            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex("<litleOnlineRequest.*?<echeckVerification.*?<echeck>.*?<accNum>12345657890</accNum>.*?</echeck>.*?</echeckVerification>", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVerificationResponse><litleTxnId>123</litleTxnId></echeckVerificationResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            EcheckVerificationResponse echeckverificaitonresponse = litle.EcheckVerification(echeckverification);
            Assert.AreEqual(123, echeckverificaitonresponse.LitleTxnId);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<forceCapture.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</forceCapture>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            ForceCaptureResponse forcecaptureresponse = litle.ForceCapture(forcecapture);
            Assert.AreEqual(123, forcecaptureresponse.LitleTxnId);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<sale.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</sale>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            SaleResponse saleresponse = litle.Sale(sale);
            Assert.AreEqual(123, saleresponse.LitleTxnId);
        }

        [Test]
        public void testToken()
        {
            RegisterTokenRequestType token = new RegisterTokenRequestType();
            token.OrderId = "12344";
            token.AccountNumber = "1233456789103801";
            

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<registerTokenRequest.*?<accountNumber>1233456789103801</accountNumber>.*?</registerTokenRequest>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>123</litleTxnId></registerTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            RegisterTokenResponse registertokenresponse = litle.RegisterToken(token);
            Assert.AreEqual(123, registertokenresponse.LitleTxnId);
            Assert.IsNull(registertokenresponse.Type);
        }

        [Test]
        public void testActivate()
        {
            Activate activate = new Activate();
            activate.OrderId = "2";
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.Card = new CardType();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<activate.*?<orderId>2</orderId>.*?</activate>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><activateResponse><litleTxnId>123</litleTxnId></activateResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            ActivateResponse activateResponse = litle.Activate(activate);
            Assert.AreEqual(123, activateResponse.LitleTxnId);
        }

        [Test]
        public void testDeactivate()
        {
            Deactivate deactivate = new Deactivate();
            deactivate.OrderId = "2";
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<deactivate.*?<orderId>2</orderId>.*?</deactivate>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><deactivateResponse><litleTxnId>123</litleTxnId></deactivateResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            DeactivateResponse deactivateResponse = litle.Deactivate(deactivate);
            Assert.AreEqual(123, deactivateResponse.LitleTxnId);
        }

        [Test]
        public void testLoad()
        {
            Load load = new Load();
            load.OrderId = "2";
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<load.*?<orderId>2</orderId>.*?</load>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><loadResponse><litleTxnId>123</litleTxnId></loadResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            LoadResponse loadResponse = litle.Load(load);
            Assert.AreEqual(123, loadResponse.LitleTxnId);
        }

        [Test]
        public void testUnload()
        {
            Unload unload = new Unload();
            unload.OrderId = "2";
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<unload.*?<orderId>2</orderId>.*?</unload>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><unloadResponse><litleTxnId>123</litleTxnId></unloadResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            UnloadResponse unloadResponse = litle.Unload(unload);
            Assert.AreEqual(123, unloadResponse.LitleTxnId);
        }

        [Test]
        public void testBalanceInquiry()
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderId = "2";
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<balanceInquiry.*?<orderId>2</orderId>.*?</balanceInquiry>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><balanceInquiryResponse><litleTxnId>123</litleTxnId></balanceInquiryResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            BalanceInquiryResponse balanceInquiryResponse = litle.BalanceInquiry(balanceInquiry);
            Assert.AreEqual(123, balanceInquiryResponse.LitleTxnId);
        }

        [Test]
        public void testCreatePlan()
        {
            CreatePlan createPlan = new CreatePlan();
            createPlan.PlanCode = "theCode";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<createPlan.*?<planCode>theCode</planCode>.*?</createPlan>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><createPlanResponse><planCode>theCode</planCode></createPlanResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            CreatePlanResponse createPlanResponse = litle.CreatePlan(createPlan);
            Assert.AreEqual("theCode", createPlanResponse.PlanCode);
        }

        [Test]
        public void testUpdatePlan()
        {
            UpdatePlan updatePlan = new UpdatePlan();
            updatePlan.PlanCode = "theCode";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<updatePlan.*?<planCode>theCode</planCode>.*?</updatePlan>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updatePlanResponse><planCode>theCode</planCode></updatePlanResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            UpdatePlanResponse updatePlanResponse = litle.UpdatePlan(updatePlan);
            Assert.AreEqual("theCode", updatePlanResponse.PlanCode);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<authorization.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='1' message='Error validating xml data against the schema' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            try
            {
                litle.Authorize(authorization);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<authorization.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("no xml");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            try
            {
                litle.Authorize(authorization);
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

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*?<litleOnlineRequest.*?<authorization.*? reportGroup=\"Default Report Group\">.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse reportGroup='Default Report Group'></authorizationResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            AuthorizationResponse authorize = litle.Authorize(authorization);
            Assert.AreEqual("Default Report Group", authorize.ReportGroup);
        }

        [Test]
        public void testSetMerchantSdk()
        {

        }
            
    }
}

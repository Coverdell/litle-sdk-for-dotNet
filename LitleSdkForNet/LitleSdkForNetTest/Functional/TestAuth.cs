using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestAuth
    {
        private LitleOnline litle;
        private Dictionary<string, string> config;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            config = new Dictionary<string, string>();
            config.Add("url", "https://www.testlitle.com/sandbox/communicator/online");
            config.Add("reportGroup", "Default Report Group");
            config.Add("username", "DOTNET");
            config.Add("version", "8.13");
            config.Add("timeout", "65");
            config.Add("merchantId", "101");
            config.Add("password", "TESTCASE");
            config.Add("printxml", "true");
            config.Add("proxyHost", Properties.Settings.Default.proxyHost);
            config.Add("proxyPort", Properties.Settings.Default.proxyPort);
            config.Add("logFile", Properties.Settings.Default.logFile);
            config.Add("neuterAccountNums", "true");
            litle = new LitleOnline(config);
        }

        [Test]
        public void SimpleAuthWithCard()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile

            CustomBilling cb = new CustomBilling();
            cb.Phone = "1112223333"; //This needs to compile too            

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }
        [Test]
        public void SimpleAuthWithMpos()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 200;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            MposType mpos = new MposType();
            mpos.Ksn = "77853211300008E00016";
            mpos.EncryptedTrack = "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD";
            mpos.FormatId = "30";
            mpos.Track1Status = 0;
            mpos.Track2Status = 0;
            authorization.Mpos = mpos; //This needs to compile
       

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }
         [Test]
        public void AuthWithAmpersand()
        {
            Authorization authorization = new Authorization();
            authorization.OrderId = "1";
            authorization.Amount = 10010;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Contact contact = new Contact();
            contact.Name = "John & Jane Smith";
            contact.AddressLine1 = "1 Main St.";
            contact.City = "Burlington";
            contact.State = "MA";
            contact.Zip = "01803-3747";
            contact.Country = CountryTypeEnum.US;
            authorization.BillToAddress = contact;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
             card.CardValidationNum = "349";
             authorization.Card = card;
             authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
         }
        [Test]
        public void simpleAuthWithPaypal()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "123456";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            PayPal paypal = new PayPal();
            paypal.PayerId = "1234";
            paypal.Token = "1234";
            paypal.TransactionId = "123456";
            authorization.Paypal = paypal; //This needs to compile

            CustomBilling cb = new CustomBilling();
            cb.Phone = "1112223333"; //This needs to compile too            

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void simpleAuthWithApplepayAndSecondaryAmountAndWallet()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "123456";
            authorization.Amount = 110;
            authorization.SecondaryAmount = 50;
            authorization.OrderSource = OrderSourceType.Applepay;
            ApplepayType applepay = new ApplepayType();
            ApplepayHeaderType applepayHeaderType = new ApplepayHeaderType();
            applepayHeaderType.ApplicationData = "454657413164";
            applepayHeaderType.EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.TransactionId = "1234";
            applepay.Header = applepayHeaderType;
            applepay.Data = "user";
            applepay.Signature = "sign";
            applepay.Version = "1";
            authorization.Applepay = applepay;

            Wallet wallet = new Wallet();
            wallet.WalletSourceTypeId = "123";
            wallet.WalletSourceType = WalletWalletSourceType.MasterPass;
            authorization.Wallet = wallet;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("Insufficient Funds", response.message);
            Assert.AreEqual("110", response.applepayResponse.transactionAmount);
        }

        [Test]
        public void posWithoutCapabilityAndEntryMode()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            Pos pos = new Pos();
            pos.CardholderId = posCardholderIdTypeEnum.pin;
            authorization.Pos = pos;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000002";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile

            CustomBilling cb = new CustomBilling();
            cb.Phone = "1112223333"; //This needs to compile too            

            try
            {
                litle.Authorize(authorization);
                //expected exception;
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void trackData()
        {
            Authorization authorization = new Authorization();
            authorization.id = "AX54321678";
            authorization.reportGroup = "RG27";
            authorization.OrderId = "12z58743y1";
            authorization.Amount = 12522L;
            authorization.OrderSource = OrderSourceType.Retail;
            Contact billToAddress = new Contact();
            billToAddress.Zip = "95032";
            authorization.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Track = "%B40000001^Doe/JohnP^06041...?;40001=0604101064200?";
            authorization.Card = card;
            Pos pos = new Pos();
            pos.Capability = posCapabilityTypeEnum.magstripe;
            pos.EntryMode = posEntryModeTypeEnum.completeread;
            pos.CardholderId = posCardholderIdTypeEnum.signature;
            authorization.Pos = pos;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void testAuthHandleSpecialCharacters()
        {
            Authorization authorization = new Authorization();
            authorization.reportGroup = "<'&\">";
            authorization.OrderId = "123456";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            PayPal paypal = new PayPal();
            paypal.PayerId = "1234";
            paypal.Token = "1234";
            paypal.TransactionId = "123456";
            authorization.Paypal = paypal; //This needs to compile

            CustomBilling cb = new CustomBilling();
            cb.Phone = "<'&\">"; //This needs to compile too            

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void TestNotHavingTheLogFileSettingShouldDefaultItsValueToNull()
        {
            config.Remove("logFile");

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void TestNeuterAccountNumsShouldDefaultToFalse()
        {
            config.Remove("neuterAccountNums");

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void TestPrintxmlShouldDefaultToFalse()
        {
            config.Remove("printxml");

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }

        [Test]
        public void TestWithAdvancedFraudCheck()
        {
            config.Remove("printxml");

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;
            AdvancedFraudChecksType advancedFraudChecks = new AdvancedFraudChecksType();
            advancedFraudChecks.ThreatMetrixSessionId = "800";
            advancedFraudChecks.CustomAttribute1 = "testAttribute1";
            advancedFraudChecks.CustomAttribute2 = "testAttribute2";
            advancedFraudChecks.CustomAttribute3 = "testAttribute3";
            advancedFraudChecks.CustomAttribute4 = "testAttribute4";
            advancedFraudChecks.CustomAttribute5 = "testAttribute5";
            authorization.AdvancedFraudChecks = advancedFraudChecks;

            authorizationResponse response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
        }
    }
}

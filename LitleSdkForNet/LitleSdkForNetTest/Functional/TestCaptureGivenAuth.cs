using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestCaptureGivenAuth
    {

        private LitleOnline litle;

        [TestFixtureSetUp]
        public void setUp()
        {
            Dictionary<string, string> config = new Dictionary<string, string>();
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
        public void simpleCaptureGivenAuthWithCard() {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000000";
            card.ExpDate = "1210";
            capturegivenauth.Card = card;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void simpleCaptureGivenAuthWithMpos()
        {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 500;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            MposType mpos = new MposType();
            mpos.Ksn = "77853211300008E00016";
            mpos.EncryptedTrack = "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD";
            mpos.FormatId = "30";
            mpos.Track1Status = 0;
            mpos.Track2Status = 0;
            capturegivenauth.Mpos = mpos;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void simpleCaptureGivenAuthWithToken() {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardTokenType cardtoken = new CardTokenType();
            cardtoken.LitleToken = "123456789101112";
            cardtoken.ExpDate ="1210";
            cardtoken.CardValidationNum = "555";
            cardtoken.Type = MethodOfPaymentTypeEnum.VI;
            capturegivenauth.Token = cardtoken;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void complexCaptureGivenAuth() {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            Contact contact = new Contact();
            contact.Name = "Bob";
            contact.City = "lowell";
            contact.State = "MA";
            contact.Email ="litle.com";
            capturegivenauth.BillToAddress = contact;
            ProcessingInstructions processinginstructions = new ProcessingInstructions();
            processinginstructions.BypassVelocityCheck = true;
            capturegivenauth.ProcessingInstructions = processinginstructions;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000000";
            card.ExpDate = "1210";
            capturegivenauth.Card = card;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void authInfo() {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            FraudResult fraudresult = new FraudResult();
            fraudresult.AvsResult = "12";
            fraudresult.CardValidationResult = "123";
            fraudresult.AuthenticationResult = "1";
            fraudresult.AdvancedAVSResult = "123";
            authInfo.FraudResult = fraudresult;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000000";
            card.ExpDate = "1210";
            capturegivenauth.Card=card;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void simpleCaptureGivenAuthWithTokenAndSpecialCharacters()
        {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "<'&\">";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardTokenType cardtoken = new CardTokenType();
            cardtoken.LitleToken = "123456789101112";
            cardtoken.ExpDate = "1210";
            cardtoken.CardValidationNum = "555";
            cardtoken.Type = MethodOfPaymentTypeEnum.VI;
            capturegivenauth.Token = cardtoken;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void simpleCaptureGivenAuthWithSecondaryAmount()
        {
            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.SecondaryAmount = 50;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000000";
            card.ExpDate = "1210";
            capturegivenauth.Card = card;
            CaptureGivenAuthResponse response = litle.CaptureGivenAuth(capturegivenauth);
            Assert.AreEqual("Approved", response.Message);
        }
    }
}

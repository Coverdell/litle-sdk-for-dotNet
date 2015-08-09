using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    class TestCert5Token
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
            config.Add("logFile", null);
            config.Add("neuterAccountNums", null);
            config.Add("proxyHost", Properties.Settings.Default.proxyHost);
            config.Add("proxyPort", Properties.Settings.Default.proxyPort);
            litle = new LitleOnline(config);
        }

        [Test]
        public void test50()
        {
            RegisterTokenRequestType request = new RegisterTokenRequestType();
            request.OrderId = "50";
            request.AccountNumber = "4457119922390123";

            RegisterTokenResponse response = litle.RegisterToken(request);
            Assert.AreEqual("445711", response.Bin);
            Assert.AreEqual(MethodOfPaymentTypeEnum.VI, response.Type);
            Assert.AreEqual("801", response.Response);
            Assert.AreEqual("1111222233330123", response.LitleToken);
            Assert.AreEqual("Account number was successfully registered", response.Message);
        }

        [Test]
        public void test51()
        {
            RegisterTokenRequestType request = new RegisterTokenRequestType();
            request.OrderId = "51";
            request.AccountNumber = "4457119999999999";

            RegisterTokenResponse response = litle.RegisterToken(request);
            Assert.AreEqual("820", response.Response);
            Assert.AreEqual("Credit card number was invalid", response.Message);
        }

        [Test]
        public void test52()
        {
            RegisterTokenRequestType request = new RegisterTokenRequestType();
            request.OrderId = "52";
            request.AccountNumber = "4457119922390123";

            RegisterTokenResponse response = litle.RegisterToken(request);
            Assert.AreEqual("445711", response.Bin);
            Assert.AreEqual(MethodOfPaymentTypeEnum.VI, response.Type);
            Assert.AreEqual("802", response.Response);
            Assert.AreEqual("1111222233330123", response.LitleToken);
            Assert.AreEqual("Account number was previously registered", response.Message);
        }

        [Test]
        public void test53()
        {
            RegisterTokenRequestType request = new RegisterTokenRequestType();
            request.OrderId = "53";
            EcheckForTokenType echeck = new EcheckForTokenType();
            echeck.AccNum = "1099999998";
            echeck.RoutingNum = "114567895";
            request.EcheckForToken = echeck; ;

            RegisterTokenResponse response = litle.RegisterToken(request);
            Assert.AreEqual(MethodOfPaymentTypeEnum.EC, response.Type);
            Assert.AreEqual("998", response.ECheckAccountSuffix);
            Assert.AreEqual("801", response.Response);
            Assert.AreEqual("Account number was successfully registered", response.Message);
            Assert.AreEqual("111922223333000998", response.LitleToken);
        }

        [Test]
        public void test54()
        {
            RegisterTokenRequestType request = new RegisterTokenRequestType();
            request.OrderId = "54";
            EcheckForTokenType echeck = new EcheckForTokenType();
            echeck.AccNum = "1022222102";
            echeck.RoutingNum = "1145_7895";
            request.EcheckForToken = echeck; ;

            RegisterTokenResponse response = litle.RegisterToken(request);
            Assert.AreEqual("900", response.Response);
            Assert.AreEqual("Invalid bank routing number", response.Message);
        }

        [Test]
        public void test55()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "55";
            auth.Amount = 15000;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Number = "5435101234510196";
            card.ExpDate = "1112";
            card.CardValidationNum = "987";
            card.Type = MethodOfPaymentTypeEnum.MC;
            auth.Card = card;

            AuthorizationResponse response = litle.Authorize(auth);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("801", response.TokenResponse.TokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.TokenResponse.TokenMessage);
            Assert.AreEqual(MethodOfPaymentTypeEnum.MC, response.TokenResponse.Type);
            Assert.AreEqual("543510", response.TokenResponse.Bin);
        }

        [Test]
        public void test56()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "56";
            auth.Amount = 15000;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Number = "5435109999999999";
            card.ExpDate = "1112";
            card.CardValidationNum = "987";
            card.Type = MethodOfPaymentTypeEnum.MC;
            auth.Card = card;

            AuthorizationResponse response = litle.Authorize(auth);
            Assert.AreEqual("301", response.Response);
            Assert.AreEqual("Invalid account number", response.Message);
        }

        [Test]
        public void test57()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "57";
            auth.Amount = 15000;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Number = "5435101234510196";
            card.ExpDate = "1112";
            card.CardValidationNum = "987";
            card.Type = MethodOfPaymentTypeEnum.MC;
            auth.Card = card;

            AuthorizationResponse response = litle.Authorize(auth);
            Assert.AreEqual("000", response.Response);
            Assert.AreEqual("Approved", response.Message);
            Assert.AreEqual("802", response.TokenResponse.TokenResponseCode);
            Assert.AreEqual("Account number was previously registered", response.TokenResponse.TokenMessage);
            Assert.AreEqual(MethodOfPaymentTypeEnum.MC, response.TokenResponse.Type);
            Assert.AreEqual("543510", response.TokenResponse.Bin);
        }

        [Test]
        public void test59()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "59";
            auth.Amount = 15000;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardTokenType token = new CardTokenType();
            token.LitleToken = "1712990000040196";
            token.ExpDate = "1112";
            auth.Token = token;

            AuthorizationResponse response = litle.Authorize(auth);
            Assert.AreEqual("822", response.Response);
            Assert.AreEqual("Token was not found", response.Message);
        }

        [Test]
        public void test60()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "60";
            auth.Amount = 15000;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardTokenType token = new CardTokenType();
            token.LitleToken = "1712999999999999";
            token.ExpDate = "1112";
            auth.Token = token;

            AuthorizationResponse response = litle.Authorize(auth);
            Assert.AreEqual("823", response.Response);
            Assert.AreEqual("Token was invalid", response.Message);
        }

        [Test]
        public void test61()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "61";
            sale.Amount = 15000;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Tom";
            billToAddress.LastName = "Black";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking; ;
            echeck.AccNum = "1099999003";
            echeck.RoutingNum = "114567895";
            sale.Echeck = echeck;

            EcheckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("801", response.TokenResponse.TokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.TokenResponse.TokenMessage);
            Assert.AreEqual(MethodOfPaymentTypeEnum.EC, response.TokenResponse.Type);
            Assert.AreEqual("111922223333444003", response.TokenResponse.LitleToken);
        }

        [Test]
        public void test62()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "62";
            sale.Amount = 15000;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Tom";
            billToAddress.LastName = "Black";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking; ;
            echeck.AccNum = "1099999999";
            echeck.RoutingNum = "114567895";
            sale.Echeck = echeck;

            EcheckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("801", response.TokenResponse.TokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.TokenResponse.TokenMessage);
            Assert.AreEqual(MethodOfPaymentTypeEnum.EC, response.TokenResponse.Type);
            Assert.AreEqual("999", response.TokenResponse.ECheckAccountSuffix);
            Assert.AreEqual("111922223333444999", response.TokenResponse.LitleToken);
        }

        [Test]
        public void test63()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "63";
            sale.Amount = 15000;
            sale.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Tom";
            billToAddress.LastName = "Black";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Checking; ;
            echeck.AccNum = "1099999999";
            echeck.RoutingNum = "214567892";
            sale.Echeck = echeck;

            EcheckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("801", response.TokenResponse.TokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.TokenResponse.TokenMessage);
            Assert.AreEqual(MethodOfPaymentTypeEnum.EC, response.TokenResponse.Type);
            Assert.AreEqual("999", response.TokenResponse.ECheckAccountSuffix);
            Assert.AreEqual("111922223333555999", response.TokenResponse.LitleToken);
        }
            
    }
}

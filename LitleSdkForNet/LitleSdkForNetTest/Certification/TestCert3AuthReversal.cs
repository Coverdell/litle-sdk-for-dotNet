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
    class TestCert3AuthReversal
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
        public void test32()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "32";
            auth.Amount = 10010;
            auth.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.Name = "John Smith";
            billToAddress.AddressLine1 = "1 Main St.";
            billToAddress.City = "Burlington";
            billToAddress.State = "MA";
            billToAddress.Zip = "01803-3747";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
            card.CardValidationNum = "349";
            card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card = card;

            AuthorizationResponse authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.Response);
            Assert.AreEqual("Approved", authorizeResponse.Message);
            Assert.AreEqual("11111 ", authorizeResponse.AuthCode);
            Assert.AreEqual("01", authorizeResponse.FraudResult.AvsResult);
            Assert.AreEqual("M", authorizeResponse.FraudResult.CardValidationResult);

            Capture capture = new Capture();
            capture.LitleTxnId = authorizeResponse.LitleTxnId;
            capture.Amount = 5005;
            CaptureResponse captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.Response);
            Assert.AreEqual("Approved", captureResponse.Message);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.LitleTxnId;
            AuthReversalResponse reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("111", reversalResponse.Response);
            Assert.AreEqual("Authorization amount has already been depleted", reversalResponse.Message);
        }

        [Test]
        public void test33()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "33";
            auth.Amount = 20020;
            auth.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Mike J. Hammer";
            billToAddress.AddressLine1 = "2 Main St.";
            billToAddress.AddressLine2 = "Apt. 222";
            billToAddress.City = "Riverside";
            billToAddress.State = "RI";
            billToAddress.Zip = "02915";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "5112010000000003";
            card.ExpDate = "0212";
            card.CardValidationNum = "261";
            card.Type = MethodOfPaymentTypeEnum.MC;
            auth.Card = card;
            FraudCheckType fraud = new FraudCheckType();
            fraud.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            auth.CardholderAuthentication = fraud;

            AuthorizationResponse authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.Response);
            Assert.AreEqual("Approved", authorizeResponse.Message);
            Assert.AreEqual("22222", authorizeResponse.AuthCode);
            Assert.AreEqual("10", authorizeResponse.FraudResult.AvsResult);
            Assert.AreEqual("M", authorizeResponse.FraudResult.CardValidationResult);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.LitleTxnId;
            AuthReversalResponse reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.Response);
            Assert.AreEqual("Approved", reversalResponse.Message);
        }

        [Test]
        public void test34()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "34";
            auth.Amount = 30030;
            auth.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Eileen Jones";
            billToAddress.AddressLine1 = "3 Main St.";
            billToAddress.City = "Bloomfield";
            billToAddress.State = "CT";
            billToAddress.Zip = "06002";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "6011010000000003";
            card.ExpDate = "0312";
            card.CardValidationNum = "758";
            card.Type = MethodOfPaymentTypeEnum.DI;
            auth.Card = card;

            AuthorizationResponse authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.Response);
            Assert.AreEqual("Approved", authorizeResponse.Message);
            Assert.AreEqual("33333", authorizeResponse.AuthCode);
            Assert.AreEqual("10", authorizeResponse.FraudResult.AvsResult);
            Assert.AreEqual("M", authorizeResponse.FraudResult.CardValidationResult);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.LitleTxnId;
            AuthReversalResponse reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.Response);
            Assert.AreEqual("Approved", reversalResponse.Message);
        }

        [Test]
        public void test35()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "35";
            auth.Amount = 40040;
            auth.OrderSource = OrderSourceType.Ecommerce;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob Black";
            billToAddress.AddressLine1 = "4 Main St.";
            billToAddress.City = "Laurel";
            billToAddress.State = "MD";
            billToAddress.Zip = "20708";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "375001000000005";
            card.ExpDate = "0412";
            card.Type = MethodOfPaymentTypeEnum.AX;
            auth.Card = card;

            AuthorizationResponse authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.Response);
            Assert.AreEqual("Approved", authorizeResponse.Message);
            Assert.AreEqual("44444", authorizeResponse.AuthCode);
            Assert.AreEqual("12", authorizeResponse.FraudResult.AvsResult);

            Capture capture = new Capture();
            capture.LitleTxnId = authorizeResponse.LitleTxnId;
            capture.Amount = 20020;
            CaptureResponse captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.Response);
            Assert.AreEqual("Approved", captureResponse.Message);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.LitleTxnId;
            reversal.Amount = 20020;
            AuthReversalResponse reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.Response);
            Assert.AreEqual("Approved", reversalResponse.Message);
        }

        [Test]
        public void test36()
        {
            Authorization auth = new Authorization();
            auth.OrderId = "36";
            auth.Amount = 20500;
            auth.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Number = "375000026600004";
            card.ExpDate = "0512";
            card.Type = MethodOfPaymentTypeEnum.AX;
            auth.Card = card;

            AuthorizationResponse authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.Response);
            Assert.AreEqual("Approved", authorizeResponse.Message);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.LitleTxnId;
            reversal.Amount = 10000;
            AuthReversalResponse reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("336", reversalResponse.Response);
            Assert.AreEqual("Reversal Amount does not match Authorization amount", reversalResponse.Message);
        }            
    }
}

using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert3AuthReversal
    {
        private LitleOnline litle;
        private IDictionary<string, StringBuilder> _memoryCache;

        [TestFixtureSetUp]
        public void setUp()
        {
            _memoryCache = new Dictionary<string, StringBuilder>();
            var config = new Dictionary<string, string>();
            config.Add("url", "https://www.testlitle.com/sandbox/communicator/online");
            config.Add("reportGroup", "Default Report Group");
            config.Add("username", "DOTNET");
            config.Add("version", "8.13");
            config.Add("timeout", "5000");
            config.Add("merchantId", "101");
            config.Add("password", "TESTCASE");
            config.Add("printxml", "true");
            config.Add("logFile", null);
            config.Add("neuterAccountNums", null);
            config.Add("proxyHost", Settings.Default.proxyHost);
            config.Add("proxyPort", Settings.Default.proxyPort);
            litle = new LitleOnline(_memoryCache, config);
        }

        [Test]
        public void test32()
        {
            var auth = new Authorization();
            auth.OrderId = "32";
            auth.Amount = 10010;
            auth.OrderSource = OrderSourceType.Ecommerce;
            var billToAddress = new Contact();
            billToAddress.Name = "John Smith";
            billToAddress.AddressLine1 = "1 Main St.";
            billToAddress.City = "Burlington";
            billToAddress.State = "MA";
            billToAddress.Zip = "01803-3747";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            var card = new CardType();
            card.Number = "4457010000000009";
            card.ExpDate = "0112";
            card.CardValidationNum = "349";
            card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card = card;

            var authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("11111 ", authorizeResponse.authCode);
            Assert.AreEqual("01", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var capture = new Capture();
            capture.LitleTxnId = authorizeResponse.litleTxnId;
            capture.Amount = 5005;
            var captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.litleTxnId;
            var reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("111", reversalResponse.response);
            Assert.AreEqual("Authorization amount has already been depleted", reversalResponse.message);
        }

        [Test]
        public void test33()
        {
            var auth = new Authorization();
            auth.OrderId = "33";
            auth.Amount = 20020;
            auth.OrderSource = OrderSourceType.Ecommerce;
            var billToAddress = new Contact();
            billToAddress.Name = "Mike J. Hammer";
            billToAddress.AddressLine1 = "2 Main St.";
            billToAddress.AddressLine2 = "Apt. 222";
            billToAddress.City = "Riverside";
            billToAddress.State = "RI";
            billToAddress.Zip = "02915";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            var card = new CardType();
            card.Number = "5112010000000003";
            card.ExpDate = "0212";
            card.CardValidationNum = "261";
            card.Type = MethodOfPaymentTypeEnum.MC;
            auth.Card = card;
            var fraud = new FraudCheckType();
            fraud.AuthenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA=";
            auth.CardholderAuthentication = fraud;

            var authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("22222", authorizeResponse.authCode);
            Assert.AreEqual("10", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.litleTxnId;
            var reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void test34()
        {
            var auth = new Authorization();
            auth.OrderId = "34";
            auth.Amount = 30030;
            auth.OrderSource = OrderSourceType.Ecommerce;
            var billToAddress = new Contact();
            billToAddress.Name = "Eileen Jones";
            billToAddress.AddressLine1 = "3 Main St.";
            billToAddress.City = "Bloomfield";
            billToAddress.State = "CT";
            billToAddress.Zip = "06002";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            var card = new CardType();
            card.Number = "6011010000000003";
            card.ExpDate = "0312";
            card.CardValidationNum = "758";
            card.Type = MethodOfPaymentTypeEnum.DI;
            auth.Card = card;

            var authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("33333", authorizeResponse.authCode);
            Assert.AreEqual("10", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.litleTxnId;
            var reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void test35()
        {
            var auth = new Authorization();
            auth.OrderId = "35";
            auth.Amount = 40040;
            auth.OrderSource = OrderSourceType.Ecommerce;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob Black";
            billToAddress.AddressLine1 = "4 Main St.";
            billToAddress.City = "Laurel";
            billToAddress.State = "MD";
            billToAddress.Zip = "20708";
            billToAddress.Country = CountryTypeEnum.US;
            auth.BillToAddress = billToAddress;
            var card = new CardType();
            card.Number = "375001000000005";
            card.ExpDate = "0412";
            card.Type = MethodOfPaymentTypeEnum.AX;
            auth.Card = card;

            var authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("44444", authorizeResponse.authCode);
            Assert.AreEqual("12", authorizeResponse.fraudResult.avsResult);

            var capture = new Capture();
            capture.LitleTxnId = authorizeResponse.litleTxnId;
            capture.Amount = 20020;
            var captureResponse = litle.Capture(capture);
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.litleTxnId;
            reversal.Amount = 20020;
            var reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void test36()
        {
            var auth = new Authorization();
            auth.OrderId = "36";
            auth.Amount = 20500;
            auth.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Number = "375000026600004";
            card.ExpDate = "0512";
            card.Type = MethodOfPaymentTypeEnum.AX;
            auth.Card = card;

            var authorizeResponse = litle.Authorize(auth);
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = authorizeResponse.litleTxnId;
            reversal.Amount = 10000;
            var reversalResponse = litle.AuthReversal(reversal);
            Assert.AreEqual("336", reversalResponse.response);
            Assert.AreEqual("Reversal Amount does not match Authorization amount", reversalResponse.message);
        }
    }
}

using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestSale
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
            config.Add("proxyHost", Settings.Default.proxyHost);
            config.Add("proxyPort", Settings.Default.proxyPort);
            config.Add("logFile", Settings.Default.logFile);
            config.Add("neuterAccountNums", "true");
            litle = new LitleOnline(_memoryCache, config);
        }

        [Test]
        public void SimpleSaleWithCard()
        {
            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            var cardObj = new CardType();
            cardObj.Type = MethodOfPaymentTypeEnum.VI;
            cardObj.Number = "4100000000000000";
            cardObj.ExpDate = "1210";
            saleObj.Card = cardObj;

            var responseObj = litle.Sale(saleObj);
            StringAssert.AreEqualIgnoringCase("Approved", responseObj.message);
        }

        [Test]
        public void SimpleSaleWithMpos()
        {
            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            var mpos = new MposType();
            mpos.Ksn = "77853211300008E00016";
            mpos.EncryptedTrack =
                "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD";
            mpos.FormatId = "30";
            mpos.Track1Status = 0;
            mpos.Track2Status = 0;
            ;
            saleObj.Mpos = mpos;

            var responseObj = litle.Sale(saleObj);
            StringAssert.AreEqualIgnoringCase("Approved", responseObj.message);
        }

        [Test]
        public void SimpleSaleWithPayPal()
        {
            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            var payPalObj = new PayPal();
            payPalObj.PayerId = "1234";
            payPalObj.Token = "1234";
            payPalObj.TransactionId = "123456";
            saleObj.Paypal = payPalObj;
            var responseObj = litle.Sale(saleObj);
            StringAssert.AreEqualIgnoringCase("Approved", responseObj.message);
        }

        [Test]
        public void SimpleSaleWithApplepayAndSecondaryAmountAndWallet()
        {
            var saleObj = new Sale();
            saleObj.Amount = 110;
            saleObj.SecondaryAmount = 50;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            var applepay = new ApplepayType();
            var applepayHeaderType = new ApplepayHeaderType();
            applepayHeaderType.ApplicationData = "454657413164";
            applepayHeaderType.EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.TransactionId = "1234";
            applepay.Header = applepayHeaderType;
            applepay.Data = "user";
            applepay.Signature = "sign";
            applepay.Version = "1";
            saleObj.Applepay = applepay;
            var wallet = new Wallet();
            wallet.WalletSourceTypeId = "123";
            wallet.WalletSourceType = WalletWalletSourceType.MasterPass;
            saleObj.Wallet = wallet;

            var responseObj = litle.Sale(saleObj);
            Assert.AreEqual("Insufficient Funds", responseObj.message);
            Assert.AreEqual("110", responseObj.applepayResponse.transactionAmount);
        }

        [Test]
        public void SimpleSaleWithInvalidFraudCheck()
        {
            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            var cardObj = new CardType();
            cardObj.Type = MethodOfPaymentTypeEnum.VI;
            cardObj.Number = "4100000000000000";
            cardObj.ExpDate = "1210";
            saleObj.Card = cardObj;
            var cardholderAuthentication = new FraudCheckType();
            cardholderAuthentication.AuthenticationValue =
                "123456789012345678901234567890123456789012345678901234567890";
            saleObj.CardholderAuthentication = cardholderAuthentication;

            try
            {
                var responseObj = litle.Sale(saleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}

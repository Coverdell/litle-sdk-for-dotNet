using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckSale
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
        public void SimpleEcheckSaleWithEcheck()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            var echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            var contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;

            var response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void NoAmount()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";

            try
            {
                //expected exception;
                var response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void EcheckSaleWithShipTo()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.Verify = true;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            var echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            var contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;
            echeckSaleObj.ShipToAddress = contactObj;

            var response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckSaleWithEcheckToken()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.Verify = true;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            var echeckTokenTypeObj = new EcheckTokenType();
            echeckTokenTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTokenTypeObj.LitleToken = "1234565789012";
            echeckTokenTypeObj.RoutingNum = "123456789";
            echeckTokenTypeObj.CheckNum = "123455";

            var customBillingObj = new CustomBilling();
            customBillingObj.Phone = "123456789";
            customBillingObj.Descriptor = "good";

            var contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Token = echeckTokenTypeObj;
            echeckSaleObj.CustomBilling = customBillingObj;
            echeckSaleObj.BillToAddress = contactObj;

            var response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckSaleMissingBilling()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            var echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            echeckSaleObj.Echeck = echeckTypeObj;

            try
            {
                //expected exception;
                var response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void SimpleEcheckSale()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.LitleTxnId = 123456789101112;
            echeckSaleObj.Amount = 12;

            var response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void SimpleEcheckSaleWithSecondaryAmountWithOrderId()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.SecondaryAmount = 50;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            var echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.CorpSavings;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            var contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;

            var response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void SimpleEcheckSaleWithSecondaryAmount()
        {
            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.SecondaryAmount = 50;
            echeckSaleObj.LitleTxnId = 1234565L;
            try
            {
                ////expected exception;
                var response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestEcheckSale
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
        public void SimpleEcheckSaleWithEcheck()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            EcheckType echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";
            
            Contact contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;

            echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void NoAmount()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            
            try
            {
                //expected exception;
                echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void EcheckSaleWithShipTo()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.Verify = true;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            EcheckType echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            Contact contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;
            echeckSaleObj.ShipToAddress = contactObj;

            echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckSaleWithEcheckToken()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.Verify = true;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            EcheckTokenType echeckTokenTypeObj = new EcheckTokenType();
            echeckTokenTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTokenTypeObj.LitleToken = "1234565789012";
            echeckTokenTypeObj.RoutingNum = "123456789";
            echeckTokenTypeObj.CheckNum = "123455";

            CustomBilling customBillingObj = new CustomBilling();
            customBillingObj.Phone = "123456789";
            customBillingObj.Descriptor = "good";

            Contact contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Token = echeckTokenTypeObj;
            echeckSaleObj.CustomBilling = customBillingObj;
            echeckSaleObj.BillToAddress = contactObj;

            echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckSaleMissingBilling()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            EcheckType echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            echeckSaleObj.Echeck = echeckTypeObj;

            try
            {
                //expected exception;
                echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void SimpleEcheckSale()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.reportGroup = "Planets";
            echeckSaleObj.LitleTxnId = 123456789101112;
            echeckSaleObj.Amount = 12;

            echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void SimpleEcheckSaleWithSecondaryAmountWithOrderId()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.SecondaryAmount = 50;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;

            EcheckType echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.CorpSavings;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";

            Contact contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckSaleObj.Echeck = echeckTypeObj;
            echeckSaleObj.BillToAddress = contactObj;

            echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void SimpleEcheckSaleWithSecondaryAmount()
        {
            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.SecondaryAmount = 50;
            echeckSaleObj.LitleTxnId = 1234565L;
            try
            {
                ////expected exception;
                echeckSalesResponse response = litle.EcheckSale(echeckSaleObj);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}

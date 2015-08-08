using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    class TestCert4Echeck
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
        public void test37()
        {
            EcheckVerification verification = new EcheckVerification();
            verification.OrderId = "37";
            verification.Amount = 3001;
            verification.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Tom";
            billToAddress.LastName = "Black";
            verification.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "10@BC99999";
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.RoutingNum = "053100300";
            verification.Echeck = echeck;

            echeckVerificationResponse response = litle.EcheckVerification(verification);
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void test38()
        {
            EcheckVerification verification = new EcheckVerification();
            verification.OrderId = "38";
            verification.Amount = 3002;
            verification.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "John";
            billToAddress.LastName = "Smith";
            billToAddress.Phone = "999-999-9999";
            verification.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "1099999999";
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.RoutingNum = "053000219";
            verification.Echeck = echeck;

            echeckVerificationResponse response = litle.EcheckVerification(verification);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test39()
        {
            EcheckVerification verification = new EcheckVerification();
            verification.OrderId = "39";
            verification.Amount = 3003;
            verification.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Robert";
            billToAddress.LastName = "Jones";
            billToAddress.CompanyName = "Good Goods Inc";
            billToAddress.Phone = "9999999999";
            verification.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "3099999999";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "053100300";
            verification.Echeck = echeck;

            echeckVerificationResponse response = litle.EcheckVerification(verification);
            Assert.AreEqual("950", response.response);
            Assert.AreEqual("Declined - Negative Information on File", response.message);
        }

        [Test]
        public void test40()
        {
            EcheckVerification verification = new EcheckVerification();
            verification.OrderId = "40";
            verification.Amount = 3004;
            verification.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Peter";
            billToAddress.LastName = "Green";
            billToAddress.CompanyName = "Green Co";
            billToAddress.Phone = "9999999999";
            verification.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "8099999999";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "063102152";
            verification.Echeck = echeck;

            echeckVerificationResponse response = litle.EcheckVerification(verification);
            Assert.AreEqual("951", response.response);
            Assert.AreEqual("Absolute Decline", response.message);
        }

        [Test]
        public void test41()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "41";
            sale.Amount = 2008;
            sale.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Mike";
            billToAddress.MiddleInitial = "J";
            billToAddress.LastName = "Hammer";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "10@BC99999";
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.RoutingNum = "053100300";
            sale.Echeck = echeck;

            echeckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void test42()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "42";
            sale.Amount = 2004;
            sale.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Tom";
            billToAddress.LastName = "Black";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "4099999992";
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.RoutingNum = "211370545";
            sale.Echeck = echeck;

            echeckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test43()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "43";
            sale.Amount = 2007;
            sale.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Peter";
            billToAddress.LastName = "Green";
            billToAddress.CompanyName = "Green Co";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "6099999992";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "211370545";
            sale.Echeck = echeck;

            echeckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test44()
        {
            EcheckSale sale = new EcheckSale();
            sale.OrderId = "44";
            sale.Amount = 2009;
            sale.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Peter";
            billToAddress.LastName = "Green";
            billToAddress.CompanyName = "Green Co";
            sale.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "9099999992";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "053133052";
            sale.Echeck = echeck;

            echeckSalesResponse response = litle.EcheckSale(sale);
            Assert.AreEqual("900", response.response);
            Assert.AreEqual("Invalid Bank Routing Number", response.message);
        }

        [Test]
        public void test45()
        {
            EcheckCredit credit = new EcheckCredit();
            credit.OrderId = "45";
            credit.Amount = 1001;
            credit.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "John";
            billToAddress.LastName = "Smith";
            credit.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "10@BC99999";
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.RoutingNum = "053100300";
            credit.Echeck = echeck;

            echeckCreditResponse response = litle.EcheckCredit(credit);
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void test46()
        {
            EcheckCredit credit = new EcheckCredit();
            credit.OrderId = "46";
            credit.Amount = 1003;
            credit.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Robert";
            billToAddress.LastName = "Jones";
            billToAddress.CompanyName = "Widget Inc";
            credit.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "3099999999";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "063102152";
            credit.Echeck = echeck;

            echeckCreditResponse response = litle.EcheckCredit(credit);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test47()
        {
            EcheckCredit credit = new EcheckCredit();
            credit.OrderId = "47";
            credit.Amount = 1007;
            credit.OrderSource = OrderSourceType.Telephone;
            Contact billToAddress = new Contact();
            billToAddress.FirstName = "Peter";
            billToAddress.LastName = "Green";
            billToAddress.CompanyName = "Green Co";
            credit.BillToAddress = billToAddress;
            EcheckType echeck = new EcheckType();
            echeck.AccNum = "6099999993";
            echeck.AccType = echeckAccountTypeEnum.Corporate;
            echeck.RoutingNum = "211370545";
            credit.Echeck = echeck;

            echeckCreditResponse response = litle.EcheckCredit(credit);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test48()
        {
            EcheckCredit credit = new EcheckCredit();
            credit.LitleTxnId = 430000000000000001L;

            echeckCreditResponse response = litle.EcheckCredit(credit);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test49()
        {
            EcheckCredit credit = new EcheckCredit();
            credit.LitleTxnId = 2L;

            echeckCreditResponse response = litle.EcheckCredit(credit);
            Assert.AreEqual("360", response.response);
            Assert.AreEqual("No transaction found with specified litleTxnId", response.message);
        }
            
    }
}

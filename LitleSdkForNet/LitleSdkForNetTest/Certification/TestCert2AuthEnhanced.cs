using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert2AuthEnhanced
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
        public void test14()
        {
            var authorization = new Authorization();
            authorization.OrderId = "14";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010200000247";
            card.ExpDate = "0812";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("2000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("NO", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("GIFT", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test15()
        {
            var authorization = new Authorization();
            authorization.OrderId = "15";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5500000254444445";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("2000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test16()
        {
            var authorization = new Authorization();
            authorization.OrderId = "16";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5592106621450897";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("0", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test17()
        {
            var authorization = new Authorization();
            authorization.OrderId = "17";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5590409551104142";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("6500", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test18()
        {
            var authorization = new Authorization();
            authorization.OrderId = "18";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5587755665222179";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("12200", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test19()
        {
            var authorization = new Authorization();
            authorization.OrderId = "19";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5445840176552850";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("20000", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test20()
        {
            var authorization = new Authorization();
            authorization.OrderId = "20";
            authorization.Amount = 3000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5390016478904678";
            card.ExpDate = "0312";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(fundingSourceTypeEnum.PREPAID, response.enhancedAuthResponse.fundingSource.type);
            Assert.AreEqual("10050", response.enhancedAuthResponse.fundingSource.availableBalance);
            Assert.AreEqual("YES", response.enhancedAuthResponse.fundingSource.reloadable);
            Assert.AreEqual("PAYROLL", response.enhancedAuthResponse.fundingSource.prepaidCardType);
        }

        [Test]
        public void test21()
        {
            var authorization = new Authorization();
            authorization.OrderId = "21";
            authorization.Amount = 5000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010201000246";
            card.ExpDate = "0912";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.AFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void test22()
        {
            var authorization = new Authorization();
            authorization.OrderId = "22";
            authorization.Amount = 5000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4457010202000245";
            card.ExpDate = "1111";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.MASSAFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void test23()
        {
            var authorization = new Authorization();
            authorization.OrderId = "23";
            authorization.Amount = 5000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010201000109";
            card.ExpDate = "0412";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.AFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void test24()
        {
            var authorization = new Authorization();
            authorization.OrderId = "24";
            authorization.Amount = 5000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5112010202000108";
            card.ExpDate = "0812";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual(affluenceTypeEnum.MASSAFFLUENT, response.enhancedAuthResponse.affluence);
        }

        [Test]
        public void test25()
        {
            var authorization = new Authorization();
            authorization.OrderId = "25";
            authorization.Amount = 5000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100204446270000";
            card.ExpDate = "1112";
            authorization.Card = card;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("BRA", response.enhancedAuthResponse.issuerCountry);
        }

        [Test]
        public void test26()
        {
            var authorization = new Authorization();
            authorization.OrderId = "26";
            authorization.Amount = 18698;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5194560012341234";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 20000;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void test27()
        {
            var authorization = new Authorization();
            authorization.OrderId = "27";
            authorization.Amount = 18698;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5194560012341234";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 15000;
            healthcareamounts.RxAmount = 16000;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void test28()
        {
            var authorization = new Authorization();
            authorization.OrderId = "28";
            authorization.Amount = 15000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.MC;
            card.Number = "5194560012341234";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 15000;
            healthcareamounts.RxAmount = 3698;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void test29()
        {
            var authorization = new Authorization();
            authorization.OrderId = "29";
            authorization.Amount = 18699;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4024720001231239";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 31000;
            healthcareamounts.RxAmount = 1000;
            healthcareamounts.VisionAmount = 19901;
            healthcareamounts.ClinicOtherAmount = 9050;
            healthcareamounts.DentalAmount = 1049;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void test30()
        {
            var authorization = new Authorization();
            authorization.OrderId = "30";
            authorization.Amount = 20000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4024720001231239";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 20000;
            healthcareamounts.RxAmount = 1000;
            healthcareamounts.VisionAmount = 19901;
            healthcareamounts.ClinicOtherAmount = 9050;
            healthcareamounts.DentalAmount = 1049;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("341", response.response);
            Assert.AreEqual("Invalid healthcare amounts", response.message);
        }

        [Test]
        public void test31()
        {
            var authorization = new Authorization();
            authorization.OrderId = "31";
            authorization.Amount = 25000;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4024720001231239";
            card.ExpDate = "1212";
            authorization.Card = card;
            authorization.AllowPartialAuth = true;
            var healthcareiias = new HealthcareIIAS();
            var healthcareamounts = new HealthcareAmounts();
            healthcareamounts.TotalHealthcareAmount = 18699;
            healthcareamounts.RxAmount = 1000;
            healthcareamounts.VisionAmount = 15099;
            healthcareiias.HealthcareAmounts = healthcareamounts;
            healthcareiias.IIASFlag = IIASFlagType.Y;
            authorization.healthcareIIAS = healthcareiias;

            var response = litle.Authorize(authorization);
            Assert.AreEqual("010", response.response);
            Assert.AreEqual("Partially Approved", response.message);
            Assert.AreEqual("18699", response.approvedAmount);
        }
    }
}

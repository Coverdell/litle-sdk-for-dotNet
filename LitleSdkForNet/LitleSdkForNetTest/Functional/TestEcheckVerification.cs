using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckVerification
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
        public void SimpleEcheckVerification()
        {
            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;

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

            echeckVerificationObject.Echeck = echeckTypeObj;
            echeckVerificationObject.BillToAddress = contactObj;

            var response = litle.EcheckVerification(echeckVerificationObject);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckVerificationWithEcheckToken()
        {
            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;

            var echeckTokenObj = new EcheckTokenType();
            echeckTokenObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTokenObj.LitleToken = "1234565789012";
            echeckTokenObj.RoutingNum = "123456789";
            echeckTokenObj.CheckNum = "123455";

            var contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckVerificationObject.Token = echeckTokenObj;
            echeckVerificationObject.BillToAddress = contactObj;

            var response = litle.EcheckVerification(echeckVerificationObject);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void TestMissingBillingField()
        {
            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.reportGroup = "Planets";
            echeckVerificationObject.Amount = 123;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;

            var echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";
            echeckVerificationObject.Echeck = echeckTypeObj;
            try
            {
                //expected exception;
                var response = litle.EcheckVerification(echeckVerificationObject);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}

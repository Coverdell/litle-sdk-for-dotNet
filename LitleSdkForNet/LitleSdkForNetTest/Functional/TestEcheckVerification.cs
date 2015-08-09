using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestEcheckVerification
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
        public void SimpleEcheckVerification()
        {
            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            
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

            echeckVerificationObject.Echeck = echeckTypeObj;
            echeckVerificationObject.BillToAddress = contactObj;

            echeckVerificationResponse response = litle.EcheckVerification(echeckVerificationObject);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckVerificationWithEcheckToken()
        {
            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;

            EcheckTokenType echeckTokenObj = new EcheckTokenType();
            echeckTokenObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTokenObj.LitleToken = "1234565789012";
            echeckTokenObj.RoutingNum = "123456789";
            echeckTokenObj.CheckNum = "123455";

            Contact contactObj = new Contact();
            contactObj.Name = "Bob";
            contactObj.City = "lowell";
            contactObj.State = "MA";
            contactObj.Email = "litle.com";

            echeckVerificationObject.Token = echeckTokenObj;
            echeckVerificationObject.BillToAddress = contactObj;

            echeckVerificationResponse response = litle.EcheckVerification(echeckVerificationObject);
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void TestMissingBillingField()
        {
            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.reportGroup = "Planets";
            echeckVerificationObject.Amount = 123;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;

            EcheckType echeckTypeObj = new EcheckType();
            echeckTypeObj.AccType = echeckAccountTypeEnum.Checking;
            echeckTypeObj.AccNum = "12345657890";
            echeckTypeObj.RoutingNum = "123456789";
            echeckTypeObj.CheckNum = "123455";
            echeckVerificationObject.Echeck = echeckTypeObj;
            try
            {
                //expected exception;
                echeckVerificationResponse response = litle.EcheckVerification(echeckVerificationObject);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}

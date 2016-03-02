using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestToken
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
        public void SimpleToken()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";
            var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }


        [Test]
        public void SimpleTokenWithPayPage()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.PaypageRegistrationId = "1233456789101112";
            registerTokenRequest.reportGroup = "Planets";
            var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithEcheck()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            var echeckObj = new EcheckForTokenType();
            echeckObj.AccNum = "12344565";
            echeckObj.RoutingNum = "123476545";
            registerTokenRequest.EcheckForToken = echeckObj;
            registerTokenRequest.reportGroup = "Planets";
            var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithApplepay()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.reportGroup = "Planets";
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
            registerTokenRequest.Applepay = applepay;
            var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
            Assert.AreEqual("0", rtokenResponse.applepayResponse.transactionAmount);
        }

        [Test]
        public void TokenEcheckMissingRequiredField()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            var echeckObj = new EcheckForTokenType();
            echeckObj.RoutingNum = "123476545";
            registerTokenRequest.EcheckForToken = echeckObj;
            registerTokenRequest.reportGroup = "Planets";
            try
            {
                //expected exception;
                var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void TestSimpleTokenWithNullableTypeField()
        {
            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";
            var rtokenResponse = litle.RegisterToken(registerTokenRequest);
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
            Assert.IsNull(rtokenResponse.type);
        }
    }
}

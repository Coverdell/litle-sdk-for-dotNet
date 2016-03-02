using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckRedeposit
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
        public void simpleEcheckRedeposit()
        {
            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            var response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckRedepositWithEcheck()
        {
            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";

            echeckredeposit.Echeck = echeck;
            var response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckRedepositWithEcheckToken()
        {
            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            var echeckToken = new EcheckTokenType();
            echeckToken.AccType = echeckAccountTypeEnum.Checking;
            echeckToken.LitleToken = "1234565789012";
            echeckToken.RoutingNum = "123456789";
            echeckToken.CheckNum = "123455";

            echeckredeposit.Token = echeckToken;
            var response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }
    }
}

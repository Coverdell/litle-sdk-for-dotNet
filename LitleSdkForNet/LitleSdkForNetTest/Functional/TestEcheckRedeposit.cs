using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestEcheckRedeposit
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
        public void simpleEcheckRedeposit() {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckRedepositResponse response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckRedepositWithEcheck() {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";

            echeckredeposit.Echeck = echeck;
            echeckRedepositResponse response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckRedepositWithEcheckToken() {
            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            EcheckTokenType echeckToken = new EcheckTokenType();
            echeckToken.AccType = echeckAccountTypeEnum.Checking;
            echeckToken.LitleToken = "1234565789012";
            echeckToken.RoutingNum = "123456789";
            echeckToken.CheckNum = "123455";

            echeckredeposit.Token = echeckToken;
            echeckRedepositResponse response = litle.EcheckRedeposit(echeckredeposit);
            Assert.AreEqual("Approved", response.message);
        }
            
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestAuthReversal
    {
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
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
        public void SimpleAuthReversal()
        {
            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            authReversalResponse response = litle.AuthReversal(reversal);
            Assert.AreEqual("Approved", response.message);
        }
            
        [Test]
        public void testAuthReversalHandleSpecialCharacters()
        {
            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "<'&\">";

            authReversalResponse response = litle.AuthReversal(reversal);
            Assert.AreEqual("Approved", response.message);
    }
    }
}

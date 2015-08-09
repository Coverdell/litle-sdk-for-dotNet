﻿using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestCredit
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
        public void SimpleCreditWithCard()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            
            creditObj.Card = card;
            
            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void SimpleCreditWithMpos()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            MposType mpos = new MposType();
            mpos.Ksn = "77853211300008E00016";
            mpos.EncryptedTrack = "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD";
            mpos.FormatId = "30";
            mpos.Track1Status = 0;
            mpos.Track2Status = 0;
            creditObj.Mpos = mpos;

            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void SimpleCreditWithPaypal()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "123456";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            PayPal payPalObj = new PayPal();
            payPalObj.PayerId = "1234";

            creditObj.Paypal = payPalObj;

            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void PaypalNotes()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "123456";
            creditObj.PayPalNotes = "Hello";
            creditObj.OrderSource = OrderSourceType.Ecommerce;

            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";

            creditObj.Card = card;
            
            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void ProcessingInstructionAndAmexData()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 2000;
            creditObj.OrderId = "12344";
            creditObj.OrderSource = OrderSourceType.Ecommerce;

            ProcessingInstructions processingInstructionsObj = new ProcessingInstructions();
            processingInstructionsObj.BypassVelocityCheck = true;

            creditObj.ProcessingInstructions = processingInstructionsObj;
            
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";

            creditObj.Card = card;

            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }

        [Test]
        public void SimpleCreditWithCardAndSpecialCharacters()
        {
            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "<&'>";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000<>0000001";
            card.ExpDate = "1210";

            creditObj.Card = card;

            CreditResponse response = litle.Credit(creditObj);
            Assert.AreEqual("Approved", response.Message);
        }
    }
}

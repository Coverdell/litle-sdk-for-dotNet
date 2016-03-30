﻿using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestCredit : LitleOnlineTestBase
    {
        protected override Dictionary<string, string> SetupConfig() => new Dictionary<string, string>
        {
            {"url", "https://www.testlitle.com/sandbox/communicator/online"},
            {"reportGroup", "Default Report Group"},
            {"username", "DOTNET"},
            {"version", "8.13"},
            {"timeout", "5000"},
            {"merchantId", "101"},
            {"password", "TESTCASE"},
            {"printxml", "true"},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort},
            {"logFile", Settings.Default.logFile},
            {"neuterAccountNums", "true"}
        };

        [Test]
        public void SimpleCreditWithCard()
        {
            var response = Litle.Credit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCreditWithMpos()
        {
            var response = Litle.Credit(new credit
            {
                amount = 106,
                orderId = "2111",
                orderSource = orderSourceType.ecommerce,
                mpos = new mposType
                {
                    ksn = "77853211300008E00016",
                    encryptedTrack =
                        "CASE1E185EADD6AFE78C9A214B21313DCD836FDD555FBE3A6C48D141FE80AB9172B963265AFF72111895FE415DEDA162CE8CB7AC4D91EDB611A2AB756AA9CB1A000000000000000000000000000000005A7AAF5E8885A9DB88ECD2430C497003F2646619A2382FFF205767492306AC804E8E64E8EA6981DD",
                    formatId = "30",
                    track1Status = 0,
                    track2Status = 0
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCreditWithPaypal()
        {
            var response = Litle.Credit(new credit
            {
                amount = 106,
                orderId = "123456",
                orderSource = orderSourceType.ecommerce,
                paypal = new payPal {payerId = "1234"}
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void PaypalNotes()
        {
            var response = Litle.Credit(new credit
            {
                amount = 106,
                orderId = "123456",
                payPalNotes = "Hello",
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void ProcessingInstructionAndAmexData()
        {
            var response = Litle.Credit(new credit
            {
                amount = 2000,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                processingInstructions = new processingInstructions {bypassVelocityCheck = true},
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCreditWithCardAndSpecialCharacters()
        {
            var response = Litle.Credit(new credit
            {
                amount = 106,
                orderId = "<&'>",
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000<>0000001",
                    expDate = "1210"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }
    }
}
using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestCapture : LitleOnlineTestBase
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
        public void SimpleCapture()
        {
            var response = Litle.Capture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes"
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCaptureWithPartial()
        {
            var response = Litle.Capture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                partial = true,
                payPalNotes = "Notes"
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void ComplexCapture()
        {
            var response = Litle.Capture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes",
                enhancedData = new enhancedData
                {
                    customerReference = "Litle",
                    salesTax = 50,
                    deliveryType = enhancedDataDeliveryType.TBD
                },
                payPalOrderComplete = true
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCaptureWithSpecial()
        {
            var response = Litle.Capture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "<'&\">"
            });
            Assert.AreEqual("Approved", response.message);
        }
    }
}
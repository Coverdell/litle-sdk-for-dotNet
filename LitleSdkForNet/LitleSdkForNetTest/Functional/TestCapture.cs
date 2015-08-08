using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestCapture
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
        public void SimpleCapture()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            captureResponse response = litle.Capture(capture);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void simpleCaptureWithPartial()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.Partial = true;
            capture.PayPalNotes = "Notes";

            captureResponse response = litle.Capture(capture);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void complexCapture()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";
            EnhancedData enhanceddata = new EnhancedData();
            enhanceddata.CustomerReference = "Litle";
            enhanceddata.SalesTax = 50;
            enhanceddata.DeliveryType = enhancedDataDeliveryType.TBD;
            capture.EnhancedData = enhanceddata;
            capture.PayPalOrderComplete = true;
            captureResponse response = litle.Capture(capture);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void SimpleCaptureWithSpecial()
        {
            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "<'&\">";

            captureResponse response = litle.Capture(capture);
            Assert.AreEqual("Approved", response.message);
        }
    }
}

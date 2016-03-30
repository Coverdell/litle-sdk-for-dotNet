using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestAuthReversal : LitleOnlineTestBase
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
        public void SimpleAuthReversal()
        {
            var response = Litle.AuthReversal(new authReversal
            {
                litleTxnId = 12345678000L,
                amount = 106,
                payPalNotes = "Notes"
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void TestAuthReversalHandleSpecialCharacters()
        {
            var response = Litle.AuthReversal(new authReversal
            {
                litleTxnId = 12345678000L,
                amount = 106,
                payPalNotes = "<'&\">"
            });
            Assert.AreEqual("Approved", response.message);
        }
    }
}
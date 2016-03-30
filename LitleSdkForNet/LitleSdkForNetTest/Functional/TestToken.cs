using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestToken : LitleOnlineTestBase
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
        public void SimpleToken()
        {
            var rtokenResponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }
        
        [Test]
        public void SimpleTokenWithPayPage()
        {
            var rtokenResponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                paypageRegistrationId = "1233456789101112",
                reportGroup = "Planets"
            });
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithEcheck()
        {
            var rtokenResponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                echeckForToken = new echeckForTokenType
                {
                    accNum = "12344565",
                    routingNum = "123476545"
                },
                reportGroup = "Planets"
            });
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
        }

        [Test]
        public void SimpleTokenWithApplepay()
        {
            var rtokenResponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                reportGroup = "Planets",
                applepay = new applepayType
                {
                    header = new applepayHeaderType
                    {
                        applicationData = "454657413164",
                        ephemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        publicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        transactionId = "1234"
                    },
                    data = "user",
                    signature = "sign",
                    version = "1"
                }
            });
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
            Assert.AreEqual("0", rtokenResponse.applepayResponse.transactionAmount);
        }

        [Test]
        public void TokenEcheckMissingRequiredField()
        {
            try //TODO: Should the test fail after invoking the concern successfully?
            {
                Litle.RegisterToken(new registerTokenRequestType
                {
                    orderId = "12344",
                    echeckForToken = new echeckForTokenType {routingNum = "123476545"},
                    reportGroup = "Planets"
                });
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void TestSimpleTokenWithNullableTypeField()
        {
            var rtokenResponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801",
                reportGroup = "Planets"
            });
            StringAssert.AreEqualIgnoringCase("Account number was successfully registered", rtokenResponse.message);
            Assert.IsNull(rtokenResponse.type);
        }
    }
}
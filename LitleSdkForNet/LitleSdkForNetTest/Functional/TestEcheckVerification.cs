using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckVerification : LitleOnlineTestBase
    {
        protected override Dictionary<string, string> SetupConfig() => new Dictionary<string, string>
        {
            {"url", "https://www.testlitle.com/sandbox/communicator/online"},
            {"reportGroup", "Default Report Group"},
            {"username", "DOTNET"},
            {"version", "9.3.2"},
            {"timeout", "5000"},
            {"merchantId", "101"},
            {"password", "TESTCASE"},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort},
        };

        [Test]
        public void SimpleEcheckVerification()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void EcheckVerificationWithEcheckToken()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                amount = 123456,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                token = new echeckTokenType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    litleToken = "1234565789012",
                    routingNum = "123456789",
                    checkNum = "123455"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });
            StringAssert.AreEqualIgnoringCase("Approved", response.message);
        }

        [Test]
        public void TestMissingBillingField()
        {
            try //TODO: Should the test fail after invoking the concern successfully?
            {
                Litle.EcheckVerification(new echeckVerification
                {
                    reportGroup = "Planets",
                    amount = 123,
                    orderId = "12345",
                    orderSource = orderSourceType.ecommerce,
                    echeck = new echeckType
                    {
                        accType = echeckAccountTypeEnum.Checking,
                        accNum = "12345657890",
                        routingNum = "123456789",
                        checkNum = "123455"
                    }
                });
            }
            catch (LitleOnlineException e)
            {
                Assert.True(e.Message.StartsWith("Error validating xml data against the schema"));
            }
        }
    }
}
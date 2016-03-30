using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert5Token : LitleOnlineTestBase
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
            {"logFile", null},
            {"neuterAccountNums", null},
            {"proxyHost", Settings.Default.proxyHost},
            {"proxyPort", Settings.Default.proxyPort}
        };

        [Test]
        public void Test50()
        {
            var response = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "50",
                accountNumber = "4457119922390123"
            });
            Assert.AreEqual("445711", response.bin);
            Assert.AreEqual(methodOfPaymentTypeEnum.VI, response.type);
            Assert.AreEqual("801", response.response);
            Assert.AreEqual("1111222233330123", response.litleToken);
            Assert.AreEqual("Account number was successfully registered", response.message);
        }

        [Test]
        public void Test51()
        {
            var response = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "51",
                accountNumber = "4457119999999999"
            });
            Assert.AreEqual("820", response.response);
            Assert.AreEqual("Credit card number was invalid", response.message);
        }

        [Test]
        public void Test52()
        {
            var response = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "52",
                accountNumber = "4457119922390123"
            });
            Assert.AreEqual("445711", response.bin);
            Assert.AreEqual(methodOfPaymentTypeEnum.VI, response.type);
            Assert.AreEqual("802", response.response);
            Assert.AreEqual("1111222233330123", response.litleToken);
            Assert.AreEqual("Account number was previously registered", response.message);
        }

        [Test]
        public void Test53()
        {
            var response = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "53",
                echeckForToken = new echeckForTokenType
                {
                    accNum = "1099999998",
                    routingNum = "114567895"
                }
            });
            Assert.AreEqual(methodOfPaymentTypeEnum.EC, response.type);
            Assert.AreEqual("998", response.eCheckAccountSuffix);
            Assert.AreEqual("801", response.response);
            Assert.AreEqual("Account number was successfully registered", response.message);
            Assert.AreEqual("111922223333000998", response.litleToken);
        }

        [Test]
        public void Test54()
        {
            var response = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "54",
                echeckForToken = new echeckForTokenType
                {
                    accNum = "1022222102",
                    routingNum = "1145_7895"
                }
            });
            Assert.AreEqual("900", response.response);
            Assert.AreEqual("Invalid bank routing number", response.message);
        }

        [Test]
        public void Test55()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "55",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    number = "5435101234510196",
                    expDate = "1112",
                    cardValidationNum = "987",
                    type = methodOfPaymentTypeEnum.MC
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("801", response.tokenResponse.tokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.tokenResponse.tokenMessage);
            Assert.AreEqual(methodOfPaymentTypeEnum.MC, response.tokenResponse.type);
            Assert.AreEqual("543510", response.tokenResponse.bin);
        }

        [Test]
        public void Test56()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "56",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    number = "5435109999999999",
                    expDate = "1112",
                    cardValidationNum = "987",
                    type = methodOfPaymentTypeEnum.MC
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid account number", response.message);
        }

        [Test]
        public void Test57()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "57",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    number = "5435101234510196",
                    expDate = "1112",
                    cardValidationNum = "987",
                    type = methodOfPaymentTypeEnum.MC
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
            Assert.AreEqual("802", response.tokenResponse.tokenResponseCode);
            Assert.AreEqual("Account number was previously registered", response.tokenResponse.tokenMessage);
            Assert.AreEqual(methodOfPaymentTypeEnum.MC, response.tokenResponse.type);
            Assert.AreEqual("543510", response.tokenResponse.bin);
        }

        [Test]
        public void Test59()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "59",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                token = new cardTokenType
                {
                    litleToken = "1712990000040196",
                    expDate = "1112"
                }
            });
            Assert.AreEqual("822", response.response);
            Assert.AreEqual("Token was not found", response.message);
        }

        [Test]
        public void Test60()
        {
            var response = Litle.Authorize(new authorization
            {
                orderId = "60",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                token = new cardTokenType
                {
                    litleToken = "1712999999999999",
                    expDate = "1112"
                }
            });
            Assert.AreEqual("823", response.response);
            Assert.AreEqual("Token was invalid", response.message);
        }

        [Test]
        public void Test61()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "61",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    firstName = "Tom",
                    lastName = "Black"
                },
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "1099999003",
                    routingNum = "114567895"
                }
            });
            Assert.AreEqual("801", response.tokenResponse.tokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.tokenResponse.tokenMessage);
            Assert.AreEqual(methodOfPaymentTypeEnum.EC, response.tokenResponse.type);
            Assert.AreEqual("111922223333444003", response.tokenResponse.litleToken);
        }

        [Test]
        public void Test62()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "62",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    firstName = "Tom",
                    lastName = "Black"
                },
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "1099999999",
                    routingNum = "114567895"
                }
            });
            Assert.AreEqual("801", response.tokenResponse.tokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.tokenResponse.tokenMessage);
            Assert.AreEqual(methodOfPaymentTypeEnum.EC, response.tokenResponse.type);
            Assert.AreEqual("999", response.tokenResponse.eCheckAccountSuffix);
            Assert.AreEqual("111922223333444999", response.tokenResponse.litleToken);
        }

        [Test]
        public void Test63()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "63",
                amount = 15000,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    firstName = "Tom",
                    lastName = "Black"
                },
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "1099999999",
                    routingNum = "214567892"
                }
            });
            Assert.AreEqual("801", response.tokenResponse.tokenResponseCode);
            Assert.AreEqual("Account number was successfully registered", response.tokenResponse.tokenMessage);
            Assert.AreEqual(methodOfPaymentTypeEnum.EC, response.tokenResponse.type);
            Assert.AreEqual("999", response.tokenResponse.eCheckAccountSuffix);
            Assert.AreEqual("111922223333555999", response.tokenResponse.litleToken);
        }
    }
}
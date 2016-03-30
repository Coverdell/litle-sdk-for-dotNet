using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert3AuthReversal : LitleOnlineTestBase
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
        public void Test32()
        {
            var authorizeResponse = Litle.Authorize(new authorization
            {
                orderId = "32",
                amount = 10010,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "John Smith",
                    addressLine1 = "1 Main St.",
                    city = "Burlington",
                    state = "MA",
                    zip = "01803-3747",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    number = "4457010000000009",
                    expDate = "0112",
                    cardValidationNum = "349",
                    type = methodOfPaymentTypeEnum.VI
                }
            });
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("11111 ", authorizeResponse.authCode);
            Assert.AreEqual("01", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var captureResponse = Litle.Capture(new capture
            {
                litleTxnId = authorizeResponse.litleTxnId,
                amount = 5005
            });
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var reversalResponse = Litle.AuthReversal(new authReversal {litleTxnId = authorizeResponse.litleTxnId});
            Assert.AreEqual("111", reversalResponse.response);
            Assert.AreEqual("Authorization amount has already been depleted", reversalResponse.message);
        }

        [Test]
        public void Test33()
        {
            var authorizeResponse = Litle.Authorize(new authorization
            {
                orderId = "33",
                amount = 20020,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Mike J. Hammer",
                    addressLine1 = "2 Main St.",
                    addressLine2 = "Apt. 222",
                    city = "Riverside",
                    state = "RI",
                    zip = "02915",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    number = "5112010000000003",
                    expDate = "0212",
                    cardValidationNum = "261",
                    type = methodOfPaymentTypeEnum.MC
                },
                cardholderAuthentication = new fraudCheckType {authenticationValue = "BwABBJQ1AgAAAAAgJDUCAAAAAAA="}
            });
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("22222", authorizeResponse.authCode);
            Assert.AreEqual("10", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var reversalResponse = Litle.AuthReversal(new authReversal {litleTxnId = authorizeResponse.litleTxnId});
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void Test34()
        {
            var authorizeResponse = Litle.Authorize(new authorization
            {
                orderId = "34",
                amount = 30030,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Eileen Jones",
                    addressLine1 = "3 Main St.",
                    city = "Bloomfield",
                    state = "CT",
                    zip = "06002",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    number = "6011010000000003",
                    expDate = "0312",
                    cardValidationNum = "758",
                    type = methodOfPaymentTypeEnum.DI
                }
            });
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("33333", authorizeResponse.authCode);
            Assert.AreEqual("10", authorizeResponse.fraudResult.avsResult);
            Assert.AreEqual("M", authorizeResponse.fraudResult.cardValidationResult);

            var reversalResponse = Litle.AuthReversal(new authReversal {litleTxnId = authorizeResponse.litleTxnId});
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void Test35()
        {
            var authorizeResponse = Litle.Authorize(new authorization
            {
                orderId = "35",
                amount = 40040,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    name = "Bob Black",
                    addressLine1 = "4 Main St.",
                    city = "Laurel",
                    state = "MD",
                    zip = "20708",
                    country = countryTypeEnum.US
                },
                card = new cardType
                {
                    number = "375001000000005",
                    expDate = "0412",
                    type = methodOfPaymentTypeEnum.AX
                }
            });
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);
            Assert.AreEqual("44444", authorizeResponse.authCode);
            Assert.AreEqual("12", authorizeResponse.fraudResult.avsResult);

            var captureResponse = Litle.Capture(new capture
            {
                litleTxnId = authorizeResponse.litleTxnId,
                amount = 20020
            });
            Assert.AreEqual("000", captureResponse.response);
            Assert.AreEqual("Approved", captureResponse.message);

            var reversalResponse = Litle.AuthReversal(new authReversal
            {
                litleTxnId = authorizeResponse.litleTxnId,
                amount = 20020
            });
            Assert.AreEqual("000", reversalResponse.response);
            Assert.AreEqual("Approved", reversalResponse.message);
        }

        [Test]
        public void Test36()
        {
            var authorizeResponse = Litle.Authorize(new authorization
            {
                orderId = "36",
                amount = 20500,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    number = "375000026600004",
                    expDate = "0512",
                    type = methodOfPaymentTypeEnum.AX
                }
            });
            Assert.AreEqual("000", authorizeResponse.response);
            Assert.AreEqual("Approved", authorizeResponse.message);

            var reversalResponse = Litle.AuthReversal(new authReversal
            {
                litleTxnId = authorizeResponse.litleTxnId,
                amount = 10000
            });
            Assert.AreEqual("336", reversalResponse.response);
            Assert.AreEqual("Reversal Amount does not match Authorization amount", reversalResponse.message);
        }
    }
}
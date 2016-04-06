using System.Collections.Generic;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Certification
{
    [TestFixture]
    internal class TestCert4Echeck : LitleOnlineTestBase
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
        public void Test37()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                orderId = "37",
                amount = 3001,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Tom",
                    lastName = "Black"
                },
                echeck = new echeckType
                {
                    accNum = "10@BC99999",
                    accType = echeckAccountTypeEnum.Checking,
                    routingNum = "053100300"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void Test38()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                orderId = "38",
                amount = 3002,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "John",
                    lastName = "Smith",
                    phone = "999-999-9999"
                },
                echeck = new echeckType
                {
                    accNum = "1099999999",
                    accType = echeckAccountTypeEnum.Checking,
                    routingNum = "053000219"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test39()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                orderId = "39",
                amount = 3003,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Robert",
                    lastName = "Jones",
                    companyName = "Good Goods Inc",
                    phone = "9999999999"
                },
                echeck = new echeckType
                {
                    accNum = "3099999999",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "053100300"
                }
            });
            Assert.AreEqual("950", response.response);
            Assert.AreEqual("Declined - Negative Information on File", response.message);
        }

        [Test]
        public void Test40()
        {
            var response = Litle.EcheckVerification(new echeckVerification
            {
                orderId = "40",
                amount = 3004,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Peter",
                    lastName = "Green",
                    companyName = "Green Co",
                    phone = "9999999999"
                },
                echeck = new echeckType
                {
                    accNum = "8099999999",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "063102152"
                }
            });
            Assert.AreEqual("951", response.response);
            Assert.AreEqual("Absolute Decline", response.message);
        }

        [Test]
        public void Test41()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "41",
                amount = 2008,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Mike",
                    middleInitial = "J",
                    lastName = "Hammer"
                },
                echeck = new echeckType
                {
                    accNum = "10@BC99999",
                    accType = echeckAccountTypeEnum.Checking,
                    routingNum = "053100300"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void Test42()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "42",
                amount = 2004,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Tom",
                    lastName = "Black"
                },
                echeck = new echeckType
                {
                    accNum = "4099999992",
                    accType = echeckAccountTypeEnum.Checking,
                    routingNum = "211370545"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test43()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "43",
                amount = 2007,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Peter",
                    lastName = "Green",
                    companyName = "Green Co"
                },
                echeck = new echeckType
                {
                    accNum = "6099999992",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "211370545"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test44()
        {
            var response = Litle.EcheckSale(new echeckSale
            {
                orderId = "44",
                amount = 2009,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Peter",
                    lastName = "Green",
                    companyName = "Green Co"
                },
                echeck = new echeckType
                {
                    accNum = "9099999992",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "053133052"
                }
            });
            Assert.AreEqual("900", response.response);
            Assert.AreEqual("Invalid Bank Routing Number", response.message);
        }

        [Test]
        public void Test45()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                orderId = "45",
                amount = 1001,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "John",
                    lastName = "Smith"
                },
                echeck = new echeckType
                {
                    accNum = "10@BC99999",
                    accType = echeckAccountTypeEnum.Checking,
                    routingNum = "053100300"
                }
            });
            Assert.AreEqual("301", response.response);
            Assert.AreEqual("Invalid Account Number", response.message);
        }

        [Test]
        public void Test46()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                orderId = "46",
                amount = 1003,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Robert",
                    lastName = "Jones",
                    companyName = "Widget Inc"
                },
                echeck = new echeckType
                {
                    accNum = "3099999999",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "063102152"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test47()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                orderId = "47",
                amount = 1007,
                orderSource = orderSourceType.telephone,
                billToAddress = new contact
                {
                    firstName = "Peter",
                    lastName = "Green",
                    companyName = "Green Co"
                },
                echeck = new echeckType
                {
                    accNum = "6099999993",
                    accType = echeckAccountTypeEnum.Corporate,
                    routingNum = "211370545"
                }
            });
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test48()
        {
            var response = Litle.EcheckCredit(new echeckCredit {litleTxnId = 430000000000000001L});
            Assert.AreEqual("000", response.response);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void Test49()
        {
            var response = Litle.EcheckCredit(new echeckCredit {litleTxnId = 2L});
            Assert.AreEqual("360", response.response);
            Assert.AreEqual("No transaction found with specified litleTxnId", response.message);
        }
    }
}
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckCredit : LitleOnlineTestBase
    {
        [Test]
        public void SimpleEcheckCredit()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12L,
                litleTxnId = 123456789101112L
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void NoLitleTxnId()
        {
            try
            {
                Litle.EcheckCredit(new echeckCredit());
                Assert.Fail("Expected exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.IsTrue(e.Message.Contains("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void EcheckCreditWithEcheck()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12L,
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
                    city = "Lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void EcheckCreditWithToken()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12L,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeckToken = new echeckTokenType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    litleToken = "1234565789012",
                    routingNum = "123456789",
                    checkNum = "123455"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "Lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void MissingBilling()
        {
            try
            {
                Litle.EcheckCredit(new echeckCredit
                {
                    amount = 12L,
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
                Assert.Fail("Expected exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.IsTrue(e.Message.Contains("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void EcheckCreditWithSecondaryAmountWithOrderIdAndCcdPaymentInfo()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12L,
                secondaryAmount = 50,
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455",
                    ccdPaymentInformation = "9876554"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "Lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void EcheckCreditWithSecondaryAmountWithLitleTxnId()
        {
            var response = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12L,
                secondaryAmount = 50,
                litleTxnId = 12345L
            });
            Assert.AreEqual("Approved", response.message);
        }
    }
}
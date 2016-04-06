using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestSale : LitleOnlineTestBase
    {
        [Test]
        public void TestFraudFilterOverride()
        {
            SetupCommunications(".*<fraudFilterOverride>false</fraudFilterOverride>.*",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets",
                fraudFilterOverride = false
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount()
        {
            SetupCommunications(
                ".*<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                amount = 2,
                surchargeAmount = 1,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            SetupCommunications(".*<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestRecurringRequest()
        {
            SetupCommunications(
                ".*<fraudFilterOverride>true</fraudFilterOverride>\r\n<recurringRequest>\r\n<subscription>\r\n<planCode>abc123</planCode>\r\n<numberOfPayments>12</numberOfPayments>\r\n</subscription>\r\n</recurringRequest>.*",
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1213"
                },
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                fraudFilterOverride = true,
                recurringRequest = new recurringRequest
                {
                    subscription = new subscription
                    {
                        planCode = "abc123",
                        numberOfPayments = 12
                    }
                }
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestRecurringResponse_Full()
        {
            const string xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage><recurringTxnId>678</recurringTxnId></recurringResponse></saleResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var saleResponse = litleOnlineResponse.saleResponse;

            Assert.AreEqual(123, saleResponse.litleTxnId);
            Assert.AreEqual(12, saleResponse.recurringResponse.subscriptionId);
            Assert.AreEqual("345", saleResponse.recurringResponse.responseCode);
            Assert.AreEqual("Foo", saleResponse.recurringResponse.responseMessage);
            Assert.AreEqual(678, saleResponse.recurringResponse.recurringTxnId);
        }

        [Test]
        public void TestRecurringResponse_NoRecurringTxnId()
        {
            const string xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage></recurringResponse></saleResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var saleResponse = litleOnlineResponse.saleResponse;

            Assert.AreEqual(123, saleResponse.litleTxnId);
            Assert.AreEqual(12, saleResponse.recurringResponse.subscriptionId);
            Assert.AreEqual("345", saleResponse.recurringResponse.responseCode);
            Assert.AreEqual("Foo", saleResponse.recurringResponse.responseMessage);
            Assert.AreEqual(0, saleResponse.recurringResponse.recurringTxnId);
        }

        [Test]
        public void TestRecurringRequest_Optional()
        {
            SetupCommunications(".*<fraudFilterOverride>true</fraudFilterOverride>\r\n</sale>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1213"
                },
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                fraudFilterOverride = true
            });

            //TODO: Write assertions!
        }

        [Test]
        public void Test_LitleInternalRecurringRequest()
        {
            SetupCommunications(
                "<fraudFilterOverride>true</fraudFilterOverride>\r\n<litleInternalRecurringRequest>\r\n<subscriptionId>123</subscriptionId>\r\n<recurringTxnId>456</recurringTxnId>\r\n</litleInternalRecurringRequest>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1213"
                },
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                fraudFilterOverride = true,
                litleInternalRecurringRequest = new litleInternalRecurringRequest
                {
                    subscriptionId = "123",
                    recurringTxnId = "456"
                }
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            SetupCommunications(
                ".*</litleInternalRecurringRequest>\r\n<debtRepayment>true</debtRepayment>\r\n</sale>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                litleInternalRecurringRequest = new litleInternalRecurringRequest(),
                debtRepayment = true
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            SetupCommunications(
                ".*</litleInternalRecurringRequest>\r\n<debtRepayment>false</debtRepayment>\r\n</sale>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                litleInternalRecurringRequest = new litleInternalRecurringRequest(),
                debtRepayment = false
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            SetupCommunications(".*</litleInternalRecurringRequest>\r\n</sale>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale {litleInternalRecurringRequest = new litleInternalRecurringRequest()});

            //TODO: Write assertions!
        }

        [Test]
        public void TestSecondaryAmount()
        {
            SetupCommunications(
                ".*<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
                amount = 2,
                secondaryAmount = 1,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestApplepayAndWallet()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<sale.*?<applepay>.*?<data>user</data>.*?</applepay>.*?<walletSourceTypeId>123</walletSourceTypeId>.*?</wallet>.*?</sale>.*?",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            Litle.Sale(new sale
            {
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
                },
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                wallet = new wallet {walletSourceTypeId = "123"}
            });

            //TODO: Write assertions!
        }
    }
}
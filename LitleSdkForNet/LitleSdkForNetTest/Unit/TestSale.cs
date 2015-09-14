using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestSale : TestBase
    {
        [Test]
        public void TestFraudFilterOverride()
        {
            var sale = new Sale
            {
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets",
                FraudFilterOverride = false
            };

            const string value =
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<fraudFilterOverride>false</fraudFilterOverride>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var sale = new Sale
            {
                Amount = 2,
                SurchargeAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var sale = new Sale
            {
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestRecurringRequest()
        {
            var sale = new Sale
            {
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "4100000000000001",
                    ExpDate = "1213"
                },
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                FraudFilterOverride = true,
                RecurringRequest = new RecurringRequest
                {
                    Subscription = new Subscription
                    {
                        PlanCode = "abc123",
                        NumberOfPayments = 12
                    }
                }
            };

            const string value = "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "<recurringRequest>",
                "<subscription>",
                "<planCode>abc123</planCode>",
                "<numberOfPayments>12</numberOfPayments>",
                "</subscription>",
                "</recurringRequest>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestRecurringResponse_Full()
        {
            const string xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage><recurringTxnId>678</recurringTxnId></recurringResponse></saleResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var saleResponse = litleOnlineResponse.SaleResponse;

            Assert.AreEqual(123, saleResponse.LitleTxnId);
            Assert.AreEqual(12, saleResponse.RecurringResponse.SubscriptionId);
            Assert.AreEqual("345", saleResponse.RecurringResponse.ResponseCode);
            Assert.AreEqual("Foo", saleResponse.RecurringResponse.ResponseMessage);
            Assert.AreEqual(678, saleResponse.RecurringResponse.RecurringTxnId);
        }

        [Test]
        public void TestRecurringResponse_NoRecurringTxnId()
        {
            const string xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage></recurringResponse></saleResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var saleResponse = litleOnlineResponse.SaleResponse;

            Assert.AreEqual(123, saleResponse.LitleTxnId);
            Assert.AreEqual(12, saleResponse.RecurringResponse.SubscriptionId);
            Assert.AreEqual("345", saleResponse.RecurringResponse.ResponseCode);
            Assert.AreEqual("Foo", saleResponse.RecurringResponse.ResponseMessage);
            Assert.AreEqual(0, saleResponse.RecurringResponse.RecurringTxnId);
        }

        [Test]
        public void TestRecurringRequest_Optional()
        {
            var sale = new Sale
            {
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "4100000000000001",
                    ExpDate = "1213"
                },
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                FraudFilterOverride = true
            };

            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "</sale>");
            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void Test_LitleInternalRecurringRequest()
        {
            var sale = new Sale
            {
                Card = new CardType {Type = MethodOfPaymentTypeEnum.VI, Number = "4100000000000001", ExpDate = "1213"},
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                FraudFilterOverride = true,
                LitleInternalRecurringRequest = new LitleInternalRecurringRequest
                {
                    SubscriptionId = "123",
                    RecurringTxnId = "456"
                }
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "<litleInternalRecurringRequest>",
                "<subscriptionId>123</subscriptionId>",
                "<recurringTxnId>456</recurringTxnId>",
                "</litleInternalRecurringRequest>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        public void Test_LitleInternalRecurringRequest_Optional()
        {
            var sale = new Sale
            {
                Card = new CardType {Type = MethodOfPaymentTypeEnum.VI, Number = "4100000000000001", ExpDate = "1213"},
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                FraudFilterOverride = true
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "</sale>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            var sale = new Sale
            {
                LitleInternalRecurringRequest = new LitleInternalRecurringRequest(),
                DebtRepayment = true
            };

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "</litleInternalRecurringRequest>",
                "<debtRepayment>true</debtRepayment>",
                "</sale>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            var sale = new Sale
            {
                LitleInternalRecurringRequest = new LitleInternalRecurringRequest(),
                DebtRepayment = false
            };

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "</litleInternalRecurringRequest>",
                "<debtRepayment>false</debtRepayment>",
                "</sale>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            var sale = new Sale {LitleInternalRecurringRequest = new LitleInternalRecurringRequest()};

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "</litleInternalRecurringRequest>",
                "</sale>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestSecondaryAmount()
        {
            var sale = new Sale
            {
                Amount = 2,
                SecondaryAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }

        [Test]
        public void TestApplepayAndWallet()
        {
            var sale = new Sale
            {
                Applepay = new ApplepayType
                {
                    Header = new ApplepayHeaderType
                    {
                        ApplicationData = "454657413164",
                        EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        TransactionId = "1234"
                    },
                    Data = "user",
                    Signature = "sign",
                    Version = "1"
                },
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                Wallet = new Wallet {WalletSourceTypeId = "123"}
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<walletSourceTypeId>123</walletSourceTypeId>",
                "</wallet>",
                "</sale>");
            MockLitlePost(regex, value);
            Litle.Sale(sale);
        }
    }
}
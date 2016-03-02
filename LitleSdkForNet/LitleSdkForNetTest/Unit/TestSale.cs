using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestSale
    {
        private LitleOnline litle;
        private IDictionary<string, StringBuilder> _memoryStreams;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            _memoryStreams = new Dictionary<string, StringBuilder>();
            litle = new LitleOnline(_memoryStreams);
        }

        [Test]
        public void TestFraudFilterOverride()
        {
            var sale = new Sale();
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.reportGroup = "Planets";
            sale.FraudFilterOverride = false;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<fraudFilterOverride>false</fraudFilterOverride>.*", RegexOptions.Singleline),
                        It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var sale = new Sale();
            sale.Amount = 2;
            sale.SurchargeAmount = 1;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var sale = new Sale();
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestRecurringRequest()
        {
            var sale = new Sale();
            sale.Card = new CardType();
            sale.Card.Type = MethodOfPaymentTypeEnum.VI;
            sale.Card.Number = "4100000000000001";
            sale.Card.ExpDate = "1213";
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.FraudFilterOverride = true;
            sale.RecurringRequest = new RecurringRequest();
            sale.RecurringRequest.Subscription = new Subscription();
            sale.RecurringRequest.Subscription.PlanCode = "abc123";
            sale.RecurringRequest.Subscription.NumberOfPayments = 12;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<fraudFilterOverride>true</fraudFilterOverride>\r\n<recurringRequest>\r\n<subscription>\r\n<planCode>abc123</planCode>\r\n<numberOfPayments>12</numberOfPayments>\r\n</subscription>\r\n</recurringRequest>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestRecurringResponse_Full()
        {
            var xmlResponse =
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
            var xmlResponse =
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
            var sale = new Sale();
            sale.Card = new CardType();
            sale.Card.Type = MethodOfPaymentTypeEnum.VI;
            sale.Card.Number = "4100000000000001";
            sale.Card.ExpDate = "1213";
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.FraudFilterOverride = true;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<fraudFilterOverride>true</fraudFilterOverride>\r\n</sale>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void Test_LitleInternalRecurringRequest()
        {
            var sale = new Sale();
            sale.Card = new CardType();
            sale.Card.Type = MethodOfPaymentTypeEnum.VI;
            sale.Card.Number = "4100000000000001";
            sale.Card.ExpDate = "1213";
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.FraudFilterOverride = true;
            sale.LitleInternalRecurringRequest = new LitleInternalRecurringRequest();
            sale.LitleInternalRecurringRequest.SubscriptionId = "123";
            sale.LitleInternalRecurringRequest.RecurringTxnId = "456";

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            "<fraudFilterOverride>true</fraudFilterOverride>\r\n<litleInternalRecurringRequest>\r\n<subscriptionId>123</subscriptionId>\r\n<recurringTxnId>456</recurringTxnId>\r\n</litleInternalRecurringRequest>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        public void Test_LitleInternalRecurringRequest_Optional()
        {
            var sale = new Sale();
            sale.Card = new CardType();
            sale.Card.Type = MethodOfPaymentTypeEnum.VI;
            sale.Card.Number = "4100000000000001";
            sale.Card.ExpDate = "1213";
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.FraudFilterOverride = true;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<fraudFilterOverride>true</fraudFilterOverride>\r\n</sale>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            var sale = new Sale();
            sale.LitleInternalRecurringRequest = new LitleInternalRecurringRequest();
            sale.DebtRepayment = true;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*</litleInternalRecurringRequest>\r\n<debtRepayment>true</debtRepayment>\r\n</sale>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            var sale = new Sale();
            sale.LitleInternalRecurringRequest = new LitleInternalRecurringRequest();
            sale.DebtRepayment = false;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*</litleInternalRecurringRequest>\r\n<debtRepayment>false</debtRepayment>\r\n</sale>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            var sale = new Sale();
            sale.LitleInternalRecurringRequest = new LitleInternalRecurringRequest();

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*</litleInternalRecurringRequest>\r\n</sale>.*", RegexOptions.Singleline),
                        It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestSecondaryAmount()
        {
            var sale = new Sale();
            sale.Amount = 2;
            sale.SecondaryAmount = 1;
            sale.OrderSource = OrderSourceType.Ecommerce;
            sale.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }

        [Test]
        public void TestApplepayAndWallet()
        {
            var sale = new Sale();
            sale.Applepay = new ApplepayType();
            var applepayHeaderType = new ApplepayHeaderType();
            applepayHeaderType.ApplicationData = "454657413164";
            applepayHeaderType.EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.TransactionId = "1234";
            sale.Applepay.Header = applepayHeaderType;
            sale.Applepay.Data = "user";
            sale.Applepay.Signature = "sign";
            sale.Applepay.Version = "1";
            sale.OrderId = "12344";
            sale.Amount = 2;
            sale.OrderSource = OrderSourceType.Ecommerce;
            var wallet = new Wallet();
            wallet.WalletSourceTypeId = "123";
            sale.Wallet = wallet;

            var mock = new Mock<Communications>(_memoryStreams);
            ;

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*?<litleOnlineRequest.*?<sale.*?<applepay>.*?<data>user</data>.*?</applepay>.*?<walletSourceTypeId>123</walletSourceTypeId>.*?</wallet>.*?</sale>.*?",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Sale(sale);
        }
    }
}

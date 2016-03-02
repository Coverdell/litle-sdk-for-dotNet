using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestAuthorization
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
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";
            auth.FraudFilterOverride = true;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<fraudFilterOverride>true</fraudFilterOverride>.*", RegexOptions.Singleline),
                        It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestContactShouldSendEmailForEmail_NotZip()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";
            var billToAddress = new Contact();
            billToAddress.Email = "gdake@litle.com";
            billToAddress.Zip = "12345";
            auth.BillToAddress = billToAddress;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<zip>12345</zip>.*<email>gdake@litle.com</email>.*", RegexOptions.Singleline),
                        It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void Test3dsAttemptedShouldNotSayItem()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Item3DsAttempted;
            auth.reportGroup = "Planets";
            var billToAddress = new Contact();
            billToAddress.Email = "gdake@litle.com";
            billToAddress.Zip = "12345";
            auth.BillToAddress = billToAddress;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<amount>2</amount>.*<orderSource>3dsAttempted</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void Test3dsAuthenticatedShouldNotSayItem()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Item3DsAuthenticated;
            auth.reportGroup = "Planets";
            var billToAddress = new Contact();
            billToAddress.Email = "gdake@litle.com";
            billToAddress.Zip = "12345";
            auth.BillToAddress = billToAddress;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<amount>2</amount>.*<orderSource>3dsAuthenticated</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestSecondaryAmount()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.SecondaryAmount = 1;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.SurchargeAmount = 1;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestMethodOfPaymentAllowsGiftCard()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.reportGroup = "Planets";
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.GC;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            auth.Card = card;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<card>\r\n<type>GC</type>\r\n<number>414100000000000000</number>\r\n<expDate>1210</expDate>\r\n</card>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestMethodOfPaymentApplepayAndWallet()
        {
            var auth = new Authorization();
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Applepay;
            auth.reportGroup = "Planets";
            var applepay = new ApplepayType();
            var applepayHeaderType = new ApplepayHeaderType();
            applepayHeaderType.ApplicationData = "454657413164";
            applepayHeaderType.EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.TransactionId = "1234";
            applepay.Header = applepayHeaderType;
            applepay.Data = "user";
            applepay.Signature = "sign";
            applepay.Version = "1";
            auth.Applepay = applepay;

            var wallet = new Wallet();
            wallet.WalletSourceTypeId = "123";
            auth.Wallet = wallet;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*?<litleOnlineRequest.*?<authorization.*?<orderSource>applepay</orderSource>.*?<applepay>.*?<data>user</data>.*?</applepay>.*?<wallet>.*?<walletSourceTypeId>123</walletSourceTypeId>.*?</wallet>.*?</authorization>.*?",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestRecurringRequest()
        {
            var auth = new Authorization();
            auth.Card = new CardType();
            auth.Card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card.Number = "4100000000000001";
            auth.Card.ExpDate = "1213";
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.FraudFilterOverride = true;
            auth.RecurringRequest = new RecurringRequest();
            auth.RecurringRequest.Subscription = new Subscription();
            auth.RecurringRequest.Subscription.PlanCode = "abc123";
            auth.RecurringRequest.Subscription.NumberOfPayments = 12;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<fraudFilterOverride>true</fraudFilterOverride>\r\n<recurringRequest>\r\n<subscription>\r\n<planCode>abc123</planCode>\r\n<numberOfPayments>12</numberOfPayments>\r\n</subscription>\r\n</recurringRequest>\r\n</authorization>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestDebtRepayment()
        {
            var auth = new Authorization();
            auth.Card = new CardType();
            auth.Card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card.Number = "4100000000000001";
            auth.Card.ExpDate = "1213";
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.FraudFilterOverride = true;
            auth.DebtRepayment = true;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<fraudFilterOverride>true</fraudFilterOverride>\r\n<debtRepayment>true</debtRepayment>\r\n</authorization>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestRecurringResponse_Full()
        {
            var xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage><recurringTxnId>678</recurringTxnId></recurringResponse></authorizationResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.authorizationResponse;

            Assert.AreEqual(123, authorizationResponse.litleTxnId);
            Assert.AreEqual(12, authorizationResponse.recurringResponse.subscriptionId);
            Assert.AreEqual("345", authorizationResponse.recurringResponse.responseCode);
            Assert.AreEqual("Foo", authorizationResponse.recurringResponse.responseMessage);
            Assert.AreEqual(678, authorizationResponse.recurringResponse.recurringTxnId);
        }

        [Test]
        public void TestRecurringResponse_NoRecurringTxnId()
        {
            var xmlResponse =
                "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage></recurringResponse></authorizationResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.authorizationResponse;

            Assert.AreEqual(123, authorizationResponse.litleTxnId);
            Assert.AreEqual(12, authorizationResponse.recurringResponse.subscriptionId);
            Assert.AreEqual("345", authorizationResponse.recurringResponse.responseCode);
            Assert.AreEqual("Foo", authorizationResponse.recurringResponse.responseMessage);
            Assert.AreEqual(0, authorizationResponse.recurringResponse.recurringTxnId);
        }

        [Test]
        public void TestSimpleAuthWithFraudCheck()
        {
            var auth = new Authorization();
            auth.Card = new CardType();
            auth.Card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card.Number = "4100000000000001";
            auth.Card.ExpDate = "1213";
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.CardholderAuthentication = new FraudCheckType();
            auth.CardholderAuthentication.CustomerIpAddress = "192.168.1.1";

            var expectedResult = @"
<authorization id="""" reportGroup="""">
<orderId>12344</orderId>
<amount>2</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>VI</type>
<number>4100000000000001</number>
<expDate>1213</expDate>
</card>
<cardholderAuthentication>
<customerIpAddress>192.168.1.1</customerIpAddress>
</cardholderAuthentication>
</authorization>";

            Assert.AreEqual(expectedResult, auth.Serialize());

            var mock = new Mock<Communications>(_memoryStreams);
            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<authorization id=\".*>.*<customerIpAddress>192.168.1.1</customerIpAddress>.*</authorization>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Authorize(auth);

            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestSimpleAuthWithBillMeLaterRequest()
        {
            var auth = new Authorization();
            auth.Card = new CardType();
            auth.Card.Type = MethodOfPaymentTypeEnum.VI;
            auth.Card.Number = "4100000000000001";
            auth.Card.ExpDate = "1213";
            auth.OrderId = "12344";
            auth.Amount = 2;
            auth.OrderSource = OrderSourceType.Ecommerce;
            auth.BillMeLaterRequest = new BillMeLaterRequest();
            auth.BillMeLaterRequest.VirtualAuthenticationKeyData = "Data";
            auth.BillMeLaterRequest.VirtualAuthenticationKeyPresenceIndicator = "Presence";

            var expectedResult = @"
<authorization id="""" reportGroup="""">
<orderId>12344</orderId>
<amount>2</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>VI</type>
<number>4100000000000001</number>
<expDate>1213</expDate>
</card>
<billMeLaterRequest>
<virtualAuthenticationKeyPresenceIndicator>Presence</virtualAuthenticationKeyPresenceIndicator>
<virtualAuthenticationKeyData>Data</virtualAuthenticationKeyData>
</billMeLaterRequest>
</authorization>";

            Assert.AreEqual(expectedResult, auth.Serialize());

            var mock = new Mock<Communications>(_memoryStreams);
            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<authorization id=\".*>.*<billMeLaterRequest>\r\n<virtualAuthenticationKeyPresenceIndicator>Presence</virtualAuthenticationKeyPresenceIndicator>\r\n<virtualAuthenticationKeyData>Data</virtualAuthenticationKeyData>\r\n</billMeLaterRequest>.*</authorization>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.Authorize(auth);

            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestAuthWithAdvancedFraud()
        {
            var auth = new Authorization();
            auth.OrderId = "123";
            auth.Amount = 10;
            auth.AdvancedFraudChecks = new AdvancedFraudChecksType();
            auth.AdvancedFraudChecks.ThreatMetrixSessionId = "800";
            auth.AdvancedFraudChecks.CustomAttribute1 = "testAttribute1";
            auth.AdvancedFraudChecks.CustomAttribute2 = "testAttribute2";
            auth.AdvancedFraudChecks.CustomAttribute3 = "testAttribute3";
            auth.AdvancedFraudChecks.CustomAttribute4 = "testAttribute4";
            auth.AdvancedFraudChecks.CustomAttribute5 = "testAttribute5";


            var expectedResult = @"
<authorization id="""" reportGroup="""">
<orderId>123</orderId>
<amount>10</amount>
<advancedFraudChecks>
<threatMetrixSessionId>800</threatMetrixSessionId>
<customAttribute1>testAttribute1</customAttribute1>
<customAttribute2>testAttribute2</customAttribute2>
<customAttribute3>testAttribute3</customAttribute3>
<customAttribute4>testAttribute4</customAttribute4>
<customAttribute5>testAttribute5</customAttribute5>
</advancedFraudChecks>
</authorization>";
            var test = auth.Serialize();
            Assert.AreEqual(expectedResult, auth.Serialize());

            var mock = new Mock<Communications>(_memoryStreams);
            mock.Setup(
                Communications => Communications.HttpPost(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.23' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><orderId>123</orderId><fraudResult><advancedFraudResults><deviceReviewStatus>\"ReviewStatus\"</deviceReviewStatus><deviceReputationScore>800</deviceReputationScore></advancedFraudResults></fraudResult></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual("123", authorizationResponse.orderId);
        }

        [Test]
        public void TestAdvancedFraudResponse()
        {
            var xmlResponse =
                @"<litleOnlineResponse version='8.23' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
<authorizationResponse>
<litleTxnId>123</litleTxnId>
<fraudResult>
<advancedFraudResults>
<deviceReviewStatus>ReviewStatus</deviceReviewStatus>
<deviceReputationScore>800</deviceReputationScore>
<triggeredRule>rule triggered</triggeredRule>
</advancedFraudResults>
</fraudResult>
</authorizationResponse>
</litleOnlineResponse>";

            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.authorizationResponse;


            Assert.AreEqual(123, authorizationResponse.litleTxnId);
            Assert.NotNull(authorizationResponse.fraudResult);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults.deviceReviewStatus);
            Assert.AreEqual("ReviewStatus", authorizationResponse.fraudResult.advancedFraudResults.deviceReviewStatus);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults.deviceReputationScore);
            Assert.AreEqual(800, authorizationResponse.fraudResult.advancedFraudResults.deviceReputationScore);
            Assert.AreEqual("rule triggered", authorizationResponse.fraudResult.advancedFraudResults.triggeredRule);
        }

        [Test]
        public void TestAuthWithPosCatLevelEnum()
        {
            var auth = new Authorization();
            auth.Pos = new Pos();
            auth.OrderId = "ABC123";
            auth.Amount = 98700;
            auth.Pos.CatLevel = posCatLevelEnum.selfservice;

            var expectedResult = @"
<authorization id="""" reportGroup="""">
<orderId>ABC123</orderId>
<amount>98700</amount>
<pos>
<catLevel>self service</catLevel>
</pos>
</authorization>";

            Assert.AreEqual(expectedResult, auth.Serialize());

            var mock = new Mock<Communications>(_memoryStreams);
            mock.Setup(
                Communications => Communications.HttpPost(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.23' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            var authorizationResponse = litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.litleTxnId);
        }

        [Test]
        public void TestRecycleEngineActive()
        {
            var xmlResponse =
                @"<litleOnlineResponse version='8.23' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
<authorizationResponse>
<litleTxnId>123</litleTxnId>
<fraudResult>
<advancedFraudResults>
<deviceReviewStatus>ReviewStatus</deviceReviewStatus>
<deviceReputationScore>800</deviceReputationScore>
<triggeredRule>rule triggered</triggeredRule>
</advancedFraudResults>
</fraudResult>
<recycling>
<recycleEngineActive>1</recycleEngineActive>
</recycling>
</authorizationResponse>
</litleOnlineResponse>";

            var litleOnlineResponse = LitleOnline.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.authorizationResponse;


            Assert.AreEqual(123, authorizationResponse.litleTxnId);
            Assert.NotNull(authorizationResponse.fraudResult);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults.deviceReviewStatus);
            Assert.AreEqual("ReviewStatus", authorizationResponse.fraudResult.advancedFraudResults.deviceReviewStatus);
            Assert.NotNull(authorizationResponse.fraudResult.advancedFraudResults.deviceReputationScore);
            Assert.AreEqual(800, authorizationResponse.fraudResult.advancedFraudResults.deviceReputationScore);
            Assert.AreEqual("rule triggered", authorizationResponse.fraudResult.advancedFraudResults.triggeredRule);
            Assert.AreEqual(true, authorizationResponse.recycling.recycleEngineActive);
        }
    }
}

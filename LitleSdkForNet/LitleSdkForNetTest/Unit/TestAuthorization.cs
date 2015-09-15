using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestAuthorization : TestBase
    {
        #region Setup
        private const string ValidResponse = @"
            <litleOnlineResponse version='8.10' response='0' message='Valid Format' 
                                    xmlns='http://www.litle.com/schema'>
                <authorizationResponse>
                    <litleTxnId>123</litleTxnId>
                </authorizationResponse>
            </litleOnlineResponse>";
        
        private static AdvancedFraudChecksType MakeAdvancedFraudChecksType()
        {
            return new AdvancedFraudChecksType
            {
                ThreatMetrixSessionId = "800",
                CustomAttribute1 = "testAttribute1",
                CustomAttribute2 = "testAttribute2",
                CustomAttribute3 = "testAttribute3",
                CustomAttribute4 = "testAttribute4",
                CustomAttribute5 = "testAttribute5"
            };
        }

        private static BillMeLaterRequest MakeBillMeLaterRequest()
        {
            return new BillMeLaterRequest
            {
                VirtualAuthenticationKeyData = "Data",
                VirtualAuthenticationKeyPresenceIndicator = "Presence"
            };
        }

        private static FraudCheckType MakeFraudCheckType()
        {
            return new FraudCheckType { CustomerIpAddress = "192.168.1.1" };
        }

        private static CardType MakeCardType(
            MethodOfPaymentTypeEnum type = MethodOfPaymentTypeEnum.VI,
            string number = "414100000000000001",
            string expDate = "1213")
        {
            return new CardType
            {
                Type = type,
                Number = number,
                ExpDate = expDate
            };
        }

        private static RecurringRequest MakeRecurringRequest()
        {
            return new RecurringRequest
            {
                Subscription = MakeSubscription()
            };
        }

        private static Subscription MakeSubscription()
        {
            return new Subscription { PlanCode = "abc123", NumberOfPayments = 12 };
        }

        private static Wallet MakeWallet()
        {
            return new Wallet { WalletSourceTypeId = "123" };
        }

        private static ApplepayType MakeApplepayType()
        {
            return new ApplepayType
            {
                Header = MakeApplepayHeaderType(),
                Data = "user",
                Signature = "sign",
                Version = "1"
            };
        }

        private static ApplepayHeaderType MakeApplepayHeaderType()
        {
            return new ApplepayHeaderType
            {
                ApplicationData = "454657413164",
                EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                TransactionId = "1234"
            };
        }

        private static Contact MakeContact()
        {
            return new Contact
            {
                Email = "gdake@litle.com",
                Zip = "12345"
            };
        }

        private static Authorization MakeAuthRequest(
            bool? fraudFilterOverride = null,
            Contact billToAddress = null,
            OrderSourceType orderSource = OrderSourceType.Ecommerce,
            long? secondaryAmount = null,
            long? surchargeAmount = null,
            CardType card = null,
            ApplepayType applepay = null,
            Wallet wallet = null,
            RecurringRequest recurringRequest = null,
            bool? debtRepayment = null,
            FraudCheckType cardholderAuthentication = null,
            BillMeLaterRequest billMeLaterRequest = null
            )
        {
            return new Authorization
            {
                OrderId = "12344",
                Amount = 2,
                OrderSource = orderSource,
                ReportGroup = "Planets",
                FraudFilterOverride = fraudFilterOverride,
                BillToAddress = billToAddress,
                SecondaryAmount = secondaryAmount,
                SurchargeAmount = surchargeAmount,
                Card = card,
                Applepay = applepay,
                Wallet = wallet,
                RecurringRequest = recurringRequest,
                DebtRepayment = debtRepayment,
                CardholderAuthentication = cardholderAuthentication,
                BillMeLaterRequest = billMeLaterRequest
            };
        }

        private void MockAuthorizeAndAssert(string regex, Authorization auth)
        {
            MockLitlePost(regex, ValidResponse);
            var authorizationResponse = Litle.Authorize(auth);

            Assert.NotNull(authorizationResponse);
            Assert.AreEqual(123, authorizationResponse.LitleTxnId);
        }
        #endregion Setup

        [Test]
        public void TestFraudFilterOverride()
        {
            var auth = MakeAuthRequest(true);
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestContactShouldSendEmailForEmail_NotZip()
        {
            var auth = MakeAuthRequest(billToAddress: MakeContact());
            var regex = FormMatchExpression(
                "<zip>12345</zip>",
                "<email>gdake@litle.com</email>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void Test3DsAttemptedShouldNotSayItem()
        {
            var auth = MakeAuthRequest(
                billToAddress: MakeContact(),
                orderSource: OrderSourceType.Item3DsAttempted);
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>3dsAttempted</orderSource>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void Test3DsAuthenticatedShouldNotSayItem()
        {
            var auth = MakeAuthRequest(
                billToAddress: MakeContact(),
                orderSource: OrderSourceType.Item3DsAuthenticated);
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>3dsAuthenticated</orderSource>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestSecondaryAmount()
        {
            var auth = MakeAuthRequest(secondaryAmount: 1);
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var auth = MakeAuthRequest(surchargeAmount: 1);
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var auth = MakeAuthRequest();
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestMethodOfPaymentAllowsGiftCard()
        {
            var auth = MakeAuthRequest(
                card: MakeCardType(
                    MethodOfPaymentTypeEnum.GC,
                    "414100000000000000",
                    "1210"));
            var regex = FormMatchExpression(
                "<card>",
                "<type>GC</type>",
                "<number>414100000000000000</number>",
                "<expDate>1210</expDate>",
                "</card>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestMethodOfPaymentApplepayAndWallet()
        {
            var auth = MakeAuthRequest(
                orderSource: OrderSourceType.Applepay,
                applepay: MakeApplepayType(),
                wallet: MakeWallet());
            var regex = FormMatchExpression(
                "<orderSource>applepay</orderSource>",
                "<applepay>",
                "<data>user</data>",
                "</applepay>",
                "<wallet>",
                "<walletSourceTypeId>123</walletSourceTypeId>",
                "</wallet>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestRecurringRequest()
        {
            var auth = MakeAuthRequest(
                card: MakeCardType(),
                fraudFilterOverride: true,
                recurringRequest: MakeRecurringRequest());
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "<recurringRequest>",
                "<subscription>",
                "<planCode>abc123</planCode>",
                "<numberOfPayments>12</numberOfPayments>",
                "</subscription>",
                "</recurringRequest>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestDebtRepayment()
        {
            var auth = MakeAuthRequest(
                card: MakeCardType(),
                fraudFilterOverride: true,
                debtRepayment: true);
            var regex = FormMatchExpression(
                "<fraudFilterOverride>true</fraudFilterOverride>",
                "<debtRepayment>true</debtRepayment>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestRecurringResponse_Full()
        {
            const string xmlResponse = "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage><recurringTxnId>678</recurringTxnId></recurringResponse></authorizationResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.AuthorizationResponse;

            Assert.AreEqual(123, authorizationResponse.LitleTxnId);
            Assert.AreEqual(12, authorizationResponse.RecurringResponse.SubscriptionId);
            Assert.AreEqual("345", authorizationResponse.RecurringResponse.ResponseCode);
            Assert.AreEqual("Foo", authorizationResponse.RecurringResponse.ResponseMessage);
            Assert.AreEqual(678, authorizationResponse.RecurringResponse.RecurringTxnId);
        }

        [Test]
        public void TestRecurringResponse_NoRecurringTxnId()
        {
            const string xmlResponse = "<litleOnlineResponse version='8.18' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId><recurringResponse><subscriptionId>12</subscriptionId><responseCode>345</responseCode><responseMessage>Foo</responseMessage></recurringResponse></authorizationResponse></litleOnlineResponse>";
            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.AuthorizationResponse;

            Assert.AreEqual(123, authorizationResponse.LitleTxnId);
            Assert.AreEqual(12, authorizationResponse.RecurringResponse.SubscriptionId);
            Assert.AreEqual("345", authorizationResponse.RecurringResponse.ResponseCode);
            Assert.AreEqual("Foo", authorizationResponse.RecurringResponse.ResponseMessage);
            Assert.AreEqual(0, authorizationResponse.RecurringResponse.RecurringTxnId);
        }

        [Test]
        public void TestSimpleAuthWithFraudCheck()
        {
            var auth = MakeAuthRequest(
                cardholderAuthentication: MakeFraudCheckType());

            var regex = FormMatchExpression(
                @"<authorization .*?>",
                    "<orderId>12344</orderId>",
                    "<amount>2</amount>",
                    "<orderSource>ecommerce</orderSource>",
                    "<cardholderAuthentication>",
                        "<customerIpAddress>192.168.1.1</customerIpAddress>",
                    "</cardholderAuthentication>",
                "</authorization>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestSimpleAuthWithBillMeLaterRequest()
        {
            var auth = MakeAuthRequest(
                billMeLaterRequest: MakeBillMeLaterRequest());
            var regex = FormMatchExpression(
                @"<authorization .*?>",
                "<orderId>12344</orderId>",
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>",
                "<billMeLaterRequest>",
                "<virtualAuthenticationKeyPresenceIndicator>Presence</virtualAuthenticationKeyPresenceIndicator>",
                "<virtualAuthenticationKeyData>Data</virtualAuthenticationKeyData>",
                "</billMeLaterRequest>",
                "</authorization>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestAuthWithAdvancedFraud()
        {
            var auth = new Authorization
            {
                OrderId = "123",
                Amount = 10,
                AdvancedFraudChecks = MakeAdvancedFraudChecksType()
            };
            var regex = FormMatchExpression(
                @"<authorization .*?>",
                "<orderId>123</orderId>",
                "<amount>10</amount>",
                "<advancedFraudChecks>",
                "<threatMetrixSessionId>800</threatMetrixSessionId>",
                "<customAttribute1>testAttribute1</customAttribute1>",
                "<customAttribute2>testAttribute2</customAttribute2>",
                "<customAttribute3>testAttribute3</customAttribute3>",
                "<customAttribute4>testAttribute4</customAttribute4>",
                "<customAttribute5>testAttribute5</customAttribute5>",
                "</advancedFraudChecks>",
                "</authorization>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestAdvancedFraudResponse()
        {
            const string xmlResponse =
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

            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.AuthorizationResponse;
            
            Assert.AreEqual(123, authorizationResponse.LitleTxnId);
            Assert.NotNull(authorizationResponse.FraudResult);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReviewStatus);
            Assert.AreEqual("ReviewStatus", authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReviewStatus);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReputationScore);
            Assert.AreEqual(800, authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReputationScore);
            Assert.AreEqual("rule triggered", authorizationResponse.FraudResult.AdvancedFraudResults.TriggeredRule);
        }

        [Test]
        public void TestAuthWithPosCatLevelEnum()
        {
            var auth = new Authorization
            {
                OrderId = "ABC123", 
                Amount = 98700,
                Pos = new Pos
                {
                    CatLevel = PosCatLevelEnum.Selfservice
                }
            };

            var regex = FormMatchExpression(
                @"<authorization .*?>",
                "<orderId>ABC123</orderId>",
                "<amount>98700</amount>",
                "<pos>",
                "<catLevel>self service</catLevel>",
                "</pos>",
                "</authorization>");
            MockAuthorizeAndAssert(regex, auth);
        }

        [Test]
        public void TestRecycleEngineActive()
        {
            const string xmlResponse = 
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

            var litleOnlineResponse = LitleXmlSerializer.DeserializeObject(xmlResponse);
            var authorizationResponse = litleOnlineResponse.AuthorizationResponse;
            
            Assert.AreEqual(123, authorizationResponse.LitleTxnId);
            Assert.NotNull(authorizationResponse.FraudResult);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReviewStatus);
            Assert.AreEqual("ReviewStatus", authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReviewStatus);
            Assert.NotNull(authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReputationScore);
            Assert.AreEqual(800, authorizationResponse.FraudResult.AdvancedFraudResults.DeviceReputationScore);
            Assert.AreEqual("rule triggered", authorizationResponse.FraudResult.AdvancedFraudResults.TriggeredRule);
            Assert.AreEqual(true, authorizationResponse.Recycling.RecycleEngineActive);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestXmlFieldsSerializer
    {

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
        }

        [Test]
        public void TestRecurringRequest_Full()
        {
            RecurringRequest request = new RecurringRequest();
            request.Subscription = new Subscription();
            request.Subscription.PlanCode = "123abc";
            request.Subscription.NumberOfPayments = 10;
            request.Subscription.StartDate = new DateTime(2013, 7, 25);
            request.Subscription.Amount = 102;

            String xml = request.Serialize();
            System.Text.RegularExpressions.Match match = Regex.Match(xml,"<subscription>\r\n<planCode>123abc</planCode>\r\n<numberOfPayments>10</numberOfPayments>\r\n<startDate>2013-07-25</startDate>\r\n<amount>102</amount>\r\n</subscription>");
            Assert.IsTrue(match.Success, xml);
        }

        [Test]
        public void TestRecurringRequest_OnlyRequired()
        {
            RecurringRequest request = new RecurringRequest();
            request.Subscription = new Subscription();
            request.Subscription.PlanCode = "123abc";

            String xml = request.Serialize();
            System.Text.RegularExpressions.Match match = Regex.Match(xml, "<subscription>\r\n<planCode>123abc</planCode>\r\n</subscription>");
            Assert.IsTrue(match.Success, xml);
        }

        [Test]
        public void TestSubscription_CanContainCreateDiscounts()
        {
            Subscription subscription = new Subscription();
            subscription.PlanCode = "123abc";

            CreateDiscount cd1 = new CreateDiscount();
            cd1.DiscountCode = "1";
            cd1.Name = "cheaper";
            cd1.Amount = 200;
            cd1.StartDate = new DateTime(2013, 9, 5);
            cd1.EndDate = new DateTime(2013, 9, 6);

            CreateDiscount cd2 = new CreateDiscount();
            cd2.DiscountCode = "2";
            cd2.Name = "cheap";
            cd2.Amount = 100;
            cd2.StartDate = new DateTime(2013, 9, 3);
            cd2.EndDate = new DateTime(2013, 9, 4);

            subscription.CreateDiscounts.Add(cd1);
            subscription.CreateDiscounts.Add(cd2);

            String actual = subscription.Serialize();
            String expected = @"
<planCode>123abc</planCode>
<createDiscount>
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</createDiscount>
<createDiscount>
<discountCode>2</discountCode>
<name>cheap</name>
<amount>100</amount>
<startDate>2013-09-03</startDate>
<endDate>2013-09-04</endDate>
</createDiscount>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSubscription_CanContainCreateAddOns()
        {
            Subscription subscription = new Subscription();
            subscription.PlanCode = "123abc";

            CreateAddOn cao1 = new CreateAddOn();
            cao1.AddOnCode = "1";
            cao1.Name = "addOn1";
            cao1.Amount = 100;
            cao1.StartDate = new DateTime(2013, 9, 5);
            cao1.EndDate = new DateTime(2013, 9, 6);

            CreateAddOn cao2 = new CreateAddOn();
            cao2.AddOnCode = "2";
            cao2.Name = "addOn2";
            cao2.Amount = 200;
            cao2.StartDate = new DateTime(2013, 9, 4);
            cao2.EndDate = new DateTime(2013, 9, 5);

            subscription.CreateAddOns.Add(cao1);
            subscription.CreateAddOns.Add(cao2);

            String actual = subscription.Serialize();
            String expected = @"
<planCode>123abc</planCode>
<createAddOn>
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</createAddOn>
<createAddOn>
<addOnCode>2</addOnCode>
<name>addOn2</name>
<amount>200</amount>
<startDate>2013-09-04</startDate>
<endDate>2013-09-05</endDate>
</createAddOn>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateSubscription_Full()
        {
            UpdateSubscription update = new UpdateSubscription();
            update.BillingDate = new DateTime(2002, 10, 9);
            Contact billToAddress = new Contact();
            billToAddress.Name = "Greg Dake";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "sdksupport@litle.com";
            update.BillToAddress = billToAddress;
            CardType card = new CardType();
            card.Number = "4100000000000001";
            card.ExpDate = "1215";
            card.Type = MethodOfPaymentTypeEnum.VI;
            update.Card = card;
            update.PlanCode = "abcdefg";
            update.SubscriptionId = 12345;

            String actual = update.Serialize();
            String expected = "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n<planCode>abcdefg</planCode>\r\n<billToAddress>\r\n<name>Greg Dake</name>\r\n<city>Lowell</city>\r\n<state>MA</state>\r\n<email>sdksupport@litle.com</email>\r\n</billToAddress>\r\n<card>\r\n<type>VI</type>\r\n<number>4100000000000001</number>\r\n<expDate>1215</expDate>\r\n</card>\r\n<billingDate>2002-10-09</billingDate>\r\n</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_OnlyRequired()
        {
            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 12345;

            String actual = update.Serialize();
            String expected = "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainCreateDiscounts()
        {
            CreateDiscount cd1 = new CreateDiscount();
            cd1.DiscountCode = "1";
            cd1.Name = "cheaper";
            cd1.Amount = 200;
            cd1.StartDate = new DateTime(2013, 9, 5);
            cd1.EndDate = new DateTime(2013, 9, 6);

            CreateDiscount cd2 = new CreateDiscount();
            cd2.DiscountCode = "2";
            cd2.Name = "cheap";
            cd2.Amount = 100;
            cd2.StartDate = new DateTime(2013, 9, 3);
            cd2.EndDate = new DateTime(2013, 9, 4);

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.CreateDiscounts.Add(cd1);
            update.CreateDiscounts.Add(cd2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<createDiscount>
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</createDiscount>
<createDiscount>
<discountCode>2</discountCode>
<name>cheap</name>
<amount>100</amount>
<startDate>2013-09-03</startDate>
<endDate>2013-09-04</endDate>
</createDiscount>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainUpdateDiscounts()
        {
            UpdateDiscount ud1 = new UpdateDiscount();
            ud1.DiscountCode = "1";
            ud1.Name = "cheaper";
            ud1.Amount = 200;
            ud1.StartDate = new DateTime(2013, 9, 5);
            ud1.EndDate = new DateTime(2013, 9, 6);

            UpdateDiscount ud2 = new UpdateDiscount();
            ud2.DiscountCode = "2";
            ud2.Name = "cheap";
            ud2.Amount = 100;
            ud2.StartDate = new DateTime(2013, 9, 3);
            ud2.EndDate = new DateTime(2013, 9, 4);

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.UpdateDiscounts.Add(ud1);
            update.UpdateDiscounts.Add(ud2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<updateDiscount>
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</updateDiscount>
<updateDiscount>
<discountCode>2</discountCode>
<name>cheap</name>
<amount>100</amount>
<startDate>2013-09-03</startDate>
<endDate>2013-09-04</endDate>
</updateDiscount>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainDeleteDiscounts()
        {
            DeleteDiscount dd1 = new DeleteDiscount();
            dd1.DiscountCode = "1";

            DeleteDiscount dd2 = new DeleteDiscount();
            dd2.DiscountCode = "2";

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.DeleteDiscounts.Add(dd1);
            update.DeleteDiscounts.Add(dd2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<deleteDiscount>
<discountCode>1</discountCode>
</deleteDiscount>
<deleteDiscount>
<discountCode>2</discountCode>
</deleteDiscount>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainCreateAddOns()
        {
            CreateAddOn cao1 = new CreateAddOn();
            cao1.AddOnCode = "1";
            cao1.Name = "addOn1";
            cao1.Amount = 100;
            cao1.StartDate = new DateTime(2013, 9, 5);
            cao1.EndDate = new DateTime(2013, 9, 6);

            CreateAddOn cao2 = new CreateAddOn();
            cao2.AddOnCode = "2";
            cao2.Name = "addOn2";
            cao2.Amount = 200;
            cao2.StartDate = new DateTime(2013, 9, 4);
            cao2.EndDate = new DateTime(2013, 9, 5);

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.CreateAddOns.Add(cao1);
            update.CreateAddOns.Add(cao2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<createAddOn>
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</createAddOn>
<createAddOn>
<addOnCode>2</addOnCode>
<name>addOn2</name>
<amount>200</amount>
<startDate>2013-09-04</startDate>
<endDate>2013-09-05</endDate>
</createAddOn>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainUpdateAddOns()
        {
            UpdateAddOn uao1 = new UpdateAddOn();
            uao1.AddOnCode = "1";
            uao1.Name = "addOn1";
            uao1.Amount = 100;
            uao1.StartDate = new DateTime(2013, 9, 5);
            uao1.EndDate = new DateTime(2013, 9, 6);

            UpdateAddOn uao2 = new UpdateAddOn();
            uao2.AddOnCode = "2";
            uao2.Name = "addOn2";
            uao2.Amount = 200;
            uao2.StartDate = new DateTime(2013, 9, 4);
            uao2.EndDate = new DateTime(2013, 9, 5);

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.UpdateAddOns.Add(uao1);
            update.UpdateAddOns.Add(uao2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<updateAddOn>
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>
</updateAddOn>
<updateAddOn>
<addOnCode>2</addOnCode>
<name>addOn2</name>
<amount>200</amount>
<startDate>2013-09-04</startDate>
<endDate>2013-09-05</endDate>
</updateAddOn>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainDeleteAddOns()
        {
            DeleteAddOn dao1 = new DeleteAddOn();
            dao1.AddOnCode = "1";

            DeleteAddOn dao2 = new DeleteAddOn();
            dao2.AddOnCode = "2";

            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.DeleteAddOns.Add(dao1);
            update.DeleteAddOns.Add(dao2);

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<deleteAddOn>
<addOnCode>1</addOnCode>
</deleteAddOn>
<deleteAddOn>
<addOnCode>2</addOnCode>
</deleteAddOn>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainToken()
        {
            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.Token = new CardTokenType();
            update.Token.LitleToken = "123456";

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<token>
<litleToken>123456</litleToken>
</token>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainPaypage()
        {
            UpdateSubscription update = new UpdateSubscription();
            update.SubscriptionId = 1;
            update.Paypage = new CardPaypageType();
            update.Paypage.PaypageRegistrationId = "abc123";

            String actual = update.Serialize();
            String expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<paypage>
<paypageRegistrationId>abc123</paypageRegistrationId>
</paypage>
</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void TestCancelSubscription_Full()
        {
            CancelSubscription cancel = new CancelSubscription();
            cancel.SubscriptionId = 12345;

            String actual = cancel.Serialize();
            String expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testCancelSubscription_OnlyRequired()
        {
            CancelSubscription update = new CancelSubscription();
            update.SubscriptionId = 12345;

            String actual = update.Serialize();
            String expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivate_Full()
        {
            Activate activate = new Activate();
            activate.OrderId = "12345";
            activate.Amount = 200;
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.ID = "theId";
            activate.ReportGroup = "theReportGroup";
            activate.Card = new CardType();

            String actual = activate.Serialize();
            String expected = @"
<activate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</activate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivate_VirtualGiftCard()
        {
            Activate activate = new Activate();
            activate.OrderId = "12345";
            activate.Amount = 200;
            activate.OrderSource = OrderSourceType.Ecommerce;
            activate.ID = "theId";
            activate.ReportGroup = "theReportGroup";
            activate.VirtualGiftCard = new VirtualGiftCardType();

            String actual = activate.Serialize();
            String expected = @"
<activate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<virtualGiftCard>
</virtualGiftCard>
</activate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testVirtualGiftCard_Full()
        {
            VirtualGiftCardType virtualGiftCard = new VirtualGiftCardType();
            virtualGiftCard.AccountNumberLength = 16;
            virtualGiftCard.GiftCardBin = "123456";

            String actual = virtualGiftCard.Serialize();
            String expected = @"
<accountNumberLength>16</accountNumberLength>
<giftCardBin>123456</giftCardBin>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDeactivate_Full()
        {
            Deactivate deactivate = new Deactivate();
            deactivate.OrderId = "12345";
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();
            deactivate.ID = "theId";
            deactivate.ReportGroup = "theReportGroup";

            String actual = deactivate.Serialize();
            String expected = @"
<deactivate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</deactivate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDeactivate_OnlyRequired()
        {
            Deactivate deactivate = new Deactivate();
            deactivate.OrderId = "12345";
            deactivate.OrderSource = OrderSourceType.Ecommerce;
            deactivate.Card = new CardType();
            deactivate.ID = "theId";
            deactivate.ReportGroup = "theReportGroup";

            String actual = deactivate.Serialize();
            String expected = @"
<deactivate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</deactivate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testLoad_Full()
        {
            Load load = new Load();
            load.OrderId = "12345";
            load.Amount = 200;
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();
            load.ID = "theId";
            load.ReportGroup = "theReportGroup";

            String actual = load.Serialize();
            String expected = @"
<load id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</load>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testLoad_OnlyRequired()
        {
            Load load = new Load();
            load.OrderId = "12345";
            load.Amount = 200;
            load.OrderSource = OrderSourceType.Ecommerce;
            load.Card = new CardType();
            load.ID = "theId";
            load.ReportGroup = "theReportGroup";

            String actual = load.Serialize();
            String expected = @"
<load id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</load>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUnload_Full()
        {
            Unload unload = new Unload();
            unload.OrderId = "12345";
            unload.Amount = 200;
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();
            unload.ID = "theId";
            unload.ReportGroup = "theReportGroup";

            String actual = unload.Serialize();
            String expected = @"
<unload id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</unload>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUnload_OnlyRequired()
        {
            Unload unload = new Unload();
            unload.OrderId = "12345";
            unload.Amount = 200;
            unload.OrderSource = OrderSourceType.Ecommerce;
            unload.Card = new CardType();
            unload.ID = "theId";
            unload.ReportGroup = "theReportGroup";

            String actual = unload.Serialize();
            String expected = @"
<unload id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</unload>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testBalanceInquiry_Full()
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderId = "12345";
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();
            balanceInquiry.ID = "theId";
            balanceInquiry.ReportGroup = "theReportGroup";

            String actual = balanceInquiry.Serialize();
            String expected = @"
<balanceInquiry id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</balanceInquiry>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testBalanceInquiry_OnlyRequired()
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry();
            balanceInquiry.OrderId = "12345";
            balanceInquiry.OrderSource = OrderSourceType.Ecommerce;
            balanceInquiry.Card = new CardType();
            balanceInquiry.ID = "theId";
            balanceInquiry.ReportGroup = "theReportGroup";

            String actual = balanceInquiry.Serialize();
            String expected = @"
<balanceInquiry id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</balanceInquiry>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreatePlan_Full()
        {
            CreatePlan create = new CreatePlan();
            create.PlanCode = "abc";
            create.Name = "thePlan";
            create.Description = "theDescription";
            create.IntervalType = IntervalType.Annual;
            create.Amount = 100;
            create.NumberOfPayments = 3;
            create.TrialNumberOfIntervals = 2;
            create.TrialIntervalType = TrialIntervalType.Month;
            create.Active = true;

            String actual = create.Serialize();
            String expected = @"
<createPlan>
<planCode>abc</planCode>
<name>thePlan</name>
<description>theDescription</description>
<intervalType>ANNUAL</intervalType>
<amount>100</amount>
<numberOfPayments>3</numberOfPayments>
<trialNumberOfIntervals>2</trialNumberOfIntervals>
<trialIntervalType>MONTH</trialIntervalType>
<active>true</active>
</createPlan>";
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void TestCreatePlan_OnlyRequired()
        {
            CreatePlan create = new CreatePlan();
            create.PlanCode = "abc";
            create.Name = "thePlan";
            create.IntervalType = IntervalType.Annual;
            create.Amount = 100;

            String actual = create.Serialize();
            String expected = @"
<createPlan>
<planCode>abc</planCode>
<name>thePlan</name>
<intervalType>ANNUAL</intervalType>
<amount>100</amount>
</createPlan>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdatePlan_Full()
        {
            UpdatePlan update = new UpdatePlan();
            update.PlanCode = "abc";
            update.Active = true;

            String actual = update.Serialize();
            String expected = @"
<updatePlan>
<planCode>abc</planCode>
<active>true</active>
</updatePlan>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TesLitleInternalRecurringRequestMustContainFinalPayment()
        {
            LitleInternalRecurringRequest litleInternalRecurringRequest = new LitleInternalRecurringRequest();
            litleInternalRecurringRequest.SubscriptionId = "123";
            litleInternalRecurringRequest.RecurringTxnId = "456";
            litleInternalRecurringRequest.FinalPayment = true;

            String actual = litleInternalRecurringRequest.Serialize();
            String expected = @"
<subscriptionId>123</subscriptionId>
<recurringTxnId>456</recurringTxnId>
<finalPayment>true</finalPayment>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreateDiscount_Full()
        {
            CreateDiscount cd = new CreateDiscount();
            cd.DiscountCode = "1";
            cd.Name = "cheaper";
            cd.Amount = 200;
            cd.StartDate = new DateTime(2013, 9, 5);
            cd.EndDate = new DateTime(2013, 9, 6);

            String actual = cd.Serialize();
            String expected = @"
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateDiscount_Full()
        {
            UpdateDiscount ud = new UpdateDiscount();
            ud.DiscountCode = "1";
            ud.Name = "cheaper";
            ud.Amount = 200;
            ud.StartDate = new DateTime(2013, 9, 5);
            ud.EndDate = new DateTime(2013, 9, 6);

            String actual = ud.Serialize();
            String expected = @"
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateDiscount_OnlyRequired()
        {
            UpdateDiscount ud = new UpdateDiscount();
            ud.DiscountCode = "1";

            String actual = ud.Serialize();
            String expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteDiscount()
        {
            DeleteDiscount ud = new DeleteDiscount();
            ud.DiscountCode = "1";

            String actual = ud.Serialize();
            String expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreateAddOn()
        {
            CreateAddOn cao = new CreateAddOn();
            cao.AddOnCode = "1";
            cao.Name = "addOn1";
            cao.Amount = 100;
            cao.StartDate = new DateTime(2013, 9, 5);
            cao.EndDate = new DateTime(2013, 9, 6);

            String actual = cao.Serialize();
            String expected = @"
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateAddOn_Full()
        {
            UpdateAddOn uao = new UpdateAddOn();
            uao.AddOnCode = "1";
            uao.Name = "addOn1";
            uao.Amount = 100;
            uao.StartDate = new DateTime(2013, 9, 5);
            uao.EndDate = new DateTime(2013, 9, 6);

            String actual = uao.Serialize();
            String expected = @"
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateAddOn_OnlyRequired()
        {
            UpdateAddOn uao = new UpdateAddOn();
            uao.AddOnCode = "1";

            String actual = uao.Serialize();
            String expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteAddOn()
        {
            DeleteAddOn dao = new DeleteAddOn();
            dao.AddOnCode = "1";

            String actual = dao.Serialize();
            String expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDepositReversal_Full()
        {
            DepositReversal depositReversal = new DepositReversal();
            depositReversal.ID = "theId";
            depositReversal.ReportGroup = "theReportGroup";
            depositReversal.CustomerId = "theCustomerId";
            depositReversal.LitleTxnId = "123";

            String actual = depositReversal.Serialize();
            String expected = @"
<depositReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</depositReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testRefundReversal_Full()
        {
            RefundReversal refundReversal = new RefundReversal();
            refundReversal.ID = "theId";
            refundReversal.ReportGroup = "theReportGroup";
            refundReversal.CustomerId = "theCustomerId";
            refundReversal.LitleTxnId = "123";

            String actual = refundReversal.Serialize();
            String expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivateReversal_Full()
        {
            ActivateReversal activateReversal = new ActivateReversal();
            activateReversal.ID = "theId";
            activateReversal.ReportGroup = "theReportGroup";
            activateReversal.CustomerId = "theCustomerId";
            activateReversal.LitleTxnId = "123";

            String actual = activateReversal.Serialize();
            String expected = @"
<activateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</activateReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDeactivateReversal_Full()
        {
            DeactivateReversal deactivateReversal = new DeactivateReversal();
            deactivateReversal.ID = "theId";
            deactivateReversal.ReportGroup = "theReportGroup";
            deactivateReversal.CustomerId = "theCustomerId";
            deactivateReversal.LitleTxnId = "123";

            String actual = deactivateReversal.Serialize();
            String expected = @"
<deactivateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</deactivateReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testLoadReversal_Full()
        {
            LoadReversal loadReversal = new LoadReversal();
            loadReversal.ID = "theId";
            loadReversal.ReportGroup = "theReportGroup";
            loadReversal.CustomerId = "theCustomerId";
            loadReversal.LitleTxnId = "123";

            String actual = loadReversal.Serialize();
            String expected = @"
<loadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</loadReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUnloadReversal_Full()
        {
            UnloadReversal unloadReversal = new UnloadReversal();
            unloadReversal.ID = "theId";
            unloadReversal.ReportGroup = "theReportGroup";
            unloadReversal.CustomerId = "theCustomerId";
            unloadReversal.LitleTxnId = "123";

            String actual = unloadReversal.Serialize();
            String expected = @"
<unloadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</unloadReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testSpecialCharacters_RefundReversal()
        {
            RefundReversal refundReversal = new RefundReversal();
            refundReversal.ID = "theId";
            refundReversal.ReportGroup = "<'&\">";
            refundReversal.CustomerId = "theCustomerId";
            refundReversal.LitleTxnId = "123";

            String actual = refundReversal.Serialize();
            String expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""&lt;&apos;&amp;&quot;&gt;"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEmptyMethodOfPayment()
        {
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.Item;
            card.Number = "4100000000000001";
            card.ExpDate = "1250";

            String actual = card.Serialize();
            String expected = @"
<type></type>
<number>4100000000000001</number>
<expDate>1250</expDate>";
            Assert.AreEqual(expected, actual);
        }
    }
}

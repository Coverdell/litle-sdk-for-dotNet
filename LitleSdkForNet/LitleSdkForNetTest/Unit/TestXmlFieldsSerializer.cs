using System;
using System.Text.RegularExpressions;
using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestXmlFieldsSerializer : TestBase
    {
        [Test]
        public void TestRecurringRequest_Full()
        {
            var request = new RecurringRequest
            {
                Subscription = new Subscription
                {
                    PlanCode = "123abc",
                    NumberOfPayments = 10,
                    StartDate = new DateTime(2013, 7, 25),
                    Amount = 102
                }
            };

            var xml = request.Serialize();
            var pattern = FormMatchExpression(
                "<subscription>",
                "<planCode>123abc</planCode>",
                "<numberOfPayments>10</numberOfPayments>",
                "<startDate>2013-07-25</startDate>",
                "<amount>102</amount>",
                "</subscription>");
            var match = Regex.Match(xml, pattern);
            Assert.IsTrue(match.Success, xml);
        }

        [Test]
        public void TestRecurringRequest_OnlyRequired()
        {
            var request = new RecurringRequest
            {
                Subscription = new Subscription
                {
                    PlanCode = "123abc"
                }
            };

            var xml = request.Serialize();
            var pattern = FormMatchExpression(
                "<subscription>",
                "<planCode>123abc</planCode>",
                "</subscription>");
            var match = Regex.Match(xml, pattern);
            Assert.IsTrue(match.Success, xml);
        }

        [Test]
        public void TestSubscription_CanContainCreateDiscounts()
        {
            var subscription = new Subscription
            {
                PlanCode = "123abc",
                CreateDiscounts =
                {
                    new CreateDiscount
                    {
                        DiscountCode = "1",
                        Name = "cheaper",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new CreateDiscount
                    {
                        DiscountCode = "2",
                        Name = "cheap",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 3),
                        EndDate = new DateTime(2013, 9, 4)
                    }
                }
            };

            var actual = subscription.Serialize();
            var pattern = FormMatchExpression(
                "<planCode>123abc</planCode>",
                "<createDiscount>",
                "<discountCode>1</discountCode>",
                "<name>cheaper</name>",
                "<amount>200</amount>",
                "<startDate>2013-09-05</startDate>",
                "<endDate>2013-09-06</endDate>",
                "</createDiscount>",
                "<createDiscount>",
                "<discountCode>2</discountCode>",
                "<name>cheap</name>",
                "<amount>100</amount>",
                "<startDate>2013-09-03</startDate>",
                "<endDate>2013-09-04</endDate>",
                "</createDiscount>");
            var match = Regex.Match(actual, pattern);
            Assert.IsTrue(match.Success, actual);
        }

        [Test]
        public void TestSubscription_CanContainCreateAddOns()
        {
            var subscription = new Subscription
            {
                PlanCode = "123abc",
                CreateAddOns =
                {
                    new CreateAddOn
                    {
                        AddOnCode = "1",
                        Name = "addOn1",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new CreateAddOn
                    {
                        AddOnCode = "2",
                        Name = "addOn2",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 4),
                        EndDate = new DateTime(2013, 9, 5)
                    }
                }
            };

            var actual = subscription.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                BillingDate = new DateTime(2002, 10, 9),
                BillToAddress = new Contact
                {
                    Name = "Greg Dake",
                    City = "Lowell",
                    State = "MA",
                    Email = "sdksupport@litle.com"
                },
                Card = new CardType
                {
                    Number = "4100000000000001",
                    ExpDate = "1215",
                    Type = MethodOfPaymentTypeEnum.VI
                },
                PlanCode = "abcdefg",
                SubscriptionId = 12345
            };

            string actual = update.Serialize();
            const string expected =
                "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n<planCode>abcdefg</planCode>\r\n<billToAddress>\r\n<name>Greg Dake</name>\r\n<city>Lowell</city>\r\n<state>MA</state>\r\n<email>sdksupport@litle.com</email>\r\n</billToAddress>\r\n<card>\r\n<type>VI</type>\r\n<number>4100000000000001</number>\r\n<expDate>1215</expDate>\r\n</card>\r\n<billingDate>2002-10-09</billingDate>\r\n</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_OnlyRequired()
        {
            var update = new UpdateSubscription
            {
                SubscriptionId = 12345
            };

            string actual = update.Serialize();
            const string expected =
                "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n</updateSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUpdateSubscription_CanContainCreateDiscounts()
        {
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                CreateDiscounts =
                {
                    new CreateDiscount
                    {
                        DiscountCode = "1",
                        Name = "cheaper",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new CreateDiscount
                    {
                        DiscountCode = "2",
                        Name = "cheap",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 3),
                        EndDate = new DateTime(2013, 9, 4)
                    }
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                UpdateDiscounts =
                {
                    new UpdateDiscount
                    {
                        DiscountCode = "1",
                        Name = "cheaper",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new UpdateDiscount
                    {
                        DiscountCode = "2",
                        Name = "cheap",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 3),
                        EndDate = new DateTime(2013, 9, 4)
                    }
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                DeleteDiscounts =
                {
                    new DeleteDiscount {DiscountCode = "1"},
                    new DeleteDiscount {DiscountCode = "2"}
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                CreateAddOns =
                {
                    new CreateAddOn
                    {
                        AddOnCode = "1",
                        Name = "addOn1",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new CreateAddOn
                    {
                        AddOnCode = "2",
                        Name = "addOn2",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 4),
                        EndDate = new DateTime(2013, 9, 5)
                    }
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                UpdateAddOns =
                {
                    new UpdateAddOn
                    {
                        AddOnCode = "1",
                        Name = "addOn1",
                        Amount = 100,
                        StartDate = new DateTime(2013, 9, 5),
                        EndDate = new DateTime(2013, 9, 6)
                    },
                    new UpdateAddOn
                    {
                        AddOnCode = "2",
                        Name = "addOn2",
                        Amount = 200,
                        StartDate = new DateTime(2013, 9, 4),
                        EndDate = new DateTime(2013, 9, 5)
                    }
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                DeleteAddOns =
                {
                    new DeleteAddOn {AddOnCode = "1"},
                    new DeleteAddOn {AddOnCode = "2"}
                }
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                Token = new CardTokenType {LitleToken = "123456"}
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var update = new UpdateSubscription
            {
                SubscriptionId = 1,
                Paypage = new CardPaypageType {PaypageRegistrationId = "abc123"}
            };

            string actual = update.Serialize();
            const string expected = @"
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
            var cancel = new CancelSubscription {SubscriptionId = 12345};

            string actual = cancel.Serialize();
            const string expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testCancelSubscription_OnlyRequired()
        {
            var update = new CancelSubscription {SubscriptionId = 12345};

            string actual = update.Serialize();
            const string expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivate_Full()
        {
            var activate = new Activate
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                ID = "theId",
                ReportGroup = "theReportGroup",
                Card = new CardType()
            };

            string actual = activate.Serialize();
            const string expected = @"
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
            var activate = new Activate
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                ID = "theId",
                ReportGroup = "theReportGroup",
                VirtualGiftCard = new VirtualGiftCardType()
            };

            string actual = activate.Serialize();
            const string expected = @"
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
            var virtualGiftCard = new VirtualGiftCardType {AccountNumberLength = 16, GiftCardBin = "123456"};

            string actual = virtualGiftCard.Serialize();
            const string expected = @"
<accountNumberLength>16</accountNumberLength>
<giftCardBin>123456</giftCardBin>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDeactivate_Full()
        {
            var deactivate = new Deactivate
            {
                OrderId = "12345",
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = deactivate.Serialize();
            const string expected = @"
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
            var deactivate = new Deactivate
            {
                OrderId = "12345",
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = deactivate.Serialize();
            const string expected = @"
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
            var load = new Load
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = load.Serialize();
            const string expected = @"
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
            var load = new Load
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = load.Serialize();
            const string expected = @"
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
            var unload = new Unload
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = unload.Serialize();
            const string expected = @"
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
            var unload = new Unload
            {
                OrderId = "12345",
                Amount = 200,
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = unload.Serialize();
            const string expected = @"
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
            var balanceInquiry = new BalanceInquiry
            {
                OrderId = "12345",
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = balanceInquiry.Serialize();
            const string expected = @"
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
            var balanceInquiry = new BalanceInquiry
            {
                OrderId = "12345",
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType(),
                ID = "theId",
                ReportGroup = "theReportGroup"
            };

            string actual = balanceInquiry.Serialize();
            const string expected = @"
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
            var create = new CreatePlan
            {
                PlanCode = "abc",
                Name = "thePlan",
                Description = "theDescription",
                IntervalType = IntervalType.Annual,
                Amount = 100,
                NumberOfPayments = 3,
                TrialNumberOfIntervals = 2,
                TrialIntervalType = TrialIntervalType.Month,
                Active = true
            };

            string actual = create.Serialize();
            const string expected = @"
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
            var create = new CreatePlan
            {
                PlanCode = "abc",
                Name = "thePlan",
                IntervalType = IntervalType.Annual,
                Amount = 100
            };

            string actual = create.Serialize();
            const string expected = @"
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
            var update = new UpdatePlan {PlanCode = "abc", Active = true};

            string actual = update.Serialize();
            const string expected = @"
<updatePlan>
<planCode>abc</planCode>
<active>true</active>
</updatePlan>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TesLitleInternalRecurringRequestMustContainFinalPayment()
        {
            var litleInternalRecurringRequest = new LitleInternalRecurringRequest
            {
                SubscriptionId = "123",
                RecurringTxnId = "456",
                FinalPayment = true
            };

            string actual = litleInternalRecurringRequest.Serialize();
            const string expected = @"
<subscriptionId>123</subscriptionId>
<recurringTxnId>456</recurringTxnId>
<finalPayment>true</finalPayment>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreateDiscount_Full()
        {
            var cd = new CreateDiscount
            {
                DiscountCode = "1",
                Name = "cheaper",
                Amount = 200,
                StartDate = new DateTime(2013, 9, 5),
                EndDate = new DateTime(2013, 9, 6)
            };

            string actual = cd.Serialize();
            const string expected = @"
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
            var ud = new UpdateDiscount
            {
                DiscountCode = "1",
                Name = "cheaper",
                Amount = 200,
                StartDate = new DateTime(2013, 9, 5),
                EndDate = new DateTime(2013, 9, 6)
            };

            string actual = ud.Serialize();
            const string expected = @"
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
            var ud = new UpdateDiscount {DiscountCode = "1"};

            string actual = ud.Serialize();
            const string expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteDiscount()
        {
            var ud = new DeleteDiscount {DiscountCode = "1"};

            string actual = ud.Serialize();
            const string expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCreateAddOn()
        {
            var cao = new CreateAddOn
            {
                AddOnCode = "1",
                Name = "addOn1",
                Amount = 100,
                StartDate = new DateTime(2013, 9, 5),
                EndDate = new DateTime(2013, 9, 6)
            };

            string actual = cao.Serialize();
            const string expected = @"
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
            var uao = new UpdateAddOn
            {
                AddOnCode = "1",
                Name = "addOn1",
                Amount = 100,
                StartDate = new DateTime(2013, 9, 5),
                EndDate = new DateTime(2013, 9, 6)
            };

            string actual = uao.Serialize();
            const string expected = @"
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
            var uao = new UpdateAddOn {AddOnCode = "1"};

            string actual = uao.Serialize();
            const string expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteAddOn()
        {
            var dao = new DeleteAddOn {AddOnCode = "1"};

            string actual = dao.Serialize();
            const string expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDepositReversal_Full()
        {
            var depositReversal = new DepositReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = depositReversal.Serialize();
            const string expected = @"
<depositReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</depositReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testRefundReversal_Full()
        {
            var refundReversal = new RefundReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = refundReversal.Serialize();
            const string expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivateReversal_Full()
        {
            var activateReversal = new ActivateReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = activateReversal.Serialize();
            const string expected = @"
<activateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</activateReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testDeactivateReversal_Full()
        {
            var deactivateReversal = new DeactivateReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = deactivateReversal.Serialize();
            const string expected = @"
<deactivateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</deactivateReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testLoadReversal_Full()
        {
            var loadReversal = new LoadReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = loadReversal.Serialize();
            const string expected = @"
<loadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</loadReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testUnloadReversal_Full()
        {
            var unloadReversal = new UnloadReversal
            {
                ID = "theId",
                ReportGroup = "theReportGroup",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = unloadReversal.Serialize();
            const string expected = @"
<unloadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</unloadReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testSpecialCharacters_RefundReversal()
        {
            var refundReversal = new RefundReversal
            {
                ID = "theId",
                ReportGroup = "<'&\">",
                CustomerId = "theCustomerId",
                LitleTxnId = "123"
            };

            string actual = refundReversal.Serialize();
            const string expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""&lt;&apos;&amp;&quot;&gt;"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEmptyMethodOfPayment()
        {
            var card = new CardType {Type = MethodOfPaymentTypeEnum.Item, Number = "4100000000000001", ExpDate = "1250"};

            string actual = card.Serialize();
            const string expected = @"
<type></type>
<number>4100000000000001</number>
<expDate>1250</expDate>";
            Assert.AreEqual(expected, actual);
        }
    }
}
using System;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestXmlFieldsSerializer
    {
        [Test]
        public void TestRecurringRequest_Full()
        {
            var request = new recurringRequest
            {
                subscription = new subscription
                {
                    planCode = "123abc",
                    numberOfPayments = 10,
                    startDate = new DateTime(2013, 7, 25),
                    amount = 102
                }
            };

            const string pattern =
                "<subscription>\r\n<planCode>123abc</planCode>\r\n<numberOfPayments>10</numberOfPayments>\r\n<startDate>2013-07-25</startDate>\r\n<amount>102</amount>\r\n</subscription>";
            StringAssert.IsMatch(pattern, request.Serialize());
        }

        [Test]
        public void TestRecurringRequest_OnlyRequired()
        {
            var request = new recurringRequest {subscription = new subscription {planCode = "123abc"}};

            const string pattern = "<subscription>\r\n<planCode>123abc</planCode>\r\n</subscription>";
            StringAssert.IsMatch(pattern, request.Serialize());
        }

        [Test]
        public void TestSubscription_CanContainCreateDiscounts()
        {
            var subscription = new subscription
            {
                planCode = "123abc",
                createDiscounts =
                {
                    new createDiscount
                    {
                        discountCode = "1",
                        name = "cheaper",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new createDiscount
                    {
                        discountCode = "2",
                        name = "cheap",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 3),
                        endDate = new DateTime(2013, 9, 4)
                    }
                }
            };

            const string expected = @"
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
            Assert.AreEqual(expected, subscription.Serialize());
        }

        [Test]
        public void TestSubscription_CanContainCreateAddOns()
        {
            var subscription = new subscription
            {
                planCode = "123abc",
                createAddOns =
                {
                    new createAddOn
                    {
                        addOnCode = "1",
                        name = "addOn1",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new createAddOn
                    {
                        addOnCode = "2",
                        name = "addOn2",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 4),
                        endDate = new DateTime(2013, 9, 5)
                    }
                }
            };

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
            Assert.AreEqual(expected, subscription.Serialize());
        }

        [Test]
        public void TestUpdateSubscription_Full()
        {
            var update = new updateSubscription
            {
                billingDate = new DateTime(2002, 10, 9),
                billToAddress = new contact
                {
                    name = "Greg Dake",
                    city = "Lowell",
                    state = "MA",
                    email = "sdksupport@litle.com"
                },
                card = new cardType
                {
                    number = "4100000000000001",
                    expDate = "1215",
                    type = methodOfPaymentTypeEnum.VI
                },
                planCode = "abcdefg",
                subscriptionId = 12345
            };

            const string expected =
                "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n<planCode>abcdefg</planCode>\r\n<billToAddress>\r\n<name>Greg Dake</name>\r\n<city>Lowell</city>\r\n<state>MA</state>\r\n<email>sdksupport@litle.com</email>\r\n</billToAddress>\r\n<card>\r\n<type>VI</type>\r\n<number>4100000000000001</number>\r\n<expDate>1215</expDate>\r\n</card>\r\n<billingDate>2002-10-09</billingDate>\r\n</updateSubscription>";
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_OnlyRequired()
        {
            var update = new updateSubscription {subscriptionId = 12345};

            const string expected =
                "\r\n<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n</updateSubscription>";
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainCreateDiscounts()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                createDiscounts =
                {
                    new createDiscount
                    {
                        discountCode = "1",
                        name = "cheaper",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new createDiscount
                    {
                        discountCode = "2",
                        name = "cheap",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 3),
                        endDate = new DateTime(2013, 9, 4)
                    }
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainUpdateDiscounts()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                updateDiscounts =
                {
                    new updateDiscount
                    {
                        discountCode = "1",
                        name = "cheaper",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new updateDiscount
                    {
                        discountCode = "2",
                        name = "cheap",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 3),
                        endDate = new DateTime(2013, 9, 4)
                    }
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainDeleteDiscounts()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                deleteDiscounts =
                {
                    new deleteDiscount {discountCode = "1"},
                    new deleteDiscount {discountCode = "2"}
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainCreateAddOns()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                createAddOns =
                {
                    new createAddOn
                    {
                        addOnCode = "1",
                        name = "addOn1",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new createAddOn
                    {
                        addOnCode = "2",
                        name = "addOn2",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 4),
                        endDate = new DateTime(2013, 9, 5)
                    }
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainUpdateAddOns()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                updateAddOns =
                {
                    new updateAddOn
                    {
                        addOnCode = "1",
                        name = "addOn1",
                        amount = 100,
                        startDate = new DateTime(2013, 9, 5),
                        endDate = new DateTime(2013, 9, 6)
                    },
                    new updateAddOn
                    {
                        addOnCode = "2",
                        name = "addOn2",
                        amount = 200,
                        startDate = new DateTime(2013, 9, 4),
                        endDate = new DateTime(2013, 9, 5)
                    }
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainDeleteAddOns()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                deleteAddOns =
                {
                    new deleteAddOn {addOnCode = "1"},
                    new deleteAddOn {addOnCode = "2"}
                }
            };

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
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainToken()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                token = new cardTokenType {litleToken = "123456"}
            };

            const string expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<token>
<litleToken>123456</litleToken>
</token>
</updateSubscription>";
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void testUpdateSubscription_CanContainPaypage()
        {
            var update = new updateSubscription
            {
                subscriptionId = 1,
                paypage = new cardPaypageType {paypageRegistrationId = "abc123"}
            };

            const string expected = @"
<updateSubscription>
<subscriptionId>1</subscriptionId>
<paypage>
<paypageRegistrationId>abc123</paypageRegistrationId>
</paypage>
</updateSubscription>";
            Assert.AreEqual(expected, update.Serialize());
        }


        [Test]
        public void TestCancelSubscription_Full()
        {
            var cancel = new cancelSubscription {subscriptionId = 12345};

            const string expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, cancel.Serialize());
        }

        [Test]
        public void testCancelSubscription_OnlyRequired()
        {
            var update = new cancelSubscription {subscriptionId = 12345};

            var actual = update.Serialize();
            const string expected = @"
<cancelSubscription>
<subscriptionId>12345</subscriptionId>
</cancelSubscription>";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void testActivate_Full()
        {
            var activate = new activate
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                id = "theId",
                reportGroup = "theReportGroup",
                card = new cardType()
            };

            const string expected = @"
<activate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</activate>";
            Assert.AreEqual(expected, activate.Serialize());
        }

        [Test]
        public void testActivate_VirtualGiftCard()
        {
            var activate = new activate
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                id = "theId",
                reportGroup = "theReportGroup",
                virtualGiftCard = new virtualGiftCardType()
            };

            const string expected = @"
<activate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<virtualGiftCard>
</virtualGiftCard>
</activate>";
            Assert.AreEqual(expected, activate.Serialize());
        }

        [Test]
        public void testVirtualGiftCard_Full()
        {
            var virtualGiftCard = new virtualGiftCardType
            {
                accountNumberLength = 16,
                giftCardBin = "123456"
            };

            const string expected = @"
<accountNumberLength>16</accountNumberLength>
<giftCardBin>123456</giftCardBin>";
            Assert.AreEqual(expected, virtualGiftCard.Serialize());
        }

        [Test]
        public void testDeactivate_Full()
        {
            var deactivate = new deactivate
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<deactivate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</deactivate>";
            Assert.AreEqual(expected, deactivate.Serialize());
        }

        [Test]
        public void testDeactivate_OnlyRequired()
        {
            var deactivate = new deactivate
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<deactivate id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</deactivate>";
            Assert.AreEqual(expected, deactivate.Serialize());
        }

        [Test]
        public void testLoad_Full()
        {
            var load = new load
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<load id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</load>";
            Assert.AreEqual(expected, load.Serialize());
        }

        [Test]
        public void testLoad_OnlyRequired()
        {
            var load = new load
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<load id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</load>";
            Assert.AreEqual(expected, load.Serialize());
        }

        [Test]
        public void testUnload_Full()
        {
            var unload = new unload
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<unload id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</unload>";
            Assert.AreEqual(expected, unload.Serialize());
        }

        [Test]
        public void testUnload_OnlyRequired()
        {
            var unload = new unload
            {
                orderId = "12345",
                amount = 200,
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<unload id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<amount>200</amount>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</unload>";
            Assert.AreEqual(expected, unload.Serialize());
        }

        [Test]
        public void testBalanceInquiry_Full()
        {
            var balanceInquiry = new balanceInquiry
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<balanceInquiry id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</balanceInquiry>";
            Assert.AreEqual(expected, balanceInquiry.Serialize());
        }

        [Test]
        public void testBalanceInquiry_OnlyRequired()
        {
            var balanceInquiry = new balanceInquiry
            {
                orderId = "12345",
                orderSource = orderSourceType.ecommerce,
                card = new cardType(),
                id = "theId",
                reportGroup = "theReportGroup"
            };

            const string expected = @"
<balanceInquiry id=""theId"" reportGroup=""theReportGroup"">
<orderId>12345</orderId>
<orderSource>ecommerce</orderSource>
<card>
<type>MC</type>
</card>
</balanceInquiry>";
            Assert.AreEqual(expected, balanceInquiry.Serialize());
        }

        [Test]
        public void TestCreatePlan_Full()
        {
            var create = new createPlan
            {
                planCode = "abc",
                name = "thePlan",
                description = "theDescription",
                intervalType = intervalType.ANNUAL,
                amount = 100,
                numberOfPayments = 3,
                trialNumberOfIntervals = 2,
                trialIntervalType = trialIntervalType.MONTH,
                active = true
            };

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
            Assert.AreEqual(expected, create.Serialize());
        }


        [Test]
        public void TestCreatePlan_OnlyRequired()
        {
            var create = new createPlan
            {
                planCode = "abc",
                name = "thePlan",
                intervalType = intervalType.ANNUAL,
                amount = 100
            };

            const string expected = @"
<createPlan>
<planCode>abc</planCode>
<name>thePlan</name>
<intervalType>ANNUAL</intervalType>
<amount>100</amount>
</createPlan>";
            Assert.AreEqual(expected, create.Serialize());
        }

        [Test]
        public void TestUpdatePlan_Full()
        {
            var update = new updatePlan
            {
                planCode = "abc",
                active = true
            };

            const string expected = @"
<updatePlan>
<planCode>abc</planCode>
<active>true</active>
</updatePlan>";
            Assert.AreEqual(expected, update.Serialize());
        }

        [Test]
        public void TesLitleInternalRecurringRequestMustContainFinalPayment()
        {
            var litleInternalRecurringRequest = new litleInternalRecurringRequest
            {
                subscriptionId = "123",
                recurringTxnId = "456",
                finalPayment = true
            };

            const string expected = @"
<subscriptionId>123</subscriptionId>
<recurringTxnId>456</recurringTxnId>
<finalPayment>true</finalPayment>";
            Assert.AreEqual(expected, litleInternalRecurringRequest.Serialize());
        }

        [Test]
        public void TestCreateDiscount_Full()
        {
            var cd = new createDiscount
            {
                discountCode = "1",
                name = "cheaper",
                amount = 200,
                startDate = new DateTime(2013, 9, 5),
                endDate = new DateTime(2013, 9, 6)
            };

            const string expected = @"
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, cd.Serialize());
        }

        [Test]
        public void TestUpdateDiscount_Full()
        {
            var ud = new updateDiscount
            {
                discountCode = "1",
                name = "cheaper",
                amount = 200,
                startDate = new DateTime(2013, 9, 5),
                endDate = new DateTime(2013, 9, 6)
            };

            const string expected = @"
<discountCode>1</discountCode>
<name>cheaper</name>
<amount>200</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, ud.Serialize());
        }

        [Test]
        public void TestUpdateDiscount_OnlyRequired()
        {
            var ud = new updateDiscount {discountCode = "1"};

            const string expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, ud.Serialize());
        }

        [Test]
        public void TestDeleteDiscount()
        {
            var ud = new deleteDiscount {discountCode = "1"};

            const string expected = @"
<discountCode>1</discountCode>";
            Assert.AreEqual(expected, ud.Serialize());
        }

        [Test]
        public void TestCreateAddOn()
        {
            var cao = new createAddOn
            {
                addOnCode = "1",
                name = "addOn1",
                amount = 100,
                startDate = new DateTime(2013, 9, 5),
                endDate = new DateTime(2013, 9, 6)
            };

            const string expected = @"
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, cao.Serialize());
        }

        [Test]
        public void TestUpdateAddOn_Full()
        {
            var uao = new updateAddOn
            {
                addOnCode = "1",
                name = "addOn1",
                amount = 100,
                startDate = new DateTime(2013, 9, 5),
                endDate = new DateTime(2013, 9, 6)
            };

            const string expected = @"
<addOnCode>1</addOnCode>
<name>addOn1</name>
<amount>100</amount>
<startDate>2013-09-05</startDate>
<endDate>2013-09-06</endDate>";
            Assert.AreEqual(expected, uao.Serialize());
        }

        [Test]
        public void TestUpdateAddOn_OnlyRequired()
        {
            var uao = new updateAddOn {addOnCode = "1"};

            const string expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, uao.Serialize());
        }

        [Test]
        public void TestDeleteAddOn()
        {
            var dao = new deleteAddOn {addOnCode = "1"};

            const string expected = @"
<addOnCode>1</addOnCode>";
            Assert.AreEqual(expected, dao.Serialize());
        }

        [Test]
        public void testDepositReversal_Full()
        {
            var depositReversal = new depositReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<depositReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</depositReversal>";
            Assert.AreEqual(expected, depositReversal.Serialize());
        }

        [Test]
        public void testRefundReversal_Full()
        {
            var refundReversal = new refundReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, refundReversal.Serialize());
        }

        [Test]
        public void testActivateReversal_Full()
        {
            var activateReversal = new activateReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<activateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</activateReversal>";
            Assert.AreEqual(expected, activateReversal.Serialize());
        }

        [Test]
        public void testDeactivateReversal_Full()
        {
            var deactivateReversal = new deactivateReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<deactivateReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</deactivateReversal>";
            Assert.AreEqual(expected, deactivateReversal.Serialize());
        }

        [Test]
        public void testLoadReversal_Full()
        {
            var loadReversal = new loadReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<loadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</loadReversal>";
            Assert.AreEqual(expected, loadReversal.Serialize());
        }

        [Test]
        public void testUnloadReversal_Full()
        {
            var unloadReversal = new unloadReversal
            {
                id = "theId",
                reportGroup = "theReportGroup",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<unloadReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""theReportGroup"">
<litleTxnId>123</litleTxnId>
</unloadReversal>";
            Assert.AreEqual(expected, unloadReversal.Serialize());
        }

        [Test]
        public void testSpecialCharacters_RefundReversal()
        {
            var refundReversal = new refundReversal
            {
                id = "theId",
                reportGroup = "<'&\">",
                customerId = "theCustomerId",
                litleTxnId = "123"
            };

            const string expected = @"
<refundReversal id=""theId"" customerId=""theCustomerId"" reportGroup=""&lt;&apos;&amp;&quot;&gt;"">
<litleTxnId>123</litleTxnId>
</refundReversal>";
            Assert.AreEqual(expected, refundReversal.Serialize());
        }

        [Test]
        public void TestEmptyMethodOfPayment()
        {
            var card = new cardType
            {
                type = methodOfPaymentTypeEnum.Item,
                number = "4100000000000001",
                expDate = "1250"
            };

            const string expected = @"
<type></type>
<number>4100000000000001</number>
<expDate>1250</expDate>";
            Assert.AreEqual(expected, card.Serialize());
        }
    }
}
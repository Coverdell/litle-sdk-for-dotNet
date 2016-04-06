using System;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestUpdateSubscription : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(
                ".*<litleOnlineRequest.*?<updateSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n<planCode>abcdefg</planCode>\r\n<billToAddress>\r\n<name>Greg Dake</name>.*?</billToAddress>\r\n<card>\r\n<type>VI</type>.*?</card>\r\n<billingDate>2002-10-09</billingDate>\r\n</updateSubscription>\r\n</litleOnlineRequest>.*?.*",
                "<litleOnlineResponse version='8.20' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateSubscriptionResponse ><litleTxnId>456</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04</responseTime><subscriptionId>12345</subscriptionId></updateSubscriptionResponse></litleOnlineResponse>");

            var response = Litle.UpdateSubscription(new updateSubscription
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
            });

            Assert.AreEqual("12345", response.subscriptionId);
            Assert.AreEqual("456", response.litleTxnId);
            Assert.AreEqual("000", response.response);
            Assert.NotNull(response.responseTime);
        }
    }
}
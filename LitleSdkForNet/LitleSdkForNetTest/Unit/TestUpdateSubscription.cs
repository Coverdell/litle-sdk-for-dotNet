using System;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestUpdateSubscription : TestBase
    {        
        [Test]
        public void TestSimple()
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

            var regex = FormMatchExpression(
                "<litleOnlineRequest.*?",
                "<updateSubscription>",
                "<subscriptionId>12345</subscriptionId>",
                "<planCode>abcdefg</planCode>",
                "<billToAddress>",
                "<name>Greg Dake</name>",
                "</billToAddress>",
                "<card>",
                "<type>VI</type>",
                "</card>",
                "<billingDate>2002-10-09</billingDate>",
                "</updateSubscription>",
                "</litleOnlineRequest>");
            const string value = "<litleOnlineResponse version='8.20' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateSubscriptionResponse ><litleTxnId>456</litleTxnId><response>000</response><message>Approved</message><responseTime>2013-09-04</responseTime><subscriptionId>12345</subscriptionId></updateSubscriptionResponse></litleOnlineResponse>";
            MockLitlePost(regex, value);
            UpdateSubscriptionResponse response = Litle.UpdateSubscription(update);
            Assert.AreEqual("12345", response.SubscriptionId);
            Assert.AreEqual("456", response.LitleTxnId);
            Assert.AreEqual("000", response.Response);
            Assert.NotNull(response.ResponseTime);
        }
    }
}
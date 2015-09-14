using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCancelSubscription : TestBase
    {
        [Test]
        public void TestSimple()
        {
            var regex = FormMatchExpression(
                "<cancelSubscription>",
                "<subscriptionId>12345</subscriptionId>",
                "</cancelSubscription>");
            const string value = @"
                <litleOnlineResponse version='8.20' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <cancelSubscriptionResponse>
                        <subscriptionId>12345</subscriptionId>
                    </cancelSubscriptionResponse>
                </litleOnlineResponse>";
            var update = new CancelSubscription {SubscriptionId = 12345};

            MockLitlePost(regex, value);

            Litle.CancelSubscription(update);
        }
    }
}
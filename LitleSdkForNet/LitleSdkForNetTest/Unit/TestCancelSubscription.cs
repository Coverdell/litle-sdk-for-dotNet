using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCancelSubscription : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(
                ".*<litleOnlineRequest.*?<cancelSubscription>\r\n<subscriptionId>12345</subscriptionId>\r\n</cancelSubscription>\r\n</litleOnlineRequest>.*?.*",
                "<litleOnlineResponse version='8.20' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><cancelSubscriptionResponse><subscriptionId>12345</subscriptionId></cancelSubscriptionResponse></litleOnlineResponse>");

            Litle.CancelSubscription(new cancelSubscription {subscriptionId = 12345});

            //TODO: Write assertions!
        }
    }
}
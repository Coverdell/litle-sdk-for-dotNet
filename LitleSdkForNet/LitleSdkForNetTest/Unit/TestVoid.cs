using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestVoid : LitleOnlineTestBase
    {
        [Test]
        public void TestRecyclingDataOnVoidResponse()
        {
            SetupCommunications(".*",
                "<litleOnlineResponse version='8.16' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><voidResponse><litleTxnId>123</litleTxnId><response>000</response><responseTime>2013-01-31T15:48:09</responseTime><postDate>2013-01-31</postDate><message>Approved</message><recycling><creditLitleTxnId>456</creditLitleTxnId></recycling></voidResponse></litleOnlineResponse>");

            var response = Litle.DoVoid(new voidTxn {litleTxnId = 123});

            Assert.AreEqual(123, response.litleTxnId);
            Assert.AreEqual(456, response.recycling.creditLitleTxnId);
        }

        [Test]
        public void TestRecyclingDataOnVoidResponseIsOptional()
        {
            SetupCommunications(".*",
                "<litleOnlineResponse version='8.16' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><voidResponse><litleTxnId>123</litleTxnId><response>000</response><responseTime>2013-01-31T15:48:09</responseTime><postDate>2013-01-31</postDate><message>Approved</message></voidResponse></litleOnlineResponse>");

            var response = Litle.DoVoid(new voidTxn {litleTxnId = 123});

            Assert.AreEqual(123, response.litleTxnId);
            Assert.IsNull(response.recycling);
        }
    }
}
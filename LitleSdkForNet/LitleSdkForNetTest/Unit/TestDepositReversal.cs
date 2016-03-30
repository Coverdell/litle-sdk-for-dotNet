using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestDepositReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(".*<litleTxnId>123</litleTxnId>.*",
                "<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><depositReversalResponse><litleTxnId>123</litleTxnId></depositReversalResponse></litleOnlineResponse>");

            var response = Litle.DepositReversal(new depositReversal
            {
                id = "a",
                reportGroup = "b",
                litleTxnId = "123"
            });

            Assert.AreEqual("123", response.litleTxnId);
        }
    }
}
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestUnloadReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(".*<litleTxnId>123</litleTxnId>.*",
                "<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><unloadReversalResponse><litleTxnId>123</litleTxnId></unloadReversalResponse></litleOnlineResponse>");

            var response = Litle.UnloadReversal(new unloadReversal
            {
                id = "a",
                reportGroup = "b",
                litleTxnId = "123"
            });

            Assert.AreEqual("123", response.litleTxnId);
        }
    }
}
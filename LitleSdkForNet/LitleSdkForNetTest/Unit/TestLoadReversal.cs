using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestLoadReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(".*<litleTxnId>123</litleTxnId>.*",
                "<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><loadReversalResponse><litleTxnId>123</litleTxnId></loadReversalResponse></litleOnlineResponse>");

            var response = Litle.LoadReversal(new loadReversal
            {
                id = "a",
                reportGroup = "b",
                litleTxnId = "123"
            });

            Assert.AreEqual("123", response.litleTxnId);
        }
    }
}
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestActivateReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(".*<litleTxnId>123</litleTxnId>.*",
                "<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><activateReversalResponse><litleTxnId>123</litleTxnId></activateReversalResponse></litleOnlineResponse>");

            var response = Litle.ActivateReversal(new activateReversal
            {
                id = "a",
                reportGroup = "b",
                litleTxnId = "123"
            });

            Assert.AreEqual("123", response.litleTxnId);
        }
    }
}
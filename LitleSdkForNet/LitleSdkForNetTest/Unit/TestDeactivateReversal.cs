using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestDeactivateReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSimple()
        {
            SetupCommunications(".*<litleTxnId>123</litleTxnId>.*",
                "<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><deactivateReversalResponse><litleTxnId>123</litleTxnId></deactivateReversalResponse></litleOnlineResponse>");

            var response = Litle.DeactivateReversal(new deactivateReversal
            {
                id = "a",
                reportGroup = "b",
                litleTxnId = "123"
            });

            Assert.AreEqual("123", response.litleTxnId);
        }
    }
}
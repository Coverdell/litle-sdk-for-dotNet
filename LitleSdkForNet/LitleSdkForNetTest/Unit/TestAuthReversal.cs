using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestAuthReversal : LitleOnlineTestBase
    {
        [Test]
        public void TestSurchargeAmount()
        {
            SetupCommunications(
                ".*<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<payPalNotes>note</payPalNotes>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authReversalResponse><litleTxnId>123</litleTxnId></authReversalResponse></litleOnlineResponse>");

            Litle.AuthReversal(new authReversal
            {
                litleTxnId = 3,
                amount = 2,
                surchargeAmount = 1,
                payPalNotes = "note",
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            SetupCommunications(".*<amount>2</amount>\r\n<payPalNotes>note</payPalNotes>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authReversalResponse><litleTxnId>123</litleTxnId></authReversalResponse></litleOnlineResponse>");

            Litle.AuthReversal(new authReversal
            {
                litleTxnId = 3,
                amount = 2,
                payPalNotes = "note",
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }
    }
}
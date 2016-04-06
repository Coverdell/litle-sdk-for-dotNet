using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCredit : LitleOnlineTestBase
    {
        [Test]
        public void TestActionReasonOnOrphanedRefund()
        {
            SetupCommunications(".*<actionReason>SUSPECT_FRAUD</actionReason>.*",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets",
                actionReason = "SUSPECT_FRAUD"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestOrderSource_Set()
        {
            SetupCommunications(".*<credit.*<amount>2</amount>.*<orderSource>ecommerce</orderSource>.*</credit>.*",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                orderId = "12344",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSecondaryAmount_Orphan()
        {
            SetupCommunications(
                ".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                secondaryAmount = 1,
                orderId = "3",
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSecondaryAmount_Tied()
        {
            SetupCommunications(
                ".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<process.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                secondaryAmount = 1,
                litleTxnId = 3,
                processingInstructions = new processingInstructions(),
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_Tied()
        {
            SetupCommunications(
                ".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<process.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                surchargeAmount = 1,
                litleTxnId = 3,
                processingInstructions = new processingInstructions(),
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_TiedOptional()
        {
            SetupCommunications(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<processi.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                litleTxnId = 3,
                reportGroup = "Planets",
                processingInstructions = new processingInstructions()
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_Orphan()
        {
            SetupCommunications(
                ".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                surchargeAmount = 1,
                orderId = "3",
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount_OrphanOptional()
        {
            SetupCommunications(
                ".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                orderId = "3",
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestPos_Tied()
        {
            SetupCommunications(
                ".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<pos>\r\n<terminalId>abc123</terminalId></pos>\r\n<payPalNotes>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                pos = new pos {terminalId = "abc123"},
                litleTxnId = 3,
                reportGroup = "Planets",
                payPalNotes = "notes"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestPos_TiedOptional()
        {
            SetupCommunications(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<payPalNotes>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Litle.Credit(new credit
            {
                amount = 2,
                litleTxnId = 3,
                reportGroup = "Planets",
                payPalNotes = "notes"
            });

            //TODO: Write assertions!
        }
    }
}
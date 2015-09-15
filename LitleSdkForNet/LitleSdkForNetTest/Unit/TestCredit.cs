using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCredit : TestBase
    {
        private const string Value = @"
            <litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                <creditResponse>
                    <litleTxnId>123</litleTxnId>
                </creditResponse>
            </litleOnlineResponse>";

        [Test]
        public void TestActionReasonOnOrphanedRefund()
        {
            var credit = new Credit
            {
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets",
                ActionReason = "SUSPECT_FRAUD"
            };
            var regex = FormMatchExpression(
                "<actionReason>SUSPECT_FRAUD</actionReason>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestOrderSource_Set()
        {
            var credit = new Credit
            {
                OrderId = "12344",
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };
            var regex = FormMatchExpression(
                "<credit.*",
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>",
                "</credit>");

            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSecondaryAmount_Orphan()
        {
            var credit = new Credit
            {
                Amount = 2,
                SecondaryAmount = 1,
                OrderId = "3",
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<orderId>3</orderId>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSecondaryAmount_Tied()
        {
            var credit = new Credit
            {
                Amount = 2,
                SecondaryAmount = 1,
                LitleTxnId = 3,
                ProcessingInstructions = new ProcessingInstructions(),
                ReportGroup = "Planets"
            };
            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<process.*");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_Tied()
        {
            var credit = new Credit
            {
                Amount = 2,
                SurchargeAmount = 1,
                LitleTxnId = 3,
                ProcessingInstructions = new ProcessingInstructions(),
                ReportGroup = "Planets"
            };
             
             var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<process.*");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_TiedOptional()
        {
            var credit = new Credit
            {
                Amount = 2,
                LitleTxnId = 3,
                ReportGroup = "Planets",
                ProcessingInstructions = new ProcessingInstructions()
            };
            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<processingInstructions />");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_Orphan()
        {
            var credit = new Credit
            {
                Amount = 2,
                SurchargeAmount = 1,
                OrderId = "3",
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<orderId>3</orderId>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_OrphanOptional()
        {
            var credit = new Credit
            {
                Amount = 2,
                OrderId = "3",
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderId>3</orderId>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestPos_Tied()
        {
            var credit = new Credit
            {
                Amount = 2,
                Pos = new Pos {TerminalId = "abc123"},
                LitleTxnId = 3,
                ReportGroup = "Planets",
                PayPalNotes = "notes"
            };
            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<pos>",
                "<terminalId>abc123</terminalId>",
                "</pos>",
                "<payPalNotes>notes</payPalNotes>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }

        [Test]
        public void TestPos_TiedOptional()
        {
            var credit = new Credit {Amount = 2, LitleTxnId = 3, ReportGroup = "Planets", PayPalNotes = "notes"};
            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<payPalNotes>");
            MockLitlePost(regex, Value);
            Litle.Credit(credit);
        }
    }
}
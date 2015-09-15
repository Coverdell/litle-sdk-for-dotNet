using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCapture : TestBase
    {
        [Test]
        public void TestSurchargeAmount()
        {
            var capture = new Capture
            {
                LitleTxnId = 3,
                Amount = 2,
                SurchargeAmount = 1,
                PayPalNotes = "note",
                ReportGroup = "Planets"
            };

            const string value = @"
                <litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <captureResponse>
                        <litleTxnId>123</litleTxnId>
                    </captureResponse>
                </litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<payPalNotes>note</payPalNotes>");
            MockLitlePost(regex, value);
            Litle.Capture(capture);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var capture = new Capture {LitleTxnId = 3, Amount = 2, PayPalNotes = "note", ReportGroup = "Planets"};
            const string value = @"
                <litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <captureResponse>
                        <litleTxnId>123</litleTxnId>
                    </captureResponse>
                </litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<payPalNotes>note</payPalNotes>");
            MockLitlePost(regex, value);
            Litle.Capture(capture);
        }
    }
}
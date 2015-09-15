using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestAuthReversal : TestBase
    {
        private const string ValidResponse = @"
                <litleOnlineResponse version='8.14' 
                                     response='0' message='Valid Format'
                                     xmlns='http://www.litle.com/schema'>
                    <authReversalResponse>
                        <litleTxnId>123</litleTxnId>
                    </authReversalResponse>
                </litleOnlineResponse>";

        [Test]
        public void TestSurchargeAmount()
        {
            var reversal = new AuthReversal
            {
                LitleTxnId = 3,
                Amount = 2,
                SurchargeAmount = 1,
                PayPalNotes = "note",
                ReportGroup = "Planets"
            };

            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<payPalNotes>note</payPalNotes>");

            MockLitlePost(regex, ValidResponse);
            Litle.AuthReversal(reversal);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var reversal = new AuthReversal
            {
                LitleTxnId = 3, 
                Amount = 2, 
                PayPalNotes = "note", 
                ReportGroup = "Planets"
            };

            var regex = FormMatchExpression(
                "<litleTxnId>3</litleTxnId>",
                "<amount>2</amount>",
                "<payPalNotes>note</payPalNotes>");

            MockLitlePost(regex, ValidResponse);
            Litle.AuthReversal(reversal);
        }
    }
}
using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestActivateReversal : TestBase
    {
        [Test]
        public void TestSimple()
        {
            var activateReversal = new ActivateReversal
            {
                ID = "a", 
                ReportGroup = "b", 
                LitleTxnId = "123"
            };
            
            const string value = @"
                <litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <activateReversalResponse>
                        <litleTxnId>123</litleTxnId>
                    </activateReversalResponse>
                </litleOnlineResponse>";

            var regex = FormMatchExpression(
                "<activateReversal reportGroup=\"b\" id=\"a\">",
                "<litleTxnId>123</litleTxnId>",
                "</activateReversal>");

            MockLitlePost(regex, value);
            
            var response = Litle.ActivateReversal(activateReversal);
            Assert.AreEqual(123, response.LitleTxnId);
        }
    }
}
using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestUpdateCardValidationNumOnToken : TestBase
    {
        [Test]
        public void TestSimpleRequest()
        {
            var update = new UpdateCardValidationNumOnToken
            {
                OrderId = "12344",
                LitleToken = "1111222233334444",
                CardValidationNum = "321",
                ID = "123",
                ReportGroup = "Default Report Group"
            };

            var regex = FormMatchExpression(
                "<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\"",
                "<orderId>12344</orderId>",
                "<litleToken>1111222233334444</litleToken>",
                "<cardValidationNum>321</cardValidationNum>",
                "</updateCardValidationNumOnToken>");
            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><orderId>12344</orderId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>";
            MockLitlePost(regex, value);
            Litle.UpdateCardValidationNumOnToken(update);
        }

        [Test]
        public void TestOrderIdIsOptional()
        {
            var update = new UpdateCardValidationNumOnToken
            {
                OrderId = null,
                LitleToken = "1111222233334444",
                CardValidationNum = "321",
                ID = "123",
                ReportGroup = "Default Report Group"
            };

            var regex = FormMatchExpression(
                "<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\".*",
                "<litleToken>1111222233334444</litleToken>",
                "<cardValidationNum>321</cardValidationNum>",
                "</updateCardValidationNumOnToken>");
            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>";
            MockLitlePost(regex, value);
            var response = Litle.UpdateCardValidationNumOnToken(update);
            Assert.IsNotNull(response);
            Assert.IsNull(response.OrderId);
        }
    }
}
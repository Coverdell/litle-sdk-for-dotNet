using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestUpdateCardValidationNumOnToken : LitleOnlineTestBase
    {
        [Test]
        public void TestSimpleRequest()
        {
            SetupCommunications(
                ".*<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\".*<orderId>12344</orderId>.*<litleToken>1111222233334444</litleToken>.*<cardValidationNum>321</cardValidationNum>.*</updateCardValidationNumOnToken>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><orderId>12344</orderId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>");

            Litle.UpdateCardValidationNumOnToken(new updateCardValidationNumOnToken
            {
                orderId = "12344",
                litleToken = "1111222233334444",
                cardValidationNum = "321",
                id = "123",
                reportGroup = "Default Report Group"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestOrderIdIsOptional()
        {
            SetupCommunications(
                ".*<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\".*<litleToken>1111222233334444</litleToken>.*<cardValidationNum>321</cardValidationNum>.*</updateCardValidationNumOnToken>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>");

            var response = Litle.UpdateCardValidationNumOnToken(new updateCardValidationNumOnToken
            {
                orderId = null,
                litleToken = "1111222233334444",
                cardValidationNum = "321",
                id = "123",
                reportGroup = "Default Report Group"
            });

            Assert.IsNotNull(response);
            Assert.IsNull(response.orderId);
        }
    }
}
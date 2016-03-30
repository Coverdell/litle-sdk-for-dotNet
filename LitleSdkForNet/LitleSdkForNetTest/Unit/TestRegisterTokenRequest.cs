using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestRegisterTokenRequest : LitleOnlineTestBase
    {
        [Test]
        public void TestSimpleRequest()
        {
            SetupCommunications(
                ".*<registerTokenRequest.*<accountNumber>4100000000000001</accountNumber>.*</registerTokenRequest>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "4100000000000001"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestCanContainCardValidationNum()
        {
            SetupCommunications(
                ".*<registerTokenRequest.*<accountNumber>4100000000000001</accountNumber>.*<cardValidationNum>123</cardValidationNum>.*</registerTokenRequest>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "4100000000000001",
                cardValidationNum = "123"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSimpleRequestWithApplepay()
        {
            SetupCommunications(
                ".*<registerTokenRequest.*<applepay>.*?<data>user</data>.*?</applepay>.*?</registerTokenRequest>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                applepay = new applepayType
                {
                    header = new applepayHeaderType
                    {
                        applicationData = "454657413164",
                        ephemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        publicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
                        transactionId = "1234"
                    },
                    data = "user",
                    signature = "sign",
                    version = "1"
                }
            });

            //TODO: Write assertions!
        }
    }
}
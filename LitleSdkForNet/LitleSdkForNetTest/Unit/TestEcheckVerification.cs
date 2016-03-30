using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestEcheckVerification : LitleOnlineTestBase
    {
        [Test]
        public void TestMerchantData()
        {
            SetupCommunications(".*<echeckVerification.*<orderId>1</orderId>.*<amount>2</amount.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*",
                "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVerificationResponse><litleTxnId>123</litleTxnId></echeckVerificationResponse></litleOnlineResponse>");

            Litle.EcheckVerification(new echeckVerification
            {
                orderId = "1",
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                billToAddress = new contact
                {
                    addressLine1 = "900",
                    city = "ABC",
                    state = "MA"
                },
                merchantData = new merchantDataType
                {
                    campaign = "camp",
                    affiliate = "affil",
                    merchantGroupingId = "mgi"
                }
            });

            //TODO: Write assertions!
        }
    }
}
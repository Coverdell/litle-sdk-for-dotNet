using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestEcheckVoid : LitleOnlineTestBase
    {
        [Test]
        public void TestFraudFilterOverride()
        {
            SetupCommunications(".*<echeckVoid.*<litleTxnId>123456789.*",
                "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVoidResponse><litleTxnId>123</litleTxnId></echeckVoidResponse></litleOnlineResponse>");

            Litle.EcheckVoid(new echeckVoid {litleTxnId = 123456789});

            //TODO: Write assertions!
        }

        [Test]
        public void SimpleForceCaptureWithSecondaryAmount()
        {
            var response = Litle.ForceCapture(new forceCapture
            {
                amount = 106,
                secondaryAmount = 50,
                orderId = "12344",
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });

            Assert.AreEqual("Approved", response.message);
        }
    }
}
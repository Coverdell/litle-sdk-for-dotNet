using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestEcheckVoid : TestBase
    {
        [Test]
        public void TestFraudFilterOverride()
        {
            var echeckVoid = new EcheckVoid {LitleTxnId = 123456789};
            const string regex = ".*<echeckVoid.*<litleTxnId>123456789.*";
            const string value = @"
                <litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <echeckVoidResponse>
                        <litleTxnId>123</litleTxnId>
                    </echeckVoidResponse>
                </litleOnlineResponse>";

            MockLitlePost(regex, value);
            Litle.EcheckVoid(echeckVoid);
        }

        [Test]
        public void SimpleForceCaptureWithSecondaryAmount()
        {
            var forcecapture = new ForceCapture
            {
                Amount = 106,
                SecondaryAmount = 50,
                OrderId = "12344",
                OrderSource = OrderSourceType.Ecommerce,
                Card = new CardType
                {
                    Type = MethodOfPaymentTypeEnum.VI,
                    Number = "4100000000000001",
                    ExpDate = "1210"
                }
            };
            var regex = FormMatchExpression(
                "<forceCapture.*>",
                "<amount>106</amount>",
                "<secondaryAmount>50</secondaryAmount>");
            const string value = @"
                <litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'>
                    <forceCaptureResponse>
                        <message>Approved</message>
                    </forceCaptureResponse>
                </litleOnlineResponse>";
            MockLitlePost(regex, value);
            var response = Litle.ForceCapture(forcecapture);
            Assert.AreEqual("Approved", response.Message);
        }
    }
}
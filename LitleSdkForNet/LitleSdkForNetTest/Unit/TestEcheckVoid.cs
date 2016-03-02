using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestEcheckVoid
    {
        private LitleOnline litle;
        private IDictionary<string, StringBuilder> _memoryStreams;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            _memoryStreams = new Dictionary<string, StringBuilder>();
            litle = new LitleOnline(_memoryStreams);
        }

        [Test]
        public void TestFraudFilterOverride()
        {
            var echeckVoid = new EcheckVoid();
            echeckVoid.LitleTxnId = 123456789;

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(".*<echeckVoid.*<litleTxnId>123456789.*", RegexOptions.Singleline),
                        It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVoidResponse><litleTxnId>123</litleTxnId></echeckVoidResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.EcheckVoid(echeckVoid);
        }

        [Test]
        public void simpleForceCaptureWithSecondaryAmount()
        {
            var forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.SecondaryAmount = 50;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            forcecapture.Card = card;
            var response = litle.ForceCapture(forcecapture);
            Assert.AreEqual("Approved", response.message);
        }
    }
}

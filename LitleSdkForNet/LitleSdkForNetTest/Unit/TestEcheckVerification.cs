using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Moq;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestEcheckVerification
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
        public void TestMerchantData()
        {
            var echeckVerification = new EcheckVerification();
            echeckVerification.OrderId = "1";
            echeckVerification.Amount = 2;
            echeckVerification.OrderSource = OrderSourceType.Ecommerce;
            echeckVerification.BillToAddress = new Contact();
            echeckVerification.BillToAddress.AddressLine1 = "900";
            echeckVerification.BillToAddress.City = "ABC";
            echeckVerification.BillToAddress.State = "MA";
            echeckVerification.MerchantData = new MerchantDataType();
            echeckVerification.MerchantData.Campaign = "camp";
            echeckVerification.MerchantData.Affiliate = "affil";
            echeckVerification.MerchantData.MerchantGroupingId = "mgi";

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(
                Communications =>
                    Communications.HttpPost(
                        It.IsRegex(
                            ".*<echeckVerification.*<orderId>1</orderId>.*<amount>2</amount.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*",
                            RegexOptions.Singleline), It.IsAny<Dictionary<string, string>>()))
                .Returns(
                    "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVerificationResponse><litleTxnId>123</litleTxnId></echeckVerificationResponse></litleOnlineResponse>");

            var mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.EcheckVerification(echeckVerification);
        }
    }
}

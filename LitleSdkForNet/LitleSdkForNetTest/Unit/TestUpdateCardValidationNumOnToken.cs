using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestUpdateCardValidationNumOnToken
    {
        
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestSimpleRequest()
        {
            UpdateCardValidationNumOnToken update = new UpdateCardValidationNumOnToken();
            update.OrderId = "12344";
            update.LitleToken = "1111222233334444";
            update.CardValidationNum = "321";
            update.id = "123";
            update.reportGroup = "Default Report Group";
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\".*<orderId>12344</orderId>.*<litleToken>1111222233334444</litleToken>.*<cardValidationNum>321</cardValidationNum>.*</updateCardValidationNumOnToken>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><orderId>12344</orderId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.UpdateCardValidationNumOnToken(update);
        }

        [Test]
        public void TestOrderIdIsOptional()
        {
            UpdateCardValidationNumOnToken update = new UpdateCardValidationNumOnToken();
            update.OrderId = null;
            update.LitleToken = "1111222233334444";
            update.CardValidationNum = "321";
            update.id = "123";
            update.reportGroup = "Default Report Group";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<updateCardValidationNumOnToken id=\"123\" reportGroup=\"Default Report Group\".*<litleToken>1111222233334444</litleToken>.*<cardValidationNum>321</cardValidationNum>.*</updateCardValidationNumOnToken>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
            //mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updateCardValidationNumOnTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></updateCardValidationNumOnTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            updateCardValidationNumOnTokenResponse response = litle.UpdateCardValidationNumOnToken(update);
            Assert.IsNotNull(response);
            Assert.IsNull(response.orderId);

        }

    }
}

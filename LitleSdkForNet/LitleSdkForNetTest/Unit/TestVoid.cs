using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestVoid
    {
        
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestRecyclingDataOnVoidResponse()
        {
            VoidTxn voidTxn = new VoidTxn();
            voidTxn.LitleTxnId = 123;
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.16' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><voidResponse><litleTxnId>123</litleTxnId><response>000</response><responseTime>2013-01-31T15:48:09</responseTime><postDate>2013-01-31</postDate><message>Approved</message><recycling><creditLitleTxnId>456</creditLitleTxnId></recycling></voidResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            LitleOnlineResponseTransactionResponseVoidResponse response = litle.DoVoid(voidTxn);
            Assert.AreEqual(123, response.LitleTxnId);
            Assert.AreEqual(456, response.Recycling.CreditLitleTxnId);
        }

        [Test]
        public void TestRecyclingDataOnVoidResponseIsOptional()
        {
            VoidTxn voidTxn = new VoidTxn();
            voidTxn.LitleTxnId = 123;

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.16' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><voidResponse><litleTxnId>123</litleTxnId><response>000</response><responseTime>2013-01-31T15:48:09</responseTime><postDate>2013-01-31</postDate><message>Approved</message></voidResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            LitleOnlineResponseTransactionResponseVoidResponse response = litle.DoVoid(voidTxn);
            Assert.AreEqual(123, response.LitleTxnId);
            Assert.IsNull(response.Recycling);
        }

    }
}

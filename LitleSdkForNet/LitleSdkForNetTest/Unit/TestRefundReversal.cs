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
    class TestRefundReversal
    {        
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestSimple()
        {
            RefundReversal refundReversal = new RefundReversal();
            refundReversal.id = "a";
            refundReversal.reportGroup = "b";
            refundReversal.LitleTxnId = "123";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>123</litleTxnId>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><refundReversalResponse><litleTxnId>123</litleTxnId></refundReversalResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            refundReversalResponse response = litle.RefundReversal(refundReversal);
            Assert.AreEqual("123", response.litleTxnId);
        }


    }
}

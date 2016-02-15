﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;
using Moq;
using System.Text.RegularExpressions;


namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestUnloadReversal
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
        public void TestSimple()
        {
            unloadReversal unloadReversal = new unloadReversal();
            unloadReversal.id = "a";
            unloadReversal.reportGroup = "b";
            unloadReversal.litleTxnId = "123";

            var mock = new Mock<Communications>(_memoryStreams);

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>123</litleTxnId>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><unloadReversalResponse><litleTxnId>123</litleTxnId></unloadReversalResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            unloadReversalResponse response = litle.UnloadReversal(unloadReversal);
            Assert.AreEqual("123", response.litleTxnId);
        }


    }
}

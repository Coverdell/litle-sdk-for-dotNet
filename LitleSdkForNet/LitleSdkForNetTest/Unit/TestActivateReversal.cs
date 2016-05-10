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
    class TestActivateReversal
    {        
        private LitleOnline litle;
        private IDictionary<string, StringBuilder> _cache;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            _cache = new Dictionary<string, StringBuilder>();
            litle = new LitleOnline(_cache);
        }

        [Test]
        public void TestSimple()
        {
            activateReversal activateReversal = new activateReversal();
            activateReversal.id = "a";
            activateReversal.reportGroup = "b";
            activateReversal.litleTxnId = "123";

            var mock = new Mock<Communications>(new Dictionary<string, StringBuilder>());

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>123</litleTxnId>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><activateReversalResponse><litleTxnId>123</litleTxnId></activateReversalResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            activateReversalResponse response = litle.ActivateReversal(activateReversal);
            Assert.AreEqual("123", response.litleTxnId);
        }


    }
}

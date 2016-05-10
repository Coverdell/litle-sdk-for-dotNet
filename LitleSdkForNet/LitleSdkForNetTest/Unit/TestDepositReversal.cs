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
    class TestDepositReversal
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
            depositReversal depositReversal = new depositReversal();
            depositReversal.id = "a";
            depositReversal.reportGroup = "b";
            depositReversal.litleTxnId = "123";

            var mock = new Mock<Communications>(_cache);

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>123</litleTxnId>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.22' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><depositReversalResponse><litleTxnId>123</litleTxnId></depositReversalResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            depositReversalResponse response = litle.DepositReversal(depositReversal);
            Assert.AreEqual("123", response.litleTxnId);
        }


    }
}

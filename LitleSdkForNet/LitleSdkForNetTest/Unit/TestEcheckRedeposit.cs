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
    class TestEcheckRedeposit
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
        public void TestMerchantData()
        {
            echeckRedeposit echeckRedeposit = new echeckRedeposit();
            echeckRedeposit.litleTxnId = 1;
            echeckRedeposit.merchantData = new merchantDataType();
            echeckRedeposit.merchantData.campaign = "camp";
            echeckRedeposit.merchantData.affiliate = "affil";
            echeckRedeposit.merchantData.merchantGroupingId = "mgi";
           
            var mock = new Mock<Communications>(_cache);

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<echeckRedeposit.*<litleTxnId>1</litleTxnId>.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.setCommunication(mockedCommunication);
            litle.EcheckRedeposit(echeckRedeposit);
        }            
    }
}

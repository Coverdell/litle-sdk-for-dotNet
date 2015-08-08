using System;
using System.Collections.Generic;
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

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestMerchantData()
        {
            EcheckRedeposit echeckRedeposit = new EcheckRedeposit();
            echeckRedeposit.litleTxnId = 1;
            echeckRedeposit.MerchantData = new MerchantDataType();
            echeckRedeposit.MerchantData.Campaign = "camp";
            echeckRedeposit.MerchantData.Affiliate = "affil";
            echeckRedeposit.MerchantData.MerchantGroupingId = "mgi";
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<echeckRedeposit.*<litleTxnId>1</litleTxnId>.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.EcheckRedeposit(echeckRedeposit);
        }            
    }
}

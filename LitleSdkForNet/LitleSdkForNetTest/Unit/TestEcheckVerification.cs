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
    class TestEcheckVerification
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
            EcheckVerification echeckVerification = new EcheckVerification();
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
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<echeckVerification.*<orderId>1</orderId>.*<amount>2</amount.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVerificationResponse><litleTxnId>123</litleTxnId></echeckVerificationResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.EcheckVerification(echeckVerification);
        }            
    }
}

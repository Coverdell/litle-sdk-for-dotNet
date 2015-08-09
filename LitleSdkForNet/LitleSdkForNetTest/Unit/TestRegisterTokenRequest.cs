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
    class TestRegisterTokenRequest
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
            RegisterTokenRequestType register = new RegisterTokenRequestType();
            register.OrderId = "12344";
            register.AccountNumber = "4100000000000001";
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<registerTokenRequest.*<accountNumber>4100000000000001</accountNumber>.*</registerTokenRequest>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.RegisterToken(register);
        }

        [Test]
        public void TestCanContainCardValidationNum()
        {
            RegisterTokenRequestType register = new RegisterTokenRequestType();
            register.OrderId = "12344";
            register.AccountNumber = "4100000000000001";
            register.CardValidationNum = "123";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<registerTokenRequest.*<accountNumber>4100000000000001</accountNumber>.*<cardValidationNum>123</cardValidationNum>.*</registerTokenRequest>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.RegisterToken(register);
        }

        [Test]
        public void TestSimpleRequestWithApplepay()
        {
            RegisterTokenRequestType register = new RegisterTokenRequestType();
            register.OrderId = "12344";
            ApplepayType applepay = new ApplepayType();
            ApplepayHeaderType applepayHeaderType = new ApplepayHeaderType();
            applepayHeaderType.ApplicationData = "454657413164";
            applepayHeaderType.EphemeralPublicKey = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.PublicKeyHash = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
            applepayHeaderType.TransactionId = "1234";
            applepay.Header = applepayHeaderType;
            applepay.Data = "user";
            applepay.Signature = "sign";
            applepay.Version = "1";
            register.Applepay = applepay;

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<registerTokenRequest.*<applepay>.*?<data>user</data>.*?</applepay>.*?</registerTokenRequest>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>4</litleTxnId><response>801</response><message>Token Successfully Registered</message><responseTime>2012-10-10T10:17:03</responseTime></registerTokenResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.RegisterToken(register);
        }

    }
}

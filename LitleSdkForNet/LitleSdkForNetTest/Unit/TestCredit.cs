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
    class TestCredit
    {
        
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void SetUpLitle()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void TestActionReasonOnOrphanedRefund()
        {
            Credit credit = new Credit();
            credit.OrderId = "12344";
            credit.Amount = 2;
            credit.OrderSource = OrderSourceType.Ecommerce;
            credit.reportGroup = "Planets";
            credit.ActionReason = "SUSPECT_FRAUD";
           
            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<actionReason>SUSPECT_FRAUD</actionReason>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");
     
            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestOrderSource_Set()
        {
            Credit credit = new Credit();
            credit.OrderId = "12344";
            credit.Amount = 2;
            credit.OrderSource = OrderSourceType.Ecommerce;
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<credit.*<amount>2</amount>.*<orderSource>ecommerce</orderSource>.*</credit>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSecondaryAmount_Orphan()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.SecondaryAmount = 1;
            credit.OrderId = "3";
            credit.OrderSource = OrderSourceType.Ecommerce;
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSecondaryAmount_Tied()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.SecondaryAmount = 1;
            credit.LitleTxnId = 3;
            credit.ProcessingInstructions = new ProcessingInstructions();
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<process.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_Tied()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.SurchargeAmount = 1;
            credit.LitleTxnId = 3;
            credit.ProcessingInstructions = new ProcessingInstructions();
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<process.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_TiedOptional()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.LitleTxnId = 3;
            credit.reportGroup = "Planets";
            credit.ProcessingInstructions = new ProcessingInstructions();

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<processi.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_Orphan()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.SurchargeAmount = 1;
            credit.OrderId = "3";
            credit.OrderSource = OrderSourceType.Ecommerce;
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestSurchargeAmount_OrphanOptional()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.OrderId = "3";
            credit.OrderSource = OrderSourceType.Ecommerce;
            credit.reportGroup = "Planets";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<orderId>3</orderId>\r\n<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestPos_Tied()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.Pos = new Pos();
            credit.Pos.TerminalId = "abc123";
            credit.LitleTxnId = 3;
            credit.reportGroup = "Planets";
            credit.PayPalNotes = "notes";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<pos>\r\n<terminalId>abc123</terminalId></pos>\r\n<payPalNotes>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }

        [Test]
        public void TestPos_TiedOptional()
        {
            Credit credit = new Credit();
            credit.Amount = 2;
            credit.LitleTxnId = 3;
            credit.reportGroup = "Planets";
            credit.PayPalNotes = "notes";

            var mock = new Mock<Communications>();

            mock.Setup(Communications => Communications.HttpPost(It.IsRegex(".*<litleTxnId>3</litleTxnId>\r\n<amount>2</amount>\r\n<payPalNotes>.*", RegexOptions.Singleline), It.IsAny<Dictionary<String, String>>()))
                .Returns("<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            Communications mockedCommunication = mock.Object;
            litle.SetCommunication(mockedCommunication);
            litle.Credit(credit);
        }


    }
}

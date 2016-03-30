﻿using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestForceCapture : LitleOnlineTestBase
    {
        [Test]
        public void TestSecondaryAmount()
        {
            SetupCommunications(
                ".*<amount>2</amount>\r\n<secondaryAmount>1</secondaryAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture
            {
                amount = 2,
                secondaryAmount = 1,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestSurchargeAmount()
        {
            SetupCommunications(
                ".*<amount>2</amount>\r\n<surchargeAmount>1</surchargeAmount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture
            {
                amount = 2,
                surchargeAmount = 1,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }


        [Test]
        public void TestSurchargeAmount_Optional()
        {
            SetupCommunications(".*<amount>2</amount>\r\n<orderSource>ecommerce</orderSource>.*",
                "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture
            {
                amount = 2,
                orderSource = orderSourceType.ecommerce,
                reportGroup = "Planets"
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            SetupCommunications(".*</merchantData>\r\n<debtRepayment>true</debtRepayment>\r\n</forceCapture>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture
            {
                merchantData = new merchantDataType(),
                debtRepayment = true
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            SetupCommunications(".*</merchantData>\r\n<debtRepayment>false</debtRepayment>\r\n</forceCapture>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture
            {
                merchantData = new merchantDataType(),
                debtRepayment = false
            });

            //TODO: Write assertions!
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            SetupCommunications(
                ".*</merchantData>\r\n</forceCapture>.*",
                "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            Litle.ForceCapture(new forceCapture {merchantData = new merchantDataType()});

            //TODO: Write assertions!
        }
    }
}
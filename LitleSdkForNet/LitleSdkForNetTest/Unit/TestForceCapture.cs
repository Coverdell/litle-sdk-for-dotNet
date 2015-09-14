using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestForceCapture : TestBase
    {
        [Test]
        public void TestSecondaryAmount()
        {
            var capture = new ForceCapture
            {
                Amount = 2,
                SecondaryAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(capture);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var capture = new ForceCapture
            {
                Amount = 2,
                SurchargeAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(capture);
        }


        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var capture = new ForceCapture
            {
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(capture);
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            var forceCapture = new ForceCapture
            {
                MerchantData = new MerchantDataType(), 
                DebtRepayment = true
            };

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<merchantData />",
                "<debtRepayment>true</debtRepayment>",
                "</forceCapture>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(forceCapture);
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            var forceCapture = new ForceCapture {MerchantData = new MerchantDataType(), DebtRepayment = false};

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<merchantData />",
                "<debtRepayment>false</debtRepayment>",
                "</forceCapture>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(forceCapture);
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            var forceCapture = new ForceCapture {MerchantData = new MerchantDataType()};

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<merchantData />",
                "</forceCapture>");
            MockLitlePost(regex, value);
            Litle.ForceCapture(forceCapture);
        }
    }
}
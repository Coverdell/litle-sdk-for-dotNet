using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestCaptureGivenAuth : TestBase
    {
        [Test]
        public void TestSecondaryAmount()
        {
            var capture = new CaptureGivenAuth
            {
                Amount = 2,
                SecondaryAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<secondaryAmount>1</secondaryAmount>",
                "<orderSource>ecommerce</orderSource>");

            MockLitlePost(regex, value);
            Litle.CaptureGivenAuth(capture);
        }

        [Test]
        public void TestSurchargeAmount()
        {
            var capture = new CaptureGivenAuth
            {
                Amount = 2,
                SurchargeAmount = 1,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<surchargeAmount>1</surchargeAmount>",
                "<orderSource>ecommerce</orderSource>");

            MockLitlePost(regex, value);
            Litle.CaptureGivenAuth(capture);
        }

        [Test]
        public void TestSurchargeAmount_Optional()
        {
            var capture = new CaptureGivenAuth
            {
                Amount = 2,
                OrderSource = OrderSourceType.Ecommerce,
                ReportGroup = "Planets"
            };

            const string value = "<litleOnlineResponse version='8.14' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<amount>2</amount>",
                "<orderSource>ecommerce</orderSource>");

            MockLitlePost(regex, value);
            Litle.CaptureGivenAuth(capture);
        }

        [Test]
        public void TestDebtRepayment_True()
        {
            var captureGivenAuth = new CaptureGivenAuth {MerchantData = new MerchantDataType(), DebtRepayment = true};

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<merchantData />",
                "<debtRepayment>true</debtRepayment>",
                "</captureGivenAuth>.*");
            MockLitlePost(regex, value);
            Litle.CaptureGivenAuth(captureGivenAuth);
        }

        [Test]
        public void TestDebtRepayment_False()
        {
            var captureGivenAuth = new CaptureGivenAuth {MerchantData = new MerchantDataType(), DebtRepayment = false};

            var regex = FormMatchExpression(
                "<merchantData />",
                "<debtRepayment>false</debtRepayment>",
                "</captureGivenAuth>");
            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";

            MockLitlePost(regex, value);
            Litle.CaptureGivenAuth(captureGivenAuth);
        }

        [Test]
        public void TestDebtRepayment_Optional()
        {
            var captureGivenAuth = new CaptureGivenAuth {MerchantData = new MerchantDataType()};

            const string value = "<litleOnlineResponse version='8.19' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>";
            var regex = FormMatchExpression(
                "<merchantData />",
                "</captureGivenAuth>");
            MockLitlePost(regex, value);

            Litle.CaptureGivenAuth(captureGivenAuth);
        }
    }
}
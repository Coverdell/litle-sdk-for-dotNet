using Litle.Sdk.Requests;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    class TestEcheckRedeposit : TestBase
    {
        [Test]
        public void TestMerchantData()
        {
            var echeckRedeposit = new EcheckRedeposit
            {
                LitleTxnId = 1,
                MerchantData = new MerchantDataType
                {
                    Campaign = "camp",
                    Affiliate = "affil",
                    MerchantGroupingId = "mgi"
                }
            };

            var regex = FormMatchExpression(
                "<echeckRedeposit.*>",
                "<merchantData>",
                "<campaign>camp</campaign>",
                "<affiliate>affil</affiliate>",
                "<merchantGroupingId>mgi</merchantGroupingId>",
                "</merchantData>",
                "<litleTxnId>1</litleTxnId>");
            const string value = "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>";

            MockLitlePost(regex, value);
            Litle.EcheckRedeposit(echeckRedeposit);
        }            
    }
}
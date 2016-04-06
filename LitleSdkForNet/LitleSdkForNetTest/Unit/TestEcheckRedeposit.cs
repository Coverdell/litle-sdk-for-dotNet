using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestEcheckRedeposit : LitleOnlineTestBase
    {
        [Test]
        public void TestMerchantData()
        {
            SetupCommunications(".*<echeckRedeposit.*<litleTxnId>1</litleTxnId>.*<merchantData>.*<campaign>camp</campaign>.*<affiliate>affil</affiliate>.*<merchantGroupingId>mgi</merchantGroupingId>.*</merchantData>.*",
                "<litleOnlineResponse version='8.13' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>");

            Litle.EcheckRedeposit(new echeckRedeposit
            {
                litleTxnId = 1,
                merchantData = new merchantDataType
                {
                    campaign = "camp",
                    affiliate = "affil",
                    merchantGroupingId = "mgi"
                }
            });

            //TODO: Write assertions!
        }
    }
}
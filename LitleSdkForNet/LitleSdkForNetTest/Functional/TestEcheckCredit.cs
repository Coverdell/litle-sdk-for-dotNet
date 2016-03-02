using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestEcheckCredit
    {
        private LitleOnline litle;
        private IDictionary<string, StringBuilder> _memoryStreams;

        [TestFixtureSetUp]
        public void beforeClass()
        {
            _memoryStreams = new Dictionary<string, StringBuilder>();
            litle = new LitleOnline(_memoryStreams);
        }

        [Test]
        public void simpleEcheckCredit()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.LitleTxnId = 123456789101112L;
            var response = litle.EcheckCredit(echeckcredit);

            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void noLitleTxnId()
        {
            var echeckcredit = new EcheckCredit();
            try
            {
                litle.EcheckCredit(echeckcredit);
                Assert.Fail("Expected exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.IsTrue(e.Message.Contains("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void echeckCreditWithEcheck()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            var response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckCreditWithToken()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeckToken = new EcheckTokenType();
            echeckToken.AccType = echeckAccountTypeEnum.Checking;
            echeckToken.LitleToken = "1234565789012";
            echeckToken.RoutingNum = "123456789";
            echeckToken.CheckNum = "123455";
            echeckcredit.EcheckToken = echeckToken;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            var response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void missingBilling()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            try
            {
                litle.EcheckCredit(echeckcredit);
                Assert.Fail("Expected exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.IsTrue(e.Message.Contains("Error validating xml data against the schema"));
            }
        }

        [Test]
        public void echeckCreditWithSecondaryAmountWithOrderIdAndCcdPaymentInfo()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.SecondaryAmount = 50;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeck.CcdPaymentInformation = "9876554";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            var response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckCreditWithSecondaryAmountWithLitleTxnId()
        {
            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.SecondaryAmount = 50;
            echeckcredit.LitleTxnId = 12345L;
            var response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestEcheckCredit
    {
        private LitleOnline litle;

        [TestFixtureSetUp]
        public void beforeClass()
        {
            litle = new LitleOnline();
        }

        [Test]
        public void simpleEcheckCredit()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.LitleTxnId = 123456789101112L;
            echeckCreditResponse response = litle.EcheckCredit(echeckcredit);

            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void noLitleTxnId()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
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
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            echeckCreditResponse response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckCreditWithToken()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckTokenType echeckToken = new EcheckTokenType();
            echeckToken.AccType = echeckAccountTypeEnum.Checking;
            echeckToken.LitleToken = "1234565789012";
            echeckToken.RoutingNum = "123456789";
            echeckToken.CheckNum = "123455";
            echeckcredit.EcheckToken = echeckToken;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            echeckCreditResponse response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void missingBilling()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
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
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.SecondaryAmount = 50;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "123456789";
            echeck.CheckNum = "123455";
            echeck.CcdPaymentInformation = "9876554";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;
            echeckCreditResponse response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }

        [Test]
        public void echeckCreditWithSecondaryAmountWithLitleTxnId()
        {
            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.SecondaryAmount = 50;
            echeckcredit.LitleTxnId = 12345L;
            echeckCreditResponse response = litle.EcheckCredit(echeckcredit);
            Assert.AreEqual("Approved", response.message);
        }
    }
}

using System;
using NUnit.Framework;

namespace Litle.Sdk.Test.Unit
{
    [TestFixture]
    internal class TestLitleOnline : LitleOnlineTestBase
    {
        [Test]
        public void TestAuth()
        {
            SetupCommunications(
                ".*<litleOnlineRequest.*<authorization.*<card>.*<number>4100000000000002</number>.*</card>.*</authorization>.*",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            var authorize = Litle.Authorize(new authorization
            {
                reportGroup = "Planets",
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(123, authorize.litleTxnId);
        }

        [Test]
        public void TestAuthReversal()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<authReversal.*?<litleTxnId>12345678000</litleTxnId>.*?</authReversal>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authReversalResponse><litleTxnId>123</litleTxnId></authReversalResponse></litleOnlineResponse>");

            var authreversalresponse = Litle.AuthReversal(new authReversal
            {
                litleTxnId = 12345678000,
                amount = 106,
                payPalNotes = "Notes"
            });

            Assert.AreEqual(123, authreversalresponse.litleTxnId);
        }

        [Test]
        public void TestCapture()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<capture.*?<litleTxnId>123456000</litleTxnId>.*?</capture>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureResponse><litleTxnId>123</litleTxnId></captureResponse></litleOnlineResponse>");

            var captureresponse = Litle.Capture(new capture
            {
                litleTxnId = 123456000,
                amount = 106,
                payPalNotes = "Notes"
            });

            Assert.AreEqual(123, captureresponse.litleTxnId);
        }

        [Test]
        public void TestCaptureGivenAuth()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<captureGivenAuth.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</captureGivenAuth>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><captureGivenAuthResponse><litleTxnId>123</litleTxnId></captureGivenAuthResponse></litleOnlineResponse>");

            var caputregivenauthresponse = Litle.CaptureGivenAuth(new captureGivenAuth
            {
                orderId = "12344",
                amount = 106,
                authInformation = new authInformation
                {
                    authDate = new DateTime(2002, 10, 9),
                    authCode = "543216",
                    authAmount = 12345
                },
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(123, caputregivenauthresponse.litleTxnId);
        }

        [Test]
        public void TestCredit()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<credit.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</credit>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><creditResponse><litleTxnId>123</litleTxnId></creditResponse></litleOnlineResponse>");

            var creditresponse = Litle.Credit(new credit
            {
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(123, creditresponse.litleTxnId);
        }

        [Test]
        public void TestEcheckCredit()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<echeckCredit.*?<litleTxnId>123456789101112</litleTxnId>.*?</echeckCredit>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckCreditResponse><litleTxnId>123</litleTxnId></echeckCreditResponse></litleOnlineResponse>");

            var echeckcreditresponse = Litle.EcheckCredit(new echeckCredit
            {
                amount = 12,
                litleTxnId = 123456789101112
            });

            Assert.AreEqual(123, echeckcreditresponse.litleTxnId);
        }

        [Test]
        public void TestEcheckRedeposit()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<echeckRedeposit.*?<litleTxnId>123456</litleTxnId>.*?</echeckRedeposit>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckRedepositResponse><litleTxnId>123</litleTxnId></echeckRedepositResponse></litleOnlineResponse>");

            var echeckredepositresponse = Litle.EcheckRedeposit(new echeckRedeposit {litleTxnId = 123456});

            Assert.AreEqual(123, echeckredepositresponse.litleTxnId);
        }

        [Test]
        public void TestEcheckSale()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<echeckSale.*?<echeck>.*?<accNum>12345657890</accNum>.*?</echeck>.*?</echeckSale>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckSalesResponse><litleTxnId>123</litleTxnId></echeckSalesResponse></litleOnlineResponse>");

            var echecksaleresponse = Litle.EcheckSale(new echeckSale
            {
                orderId = "12345",
                amount = 123456,
                orderSource = orderSourceType.ecommerce,
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });

            Assert.AreEqual(123, echecksaleresponse.litleTxnId);
        }

        [Test]
        public void TestEcheckVerification()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<echeckVerification.*?<echeck>.*?<accNum>12345657890</accNum>.*?</echeck>.*?</echeckVerification>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><echeckVerificationResponse><litleTxnId>123</litleTxnId></echeckVerificationResponse></litleOnlineResponse>");

            var echeckverificaitonresponse = Litle.EcheckVerification(new echeckVerification
            {
                orderId = "12345",
                amount = 123456,
                orderSource = orderSourceType.ecommerce,
                echeck = new echeckType
                {
                    accType = echeckAccountTypeEnum.Checking,
                    accNum = "12345657890",
                    routingNum = "123456789",
                    checkNum = "123455"
                },
                billToAddress = new contact
                {
                    name = "Bob",
                    city = "lowell",
                    state = "MA",
                    email = "litle.com"
                }
            });

            Assert.AreEqual(123, echeckverificaitonresponse.litleTxnId);
        }

        [Test]
        public void TestForceCapture()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<forceCapture.*?<card>.*?<number>4100000000000001</number>.*?</card>.*?</forceCapture>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><forceCaptureResponse><litleTxnId>123</litleTxnId></forceCaptureResponse></litleOnlineResponse>");

            var forcecaptureresponse = Litle.ForceCapture(new forceCapture
            {
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000001",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(123, forcecaptureresponse.litleTxnId);
        }

        [Test]
        public void TestSale()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<sale.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</sale>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><saleResponse><litleTxnId>123</litleTxnId></saleResponse></litleOnlineResponse>");

            var saleresponse = Litle.Sale(new sale
            {
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            });

            Assert.AreEqual(123, saleresponse.litleTxnId);
        }

        [Test]
        public void TestToken()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<registerTokenRequest.*?<accountNumber>1233456789103801</accountNumber>.*?</registerTokenRequest>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><registerTokenResponse><litleTxnId>123</litleTxnId></registerTokenResponse></litleOnlineResponse>");

            var registertokenresponse = Litle.RegisterToken(new registerTokenRequestType
            {
                orderId = "12344",
                accountNumber = "1233456789103801"
            });

            Assert.AreEqual(123, registertokenresponse.litleTxnId);
            Assert.IsNull(registertokenresponse.type);
        }

        [Test]
        public void TestActivate()
        {
            SetupCommunications(".*?<litleOnlineRequest.*?<activate.*?<orderId>2</orderId>.*?</activate>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><activateResponse><litleTxnId>123</litleTxnId></activateResponse></litleOnlineResponse>");

            var activateResponse = Litle.Activate(new activate
            {
                orderId = "2",
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            });

            Assert.AreEqual("123", activateResponse.litleTxnId);
        }

        [Test]
        public void TestDeactivate()
        {
            SetupCommunications(".*?<litleOnlineRequest.*?<deactivate.*?<orderId>2</orderId>.*?</deactivate>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><deactivateResponse><litleTxnId>123</litleTxnId></deactivateResponse></litleOnlineResponse>");

            var deactivateResponse = Litle.Deactivate(new deactivate
            {
                orderId = "2",
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            });

            Assert.AreEqual("123", deactivateResponse.litleTxnId);
        }

        [Test]
        public void TestLoad()
        {
            SetupCommunications(".*?<litleOnlineRequest.*?<load.*?<orderId>2</orderId>.*?</load>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><loadResponse><litleTxnId>123</litleTxnId></loadResponse></litleOnlineResponse>");

            var loadResponse = Litle.Load(new load
            {
                orderId = "2",
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            });

            Assert.AreEqual("123", loadResponse.litleTxnId);
        }

        [Test]
        public void TestUnload()
        {
            SetupCommunications(".*?<litleOnlineRequest.*?<unload.*?<orderId>2</orderId>.*?</unload>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><unloadResponse><litleTxnId>123</litleTxnId></unloadResponse></litleOnlineResponse>");

            var unloadResponse = Litle.Unload(new unload
            {
                orderId = "2",
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            });

            Assert.AreEqual("123", unloadResponse.litleTxnId);
        }

        [Test]
        public void TestBalanceInquiry()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<balanceInquiry.*?<orderId>2</orderId>.*?</balanceInquiry>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><balanceInquiryResponse><litleTxnId>123</litleTxnId></balanceInquiryResponse></litleOnlineResponse>");

            var balanceInquiryResponse = Litle.BalanceInquiry(new balanceInquiry
            {
                orderId = "2",
                orderSource = orderSourceType.ecommerce,
                card = new cardType()
            });

            Assert.AreEqual("123", balanceInquiryResponse.litleTxnId);
        }

        [Test]
        public void TestCreatePlan()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<createPlan.*?<planCode>theCode</planCode>.*?</createPlan>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><createPlanResponse><planCode>theCode</planCode></createPlanResponse></litleOnlineResponse>");

            var createPlanResponse = Litle.CreatePlan(new createPlan {planCode = "theCode"});

            Assert.AreEqual("theCode", createPlanResponse.planCode);
        }

        [Test]
        public void TestUpdatePlan()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<updatePlan.*?<planCode>theCode</planCode>.*?</updatePlan>.*?",
                "<litleOnlineResponse version='8.21' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><updatePlanResponse><planCode>theCode</planCode></updatePlanResponse></litleOnlineResponse>");

            var updatePlanResponse = Litle.UpdatePlan(new updatePlan {planCode = "theCode"});

            Assert.AreEqual("theCode", updatePlanResponse.planCode);
        }

        [Test]
        public void TestLitleOnlineException()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<authorization.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?",
                "<litleOnlineResponse version='8.10' response='1' message='Error validating xml data against the schema' xmlns='http://www.litle.com/schema'><authorizationResponse><litleTxnId>123</litleTxnId></authorizationResponse></litleOnlineResponse>");

            try //TODO: Should the test fail if the concern is successfully executed?
            {
                Litle.Authorize(new authorization
                {
                    reportGroup = "Planets",
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                });
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void TestInvalidOperationException()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<authorization.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?",
                "no xml");

            try //TODO: Should the test fail if the concern is successfully executed?
            {
                Litle.Authorize(new authorization
                {
                    reportGroup = "Planets",
                    orderId = "12344",
                    amount = 106,
                    orderSource = orderSourceType.ecommerce,
                    card = new cardType
                    {
                        type = methodOfPaymentTypeEnum.VI,
                        number = "4100000000000002",
                        expDate = "1210"
                    }
                });
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error validating xml data against the schema", e.Message);
            }
        }

        [Test]
        public void TestDefaultReportGroup()
        {
            SetupCommunications(
                ".*?<litleOnlineRequest.*?<authorization.*? reportGroup=\"Default Report Group\">.*?<card>.*?<number>4100000000000002</number>.*?</card>.*?</authorization>.*?",
                "<litleOnlineResponse version='8.10' response='0' message='Valid Format' xmlns='http://www.litle.com/schema'><authorizationResponse reportGroup='Default Report Group'></authorizationResponse></litleOnlineResponse>");

            var authorize = Litle.Authorize(new authorization
            {
                orderId = "12344",
                amount = 106,
                orderSource = orderSourceType.ecommerce,
                card = new cardType
                {
                    type = methodOfPaymentTypeEnum.VI,
                    number = "4100000000000002",
                    expDate = "1210"
                }
            });

            Assert.AreEqual("Default Report Group", authorize.reportGroup);
        }
    }
}
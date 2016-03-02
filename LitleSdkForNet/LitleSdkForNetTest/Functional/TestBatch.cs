using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Properties;
using NUnit.Framework;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    internal class TestBatch
    {
        private LitleRequest litle;
        private Dictionary<string, string> invalidConfig;
        private Dictionary<string, string> invalidSftpConfig;
        private IDictionary<string, StringBuilder> memoryStreams;

        [TestFixtureSetUp]
        public void setUp()
        {
            memoryStreams = new Dictionary<string, StringBuilder>();

            invalidConfig = new Dictionary<string, string>();
            invalidConfig["url"] = Settings.Default.url;
            invalidConfig["reportGroup"] = Settings.Default.reportGroup;
            invalidConfig["username"] = "badUsername";
            invalidConfig["printxml"] = Settings.Default.printxml;
            invalidConfig["timeout"] = Settings.Default.timeout;
            invalidConfig["proxyHost"] = Settings.Default.proxyHost;
            invalidConfig["merchantId"] = Settings.Default.merchantId;
            invalidConfig["password"] = "badPassword";
            invalidConfig["proxyPort"] = Settings.Default.proxyPort;
            invalidConfig["sftpUrl"] = Settings.Default.sftpUrl;
            invalidConfig["sftpUsername"] = Settings.Default.sftpUsername;
            invalidConfig["sftpPassword"] = Settings.Default.sftpPassword;
            invalidConfig["knownHostsFile"] = Settings.Default.knownHostsFile;
            invalidConfig["requestDirectory"] = Settings.Default.requestDirectory;
            invalidConfig["responseDirectory"] = Settings.Default.responseDirectory;


            invalidSftpConfig = new Dictionary<string, string>();
            invalidSftpConfig["url"] = Settings.Default.url;
            invalidSftpConfig["reportGroup"] = Settings.Default.reportGroup;
            invalidSftpConfig["username"] = Settings.Default.username;
            invalidSftpConfig["printxml"] = Settings.Default.printxml;
            invalidSftpConfig["timeout"] = Settings.Default.timeout;
            invalidSftpConfig["proxyHost"] = Settings.Default.proxyHost;
            invalidSftpConfig["merchantId"] = Settings.Default.merchantId;
            invalidSftpConfig["password"] = Settings.Default.password;
            invalidSftpConfig["proxyPort"] = Settings.Default.proxyPort;
            invalidSftpConfig["sftpUrl"] = Settings.Default.sftpUrl;
            invalidSftpConfig["sftpUsername"] = "badSftpUsername";
            invalidSftpConfig["sftpPassword"] = "badSftpPassword";
            invalidSftpConfig["knownHostsFile"] = Settings.Default.knownHostsFile;
            invalidSftpConfig["requestDirectory"] = Settings.Default.requestDirectory;
            invalidSftpConfig["responseDirectory"] = Settings.Default.responseDirectory;
        }

        [SetUp]
        public void setUpBeforeTest()
        {
            litle = new LitleRequest(memoryStreams);
        }

        [Test]
        public void SimpleBatch()
        {
            var litleBatchRequest = new BatchRequest(memoryStreams);

            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);

            var authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            var card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2;

            litleBatchRequest.AddAuthorization(authorization2);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            var reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            var capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            var capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            var capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            var authInfo = new AuthInformation();
            var authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            var capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            var authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            var creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            var creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            var echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            var echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            var billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            var echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            var echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            var echeckPreNoteSaleObj1 = new EcheckPreNoteSale();
            echeckPreNoteSaleObj1.OrderId = "12345";
            echeckPreNoteSaleObj1.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleObj1.Echeck = echeck;
            echeckPreNoteSaleObj1.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleObj1);

            var echeckPreNoteSaleObj2 = new EcheckPreNoteSale();
            echeckPreNoteSaleObj2.OrderId = "12345";
            echeckPreNoteSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleObj2.Echeck = echeck2;
            echeckPreNoteSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleObj2);

            var echeckPreNoteCreditObj1 = new EcheckPreNoteCredit();
            echeckPreNoteCreditObj1.OrderId = "12345";
            echeckPreNoteCreditObj1.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditObj1.Echeck = echeck;
            echeckPreNoteCreditObj1.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditObj1);

            var echeckPreNoteCreditObj2 = new EcheckPreNoteCredit();
            echeckPreNoteCreditObj2.OrderId = "12345";
            echeckPreNoteCreditObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditObj2.Echeck = echeck2;
            echeckPreNoteCreditObj2.BillToAddress = billToAddress2;

            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            var echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            var forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            var forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            var saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            var registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            var updateCardValidationNumOnToken = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken.OrderId = "12344";
            updateCardValidationNumOnToken.CardValidationNum = "123";
            updateCardValidationNumOnToken.LitleToken = "4100000000000001";

            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);

            var updateCardValidationNumOnToken2 = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken2.OrderId = "12345";
            updateCardValidationNumOnToken2.CardValidationNum = "123";
            updateCardValidationNumOnToken2.LitleToken = "4242424242424242";

            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken2);
            litle.AddBatch(litleBatchRequest);

            var batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(2*2, 10*2));

            var litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            var litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                var authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                while (authorizationResponse != null)
                {
                    Assert.AreEqual("000", authorizationResponse.response);

                    authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                }

                var authReversalResponse = litleBatchResponse.nextAuthReversalResponse();
                while (authReversalResponse != null)
                {
                    Assert.AreEqual("360", authReversalResponse.response);

                    authReversalResponse = litleBatchResponse.nextAuthReversalResponse();
                }

                var captureResponse = litleBatchResponse.nextCaptureResponse();
                while (captureResponse != null)
                {
                    Assert.AreEqual("360", captureResponse.response);

                    captureResponse = litleBatchResponse.nextCaptureResponse();
                }

                var captureGivenAuthResponse = litleBatchResponse.nextCaptureGivenAuthResponse();
                while (captureGivenAuthResponse != null)
                {
                    Assert.AreEqual("000", captureGivenAuthResponse.response);

                    captureGivenAuthResponse = litleBatchResponse.nextCaptureGivenAuthResponse();
                }

                var creditResponse = litleBatchResponse.nextCreditResponse();
                while (creditResponse != null)
                {
                    Assert.AreEqual("000", creditResponse.response);

                    creditResponse = litleBatchResponse.nextCreditResponse();
                }

                var echeckCreditResponse = litleBatchResponse.nextEcheckCreditResponse();
                while (echeckCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckCreditResponse.response);

                    echeckCreditResponse = litleBatchResponse.nextEcheckCreditResponse();
                }

                var echeckRedepositResponse = litleBatchResponse.nextEcheckRedepositResponse();
                while (echeckRedepositResponse != null)
                {
                    Assert.AreEqual("360", echeckRedepositResponse.response);

                    echeckRedepositResponse = litleBatchResponse.nextEcheckRedepositResponse();
                }

                var echeckSalesResponse = litleBatchResponse.nextEcheckSalesResponse();
                while (echeckSalesResponse != null)
                {
                    Assert.AreEqual("000", echeckSalesResponse.response);

                    echeckSalesResponse = litleBatchResponse.nextEcheckSalesResponse();
                }

                var echeckPreNoteSaleResponse = litleBatchResponse.nextEcheckPreNoteSaleResponse();
                while (echeckPreNoteSaleResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteSaleResponse.response);

                    echeckPreNoteSaleResponse = litleBatchResponse.nextEcheckPreNoteSaleResponse();
                }

                var echeckPreNoteCreditResponse = litleBatchResponse.nextEcheckPreNoteCreditResponse();
                while (echeckPreNoteCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteCreditResponse.response);

                    echeckPreNoteCreditResponse = litleBatchResponse.nextEcheckPreNoteCreditResponse();
                }

                var echeckVerificationResponse = litleBatchResponse.nextEcheckVerificationResponse();
                while (echeckVerificationResponse != null)
                {
                    Assert.AreEqual("957", echeckVerificationResponse.response);

                    echeckVerificationResponse = litleBatchResponse.nextEcheckVerificationResponse();
                }

                var forceCaptureResponse = litleBatchResponse.nextForceCaptureResponse();
                while (forceCaptureResponse != null)
                {
                    Assert.AreEqual("000", forceCaptureResponse.response);

                    forceCaptureResponse = litleBatchResponse.nextForceCaptureResponse();
                }

                var registerTokenResponse = litleBatchResponse.nextRegisterTokenResponse();
                while (registerTokenResponse != null)
                {
                    Assert.AreEqual("820", registerTokenResponse.response);

                    registerTokenResponse = litleBatchResponse.nextRegisterTokenResponse();
                }

                var saleResponse = litleBatchResponse.nextSaleResponse();
                while (saleResponse != null)
                {
                    Assert.AreEqual("000", saleResponse.response);

                    saleResponse = litleBatchResponse.nextSaleResponse();
                }

                var updateCardValidationNumOnTokenResponse =
                    litleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
                while (updateCardValidationNumOnTokenResponse != null)
                {
                    Assert.AreEqual("823", updateCardValidationNumOnTokenResponse.response);

                    updateCardValidationNumOnTokenResponse =
                        litleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
                }

                litleBatchResponse = litleResponse.nextBatchResponse();
            }
        }

        [Test]
        public void accountUpdateBatch()
        {
            var litleBatchRequest = new BatchRequest(memoryStreams);

            var accountUpdate1 = new AccountUpdate();
            accountUpdate1.OrderId = "1111";
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            accountUpdate1.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate1);

            var accountUpdate2 = new AccountUpdate();
            accountUpdate2.OrderId = "1112";
            accountUpdate2.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate2);

            litle.AddBatch(litleBatchRequest);
            var batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(0, 1*2));

            var litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            var litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                var accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                while (accountUpdateResponse != null)
                {
                    Assert.AreEqual("301", accountUpdateResponse.response);

                    accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                }
                litleBatchResponse = litleResponse.nextBatchResponse();
            }
        }

        [Test]
        public void RFRBatch()
        {
            var litleBatchRequest = new BatchRequest(memoryStreams);
            litleBatchRequest.Id = "1234567A";

            var accountUpdate1 = new AccountUpdate();
            accountUpdate1.OrderId = "1111";
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4242424242424242";
            card.ExpDate = "1210";
            accountUpdate1.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate1);

            var accountUpdate2 = new AccountUpdate();
            accountUpdate2.OrderId = "1112";
            accountUpdate2.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate2);
            litle.AddBatch(litleBatchRequest);

            var batchName = litle.SendToLitle();
            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(0, 1*2));
            var litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);

            var litleBatchResponse = litleResponse.nextBatchResponse();
            Assert.NotNull(litleBatchResponse);
            while (litleBatchResponse != null)
            {
                var accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                Assert.NotNull(accountUpdateResponse);
                while (accountUpdateResponse != null)
                {
                    Assert.AreEqual("000", accountUpdateResponse.response);

                    accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                }
                litleBatchResponse = litleResponse.nextBatchResponse();
            }

            var litleRfr = new LitleRequest(memoryStreams);
            var rfrRequest = new RfrRequest(memoryStreams);
            var accountUpdateFileRequestData = new AccountUpdateFileRequestData();
            accountUpdateFileRequestData.MerchantId = Settings.Default.merchantId;
            accountUpdateFileRequestData.PostDay = DateTime.Now;
            rfrRequest.AccountUpdateFileRequestData = accountUpdateFileRequestData;

            litleRfr.AddRfrRequest(rfrRequest);

            var rfrBatchName = litleRfr.SendToLitle();

            try
            {
                litle.BlockAndWaitForResponse(rfrBatchName, 120000);
                var litleRfrResponse = litle.ReceiveFromLitle(rfrBatchName);
                Assert.NotNull(litleRfrResponse);
                var rfrResponse = litleRfrResponse.nextRFRResponse();
                Assert.NotNull(rfrResponse);
                while (rfrResponse != null)
                {
                    Assert.AreEqual("1", rfrResponse.response);
                    Assert.AreEqual("The account update file is not ready yet.  Please try again later.",
                        rfrResponse.message);
                    rfrResponse = litleResponse.nextRFRResponse();
                }
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void nullBatchData()
        {
            var litleBatchRequest = new BatchRequest(memoryStreams);

            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);
            try
            {
                litleBatchRequest.AddAuthorization(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);
            try
            {
                litleBatchRequest.AddAuthReversal(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);
            try
            {
                litleBatchRequest.AddCapture(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            var authInfo = new AuthInformation();
            var authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);
            try
            {
                litleBatchRequest.AddCaptureGivenAuth(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);
            try
            {
                litleBatchRequest.AddCredit(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);
            try
            {
                litleBatchRequest.AddEcheckCredit(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            try
            {
                litleBatchRequest.AddEcheckRedeposit(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);
            try
            {
                litleBatchRequest.AddEcheckSale(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);
            try
            {
                litleBatchRequest.AddEcheckVerification(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);
            try
            {
                litleBatchRequest.AddForceCapture(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);
            try
            {
                litleBatchRequest.AddSale(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);
            try
            {
                litleBatchRequest.AddRegisterTokenRequest(null);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            try
            {
                litle.AddBatch(litleBatchRequest);
            }
            catch (NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }

        [Test]
        public void InvalidCredientialsBatch()
        {
            var litleIC = new LitleRequest(memoryStreams, invalidConfig);

            var litleBatchRequest = new BatchRequest(memoryStreams);

            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile      

            litleBatchRequest.AddAuthorization(authorization);

            var authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            var card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2; //This needs to compile

            litleBatchRequest.AddAuthorization(authorization2);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            var reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            var capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            var capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            var capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            var authInfo = new AuthInformation();
            var authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            var capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            var authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            var creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            var creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            var echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            var echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            var billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            var echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            var echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            var echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            var forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            var forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            var saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            var registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            litleIC.AddBatch(litleBatchRequest);

            var batchName = litleIC.SendToLitle();

            litleIC.BlockAndWaitForResponse(batchName, 60*1000*5);

            try
            {
                var litleResponse = litleIC.ReceiveFromLitle(batchName);
                Assert.Fail("Fail to throw a connection exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error occured while attempting to retrieve and save the file from SFTP", e.Message);
            }
        }

        [Test]
        public void InvalidSftpCredientialsBatch()
        {
            var litleISC = new LitleRequest(memoryStreams, invalidSftpConfig);

            var litleBatchRequest = new BatchRequest(memoryStreams);

            var authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile      

            litleBatchRequest.AddAuthorization(authorization);

            var authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            var card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2; //This needs to compile

            litleBatchRequest.AddAuthorization(authorization2);

            var reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            var reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            var capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            var capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            var capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            var authInfo = new AuthInformation();
            var authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            var capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            var authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            var creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            var creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            var echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            var echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            var billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            var echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            var echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            var billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            var echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            var echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            var echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            var echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            var echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            var echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            var forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            var forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            var saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            var saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            var registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            var registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            litleISC.AddBatch(litleBatchRequest);

            try
            {
                var batchName = litleISC.SendToLitle();
                Assert.Fail("Fail to throw a connection exception");
            }
            catch (LitleOnlineException e)
            {
                Assert.AreSame("Error occured while attempting to establish an SFTP connection", e.Message);
            }
        }

        [Test]
        public void SimpleBatchWithSpecialCharacters()
        {
            var litleBatchRequest = new BatchRequest(memoryStreams);

            var authorization = new Authorization();
            authorization.reportGroup = "<ReportGroup>";
            authorization.OrderId = "12344&'\"";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            var card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);

            litle.AddBatch(litleBatchRequest);

            var batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(2*2, 10*2));

            var litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            var litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                var authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                while (authorizationResponse != null)
                {
                    Assert.AreEqual("000", authorizationResponse.response);

                    authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                }

                litleBatchResponse = litleResponse.nextBatchResponse();
            }
        }

        private int estimatedResponseTime(int numAuthsAndSales, int numRest)
        {
            return (int) (5*60*1000 + 2.5*1000 + numAuthsAndSales*(1/5)*1000 + numRest*(1/50)*1000)*5;
        }
    }
}

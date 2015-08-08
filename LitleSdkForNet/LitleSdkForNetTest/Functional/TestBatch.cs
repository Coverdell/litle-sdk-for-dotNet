using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Litle.Sdk;
using System.IO;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestBatch
    {
        private LitleRequest litle;
        private Dictionary<String, String> invalidConfig;
        private Dictionary<String, String> invalidSftpConfig;

        [TestFixtureSetUp]
        public void setUp()
        {
            invalidConfig = new Dictionary<String, String>();
            invalidConfig["url"] = Properties.Settings.Default.url;
            invalidConfig["reportGroup"] = Properties.Settings.Default.reportGroup;
            invalidConfig["username"] = "badUsername";
            invalidConfig["printxml"] = Properties.Settings.Default.printxml;
            invalidConfig["timeout"] = Properties.Settings.Default.timeout;
            invalidConfig["proxyHost"] = Properties.Settings.Default.proxyHost;
            invalidConfig["merchantId"] = Properties.Settings.Default.merchantId;
            invalidConfig["password"] = "badPassword";
            invalidConfig["proxyPort"] = Properties.Settings.Default.proxyPort;
            invalidConfig["sftpUrl"] = Properties.Settings.Default.sftpUrl;
            invalidConfig["sftpUsername"] = Properties.Settings.Default.sftpUsername;
            invalidConfig["sftpPassword"] = Properties.Settings.Default.sftpPassword;
            invalidConfig["knownHostsFile"] = Properties.Settings.Default.knownHostsFile;
            invalidConfig["requestDirectory"] = Properties.Settings.Default.requestDirectory;
            invalidConfig["responseDirectory"] = Properties.Settings.Default.responseDirectory;
           

            invalidSftpConfig = new Dictionary<String, String>();
            invalidSftpConfig["url"] = Properties.Settings.Default.url;
            invalidSftpConfig["reportGroup"] = Properties.Settings.Default.reportGroup;
            invalidSftpConfig["username"] = Properties.Settings.Default.username;
            invalidSftpConfig["printxml"] = Properties.Settings.Default.printxml;
            invalidSftpConfig["timeout"] = Properties.Settings.Default.timeout;
            invalidSftpConfig["proxyHost"] = Properties.Settings.Default.proxyHost;
            invalidSftpConfig["merchantId"] = Properties.Settings.Default.merchantId;
            invalidSftpConfig["password"] = Properties.Settings.Default.password;
            invalidSftpConfig["proxyPort"] = Properties.Settings.Default.proxyPort;
            invalidSftpConfig["sftpUrl"] = Properties.Settings.Default.sftpUrl;
            invalidSftpConfig["sftpUsername"] = "badSftpUsername";
            invalidSftpConfig["sftpPassword"] = "badSftpPassword";
            invalidSftpConfig["knownHostsFile"] = Properties.Settings.Default.knownHostsFile;
            invalidSftpConfig["requestDirectory"] = Properties.Settings.Default.requestDirectory;
            invalidSftpConfig["responseDirectory"] = Properties.Settings.Default.responseDirectory;

        }

        [SetUp]
        public void setUpBeforeTest()
        {
            litle = new LitleRequest();
        }

        [Test]
        public void SimpleBatch()
        {
            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);

            Authorization authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            CardType card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2;

            litleBatchRequest.AddAuthorization(authorization2);
            
            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            AuthReversal reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            Capture capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            CaptureGivenAuth capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            AuthInformation authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            Credit creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            EcheckCredit echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            Contact billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            EcheckRedeposit echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            EcheckSale echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            EcheckPreNoteSale echeckPreNoteSaleObj1 = new EcheckPreNoteSale();
            echeckPreNoteSaleObj1.OrderId = "12345";
            echeckPreNoteSaleObj1.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleObj1.Echeck = echeck;
            echeckPreNoteSaleObj1.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleObj1);

            EcheckPreNoteSale echeckPreNoteSaleObj2 = new EcheckPreNoteSale();
            echeckPreNoteSaleObj2.OrderId = "12345";
            echeckPreNoteSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleObj2.Echeck = echeck2;
            echeckPreNoteSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleObj2);

            EcheckPreNoteCredit echeckPreNoteCreditObj1 = new EcheckPreNoteCredit();
            echeckPreNoteCreditObj1.OrderId = "12345";
            echeckPreNoteCreditObj1.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditObj1.Echeck = echeck;
            echeckPreNoteCreditObj1.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditObj1);

            EcheckPreNoteCredit echeckPreNoteCreditObj2 = new EcheckPreNoteCredit();
            echeckPreNoteCreditObj2.OrderId = "12345";
            echeckPreNoteCreditObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditObj2.Echeck = echeck2;
            echeckPreNoteCreditObj2.BillToAddress = billToAddress2;

            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            EcheckVerification echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            ForceCapture forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            ForceCapture forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            Sale saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            Sale saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            RegisterTokenRequestType registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            RegisterTokenRequestType registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            UpdateCardValidationNumOnToken updateCardValidationNumOnToken = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken.OrderId = "12344";
            updateCardValidationNumOnToken.CardValidationNum = "123";
            updateCardValidationNumOnToken.LitleToken = "4100000000000001";

            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken);

            UpdateCardValidationNumOnToken updateCardValidationNumOnToken2 = new UpdateCardValidationNumOnToken();
            updateCardValidationNumOnToken2.OrderId = "12345";
            updateCardValidationNumOnToken2.CardValidationNum = "123";
            updateCardValidationNumOnToken2.LitleToken = "4242424242424242";

            litleBatchRequest.AddUpdateCardValidationNumOnToken(updateCardValidationNumOnToken2);
            litle.AddBatch(litleBatchRequest);

            string batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(2 * 2, 10 * 2));

            litleResponse litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            batchResponse litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                authorizationResponse authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                while (authorizationResponse != null)
                {
                    Assert.AreEqual("000", authorizationResponse.response);

                    authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
                }

                authReversalResponse authReversalResponse = litleBatchResponse.nextAuthReversalResponse();
                while (authReversalResponse != null)
                {
                    Assert.AreEqual("360", authReversalResponse.response);

                    authReversalResponse = litleBatchResponse.nextAuthReversalResponse();
                }

                captureResponse captureResponse = litleBatchResponse.nextCaptureResponse();
                while (captureResponse != null)
                {
                    Assert.AreEqual("360", captureResponse.response);

                    captureResponse = litleBatchResponse.nextCaptureResponse();
                }

                captureGivenAuthResponse captureGivenAuthResponse = litleBatchResponse.nextCaptureGivenAuthResponse();
                while (captureGivenAuthResponse != null)
                {
                    Assert.AreEqual("000", captureGivenAuthResponse.response);

                    captureGivenAuthResponse = litleBatchResponse.nextCaptureGivenAuthResponse();
                }

                creditResponse creditResponse = litleBatchResponse.nextCreditResponse();
                while (creditResponse != null)
                {
                    Assert.AreEqual("000", creditResponse.response);

                    creditResponse = litleBatchResponse.nextCreditResponse();
                }

                echeckCreditResponse echeckCreditResponse = litleBatchResponse.nextEcheckCreditResponse();
                while (echeckCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckCreditResponse.response);

                    echeckCreditResponse = litleBatchResponse.nextEcheckCreditResponse();
                }

                echeckRedepositResponse echeckRedepositResponse = litleBatchResponse.nextEcheckRedepositResponse();
                while (echeckRedepositResponse != null)
                {
                    Assert.AreEqual("360", echeckRedepositResponse.response);

                    echeckRedepositResponse = litleBatchResponse.nextEcheckRedepositResponse();
                }

                echeckSalesResponse echeckSalesResponse = litleBatchResponse.nextEcheckSalesResponse();
                while (echeckSalesResponse != null)
                {
                    Assert.AreEqual("000", echeckSalesResponse.response);

                    echeckSalesResponse = litleBatchResponse.nextEcheckSalesResponse();
                }

                echeckPreNoteSaleResponse echeckPreNoteSaleResponse = litleBatchResponse.nextEcheckPreNoteSaleResponse();
                while (echeckPreNoteSaleResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteSaleResponse.response);

                    echeckPreNoteSaleResponse = litleBatchResponse.nextEcheckPreNoteSaleResponse();
                }

                echeckPreNoteCreditResponse echeckPreNoteCreditResponse = litleBatchResponse.nextEcheckPreNoteCreditResponse();
                while (echeckPreNoteCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteCreditResponse.response);

                    echeckPreNoteCreditResponse = litleBatchResponse.nextEcheckPreNoteCreditResponse();
                }

                echeckVerificationResponse echeckVerificationResponse = litleBatchResponse.nextEcheckVerificationResponse();
                while (echeckVerificationResponse != null)
                {
                    Assert.AreEqual("957", echeckVerificationResponse.response);

                    echeckVerificationResponse = litleBatchResponse.nextEcheckVerificationResponse();
                }

                forceCaptureResponse forceCaptureResponse = litleBatchResponse.nextForceCaptureResponse();
                while (forceCaptureResponse != null)
                {
                    Assert.AreEqual("000", forceCaptureResponse.response);

                    forceCaptureResponse = litleBatchResponse.nextForceCaptureResponse();
                }

                registerTokenResponse registerTokenResponse = litleBatchResponse.nextRegisterTokenResponse();
                while (registerTokenResponse != null)
                {
                    Assert.AreEqual("820", registerTokenResponse.response);

                    registerTokenResponse = litleBatchResponse.nextRegisterTokenResponse();
                }

                saleResponse saleResponse = litleBatchResponse.nextSaleResponse();
                while (saleResponse != null)
                {
                    Assert.AreEqual("000", saleResponse.response);

                    saleResponse = litleBatchResponse.nextSaleResponse();
                }

                updateCardValidationNumOnTokenResponse updateCardValidationNumOnTokenResponse = litleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
                while (updateCardValidationNumOnTokenResponse != null)
                {
                    Assert.AreEqual("823", updateCardValidationNumOnTokenResponse.response);

                    updateCardValidationNumOnTokenResponse = litleBatchResponse.nextUpdateCardValidationNumOnTokenResponse();
                }

                litleBatchResponse = litleResponse.nextBatchResponse();
            }
        }

        [Test]
        public void accountUpdateBatch()
        {
            BatchRequest litleBatchRequest = new BatchRequest();

            AccountUpdate accountUpdate1 = new AccountUpdate();
            accountUpdate1.OrderId = "1111";
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            accountUpdate1.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate1);

            AccountUpdate accountUpdate2 = new AccountUpdate();
            accountUpdate2.OrderId = "1112";
            accountUpdate2.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate2);

            litle.AddBatch(litleBatchRequest);
            string batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(0, 1 * 2));

            litleResponse litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            batchResponse litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                accountUpdateResponse accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
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
            BatchRequest litleBatchRequest = new BatchRequest();
            litleBatchRequest.ID = "1234567A";

            AccountUpdate accountUpdate1 = new AccountUpdate();
            accountUpdate1.OrderId = "1111";
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4242424242424242";
            card.ExpDate = "1210";
            accountUpdate1.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate1);

            AccountUpdate accountUpdate2 = new AccountUpdate();
            accountUpdate2.OrderId = "1112";
            accountUpdate2.Card = card;

            litleBatchRequest.AddAccountUpdate(accountUpdate2);
            litle.AddBatch(litleBatchRequest);

            string batchName = litle.SendToLitle();
            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(0, 1 * 2));
            litleResponse litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);

            batchResponse litleBatchResponse = litleResponse.nextBatchResponse();
            Assert.NotNull(litleBatchResponse);
            while (litleBatchResponse != null)
            {
                accountUpdateResponse accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                Assert.NotNull(accountUpdateResponse);
                while (accountUpdateResponse != null)
                {
                    Assert.AreEqual("000", accountUpdateResponse.response);

                    accountUpdateResponse = litleBatchResponse.nextAccountUpdateResponse();
                }
                litleBatchResponse = litleResponse.nextBatchResponse();
            }

            LitleRequest litleRfr = new LitleRequest();
            RfrRequest rfrRequest = new RfrRequest();
            AccountUpdateFileRequestData accountUpdateFileRequestData = new AccountUpdateFileRequestData();
            accountUpdateFileRequestData.MerchantId = Properties.Settings.Default.merchantId;
            accountUpdateFileRequestData.PostDay = DateTime.Now;
            rfrRequest.AccountUpdateFileRequestData = accountUpdateFileRequestData;

            litleRfr.AddRfrRequest(rfrRequest);

            string rfrBatchName = litleRfr.SendToLitle();
            
            try
            {
                litle.BlockAndWaitForResponse(rfrBatchName, 120000);
                litleResponse litleRfrResponse = litle.ReceiveFromLitle(rfrBatchName);
                Assert.NotNull(litleRfrResponse);
                RFRResponse rfrResponse = litleRfrResponse.nextRFRResponse();
                Assert.NotNull(rfrResponse);
                while (rfrResponse != null)
                {
                    Assert.AreEqual("1", rfrResponse.response);
                    Assert.AreEqual("The account update file is not ready yet.  Please try again later.", rfrResponse.message);
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
            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);
            try
            {
                litleBatchRequest.AddAuthorization(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);
            try
            {
                litleBatchRequest.AddAuthReversal(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);
            try
            {
                litleBatchRequest.AddCapture(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
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
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);
            try
            {
                litleBatchRequest.AddCredit(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "12345657890";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
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
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);
            try
            {
                litleBatchRequest.AddEcheckRedeposit(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            EcheckSale echeckSaleObj = new EcheckSale();
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
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            EcheckVerification echeckVerificationObject = new EcheckVerification();
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
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            ForceCapture forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);
            try
            {
                litleBatchRequest.AddForceCapture(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            Sale saleObj = new Sale();
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
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            RegisterTokenRequestType registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);
            try
            {
                litleBatchRequest.AddRegisterTokenRequest(null);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

            try
            {
                litle.AddBatch(litleBatchRequest);
            }
            catch (System.NullReferenceException e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }

        [Test]
        public void InvalidCredientialsBatch()
        {
            LitleRequest litleIC = new LitleRequest(invalidConfig);

            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile      

            litleBatchRequest.AddAuthorization(authorization);

            Authorization authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            CardType card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2; //This needs to compile

            litleBatchRequest.AddAuthorization(authorization2);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            AuthReversal reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            Capture capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            CaptureGivenAuth capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            AuthInformation authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            Credit creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            EcheckCredit echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            Contact billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            EcheckRedeposit echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            EcheckSale echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            EcheckVerification echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            ForceCapture forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            ForceCapture forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            Sale saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            Sale saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            RegisterTokenRequestType registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            RegisterTokenRequestType registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            litleIC.AddBatch(litleBatchRequest);

            string batchName = litleIC.SendToLitle();

            litleIC.BlockAndWaitForResponse(batchName, 60*1000*5);

            try
            {
                litleResponse litleResponse = litleIC.ReceiveFromLitle(batchName);
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
            LitleRequest litleISC = new LitleRequest(invalidSftpConfig);

            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.reportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile      

            litleBatchRequest.AddAuthorization(authorization);

            Authorization authorization2 = new Authorization();
            authorization2.reportGroup = "Planets";
            authorization2.OrderId = "12345";
            authorization2.Amount = 106;
            authorization2.OrderSource = OrderSourceType.Ecommerce;
            CardType card2 = new CardType();
            card2.Type = MethodOfPaymentTypeEnum.VI;
            card2.Number = "4242424242424242";
            card2.ExpDate = "1210";
            authorization2.Card = card2; //This needs to compile

            litleBatchRequest.AddAuthorization(authorization2);

            AuthReversal reversal = new AuthReversal();
            reversal.LitleTxnId = 12345678000L;
            reversal.Amount = 106;
            reversal.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal);

            AuthReversal reversal2 = new AuthReversal();
            reversal2.LitleTxnId = 12345678900L;
            reversal2.Amount = 106;
            reversal2.PayPalNotes = "Notes";

            litleBatchRequest.AddAuthReversal(reversal2);

            Capture capture = new Capture();
            capture.LitleTxnId = 123456000;
            capture.Amount = 106;
            capture.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture);

            Capture capture2 = new Capture();
            capture2.LitleTxnId = 123456700;
            capture2.Amount = 106;
            capture2.PayPalNotes = "Notes";

            litleBatchRequest.AddCapture(capture2);

            CaptureGivenAuth capturegivenauth = new CaptureGivenAuth();
            capturegivenauth.Amount = 106;
            capturegivenauth.OrderId = "12344";
            AuthInformation authInfo = new AuthInformation();
            DateTime authDate = new DateTime(2002, 10, 9);
            authInfo.AuthDate = authDate;
            authInfo.AuthCode = "543216";
            authInfo.AuthAmount = 12345;
            capturegivenauth.AuthInformation = authInfo;
            capturegivenauth.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth.Card = card;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth);

            CaptureGivenAuth capturegivenauth2 = new CaptureGivenAuth();
            capturegivenauth2.Amount = 106;
            capturegivenauth2.OrderId = "12344";
            AuthInformation authInfo2 = new AuthInformation();
            authDate = new DateTime(2003, 10, 9);
            authInfo2.AuthDate = authDate;
            authInfo2.AuthCode = "543216";
            authInfo2.AuthAmount = 12345;
            capturegivenauth2.AuthInformation = authInfo;
            capturegivenauth2.OrderSource = OrderSourceType.Ecommerce;
            capturegivenauth2.Card = card2;

            litleBatchRequest.AddCaptureGivenAuth(capturegivenauth2);

            Credit creditObj = new Credit();
            creditObj.Amount = 106;
            creditObj.OrderId = "2111";
            creditObj.OrderSource = OrderSourceType.Ecommerce;
            creditObj.Card = card;

            litleBatchRequest.AddCredit(creditObj);

            Credit creditObj2 = new Credit();
            creditObj2.Amount = 106;
            creditObj2.OrderId = "2111";
            creditObj2.OrderSource = OrderSourceType.Ecommerce;
            creditObj2.Card = card2;

            litleBatchRequest.AddCredit(creditObj2);

            EcheckCredit echeckcredit = new EcheckCredit();
            echeckcredit.Amount = 12L;
            echeckcredit.OrderId = "12345";
            echeckcredit.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck = new EcheckType();
            echeck.AccType = echeckAccountTypeEnum.Checking;
            echeck.AccNum = "1099999903";
            echeck.RoutingNum = "011201995";
            echeck.CheckNum = "123455";
            echeckcredit.Echeck = echeck;
            Contact billToAddress = new Contact();
            billToAddress.Name = "Bob";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";
            echeckcredit.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckCredit(echeckcredit);

            EcheckCredit echeckcredit2 = new EcheckCredit();
            echeckcredit2.Amount = 12L;
            echeckcredit2.OrderId = "12346";
            echeckcredit2.OrderSource = OrderSourceType.Ecommerce;
            EcheckType echeck2 = new EcheckType();
            echeck2.AccType = echeckAccountTypeEnum.Checking;
            echeck2.AccNum = "1099999903";
            echeck2.RoutingNum = "011201995";
            echeck2.CheckNum = "123456";
            echeckcredit2.Echeck = echeck2;
            Contact billToAddress2 = new Contact();
            billToAddress2.Name = "Mike";
            billToAddress2.City = "Lowell";
            billToAddress2.State = "MA";
            billToAddress2.Email = "litle.com";
            echeckcredit2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckCredit(echeckcredit2);

            EcheckRedeposit echeckredeposit = new EcheckRedeposit();
            echeckredeposit.litleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            EcheckRedeposit echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.litleTxnId = 123457;
            echeckredeposit2.Echeck = echeck2;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit2);

            EcheckSale echeckSaleObj = new EcheckSale();
            echeckSaleObj.Amount = 123456;
            echeckSaleObj.OrderId = "12345";
            echeckSaleObj.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj.Echeck = echeck;
            echeckSaleObj.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckSale(echeckSaleObj);

            EcheckSale echeckSaleObj2 = new EcheckSale();
            echeckSaleObj2.Amount = 123456;
            echeckSaleObj2.OrderId = "12346";
            echeckSaleObj2.OrderSource = OrderSourceType.Ecommerce;
            echeckSaleObj2.Echeck = echeck2;
            echeckSaleObj2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckSale(echeckSaleObj2);

            EcheckVerification echeckVerificationObject = new EcheckVerification();
            echeckVerificationObject.Amount = 123456;
            echeckVerificationObject.OrderId = "12345";
            echeckVerificationObject.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject.Echeck = echeck;
            echeckVerificationObject.BillToAddress = billToAddress;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject);

            EcheckVerification echeckVerificationObject2 = new EcheckVerification();
            echeckVerificationObject2.Amount = 123456;
            echeckVerificationObject2.OrderId = "12346";
            echeckVerificationObject2.OrderSource = OrderSourceType.Ecommerce;
            echeckVerificationObject2.Echeck = echeck2;
            echeckVerificationObject2.BillToAddress = billToAddress2;

            litleBatchRequest.AddEcheckVerification(echeckVerificationObject2);

            ForceCapture forcecapture = new ForceCapture();
            forcecapture.Amount = 106;
            forcecapture.OrderId = "12344";
            forcecapture.OrderSource = OrderSourceType.Ecommerce;
            forcecapture.Card = card;

            litleBatchRequest.AddForceCapture(forcecapture);

            ForceCapture forcecapture2 = new ForceCapture();
            forcecapture2.Amount = 106;
            forcecapture2.OrderId = "12345";
            forcecapture2.OrderSource = OrderSourceType.Ecommerce;
            forcecapture2.Card = card2;

            litleBatchRequest.AddForceCapture(forcecapture2);

            Sale saleObj = new Sale();
            saleObj.Amount = 106;
            saleObj.LitleTxnId = 123456;
            saleObj.OrderId = "12344";
            saleObj.OrderSource = OrderSourceType.Ecommerce;
            saleObj.Card = card;

            litleBatchRequest.AddSale(saleObj);

            Sale saleObj2 = new Sale();
            saleObj2.Amount = 106;
            saleObj2.LitleTxnId = 123456;
            saleObj2.OrderId = "12345";
            saleObj2.OrderSource = OrderSourceType.Ecommerce;
            saleObj2.Card = card2;

            litleBatchRequest.AddSale(saleObj2);

            RegisterTokenRequestType registerTokenRequest = new RegisterTokenRequestType();
            registerTokenRequest.OrderId = "12344";
            registerTokenRequest.AccountNumber = "1233456789103801";
            registerTokenRequest.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            RegisterTokenRequestType registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.reportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            litleISC.AddBatch(litleBatchRequest);

            try
            {
                string batchName = litleISC.SendToLitle();
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
            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.reportGroup = "<ReportGroup>";
            authorization.OrderId = "12344&'\"";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "4100000000000001";
            card.ExpDate = "1210";
            authorization.Card = card;

            litleBatchRequest.AddAuthorization(authorization);

            litle.AddBatch(litleBatchRequest);

            string batchName = litle.SendToLitle();

            litle.BlockAndWaitForResponse(batchName, estimatedResponseTime(2 * 2, 10 * 2));

            litleResponse litleResponse = litle.ReceiveFromLitle(batchName);

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.response);
            Assert.AreEqual("Valid Format", litleResponse.message);

            batchResponse litleBatchResponse = litleResponse.nextBatchResponse();
            while (litleBatchResponse != null)
            {
                authorizationResponse authorizationResponse = litleBatchResponse.nextAuthorizationResponse();
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
            return (int)(5 * 60 * 1000 + 2.5 * 1000 + numAuthsAndSales * (1 / 5) * 1000 + numRest * (1 / 50) * 1000) * 5;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;
using NUnit.Framework;
using Litle.Sdk;
using System.IO;

namespace Litle.Sdk.Test.Functional
{
    [TestFixture]
    class TestBatchStream
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
            invalidConfig["sftpUsername"] = Properties.Settings.Default.sftpUrl;
            invalidConfig["sftpPassword"] = Properties.Settings.Default.sftpPassword;
            invalidConfig["knownHostsFile"] = Properties.Settings.Default.knownHostsFile;
            

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
            authorization.ReportGroup = "Planets";
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
            authorization2.ReportGroup = "Planets";
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
            echeck.AccType = EcheckAccountTypeEnum.Checking;
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
            echeck2.AccType = EcheckAccountTypeEnum.Checking;
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
            echeckredeposit.LitleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            EcheckRedeposit echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.LitleTxnId = 123457;
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

            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditObj2);

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
            registerTokenRequest.ReportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            RegisterTokenRequestType registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.ReportGroup = "Planets";

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

            LitleResponse litleResponse = litle.SendToLitleWithStream();

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.Response);
            Assert.AreEqual("Valid Format", litleResponse.Message);

            BatchResponse litleBatchResponse = litleResponse.NextBatchResponse();
            while (litleBatchResponse != null)
            {
                AuthorizationResponse authorizationResponse = litleBatchResponse.NextAuthorizationResponse();
                while (authorizationResponse != null)
                {
                    Assert.AreEqual("000", authorizationResponse.Response);

                    authorizationResponse = litleBatchResponse.NextAuthorizationResponse();
                }

                AuthReversalResponse authReversalResponse = litleBatchResponse.NextAuthReversalResponse();
                while (authReversalResponse != null)
                {
                    Assert.AreEqual("360", authReversalResponse.Response);

                    authReversalResponse = litleBatchResponse.NextAuthReversalResponse();
                }

                CaptureResponse captureResponse = litleBatchResponse.NextCaptureResponse();
                while (captureResponse != null)
                {
                    Assert.AreEqual("360", captureResponse.Response);

                    captureResponse = litleBatchResponse.NextCaptureResponse();
                }

                CaptureGivenAuthResponse captureGivenAuthResponse = litleBatchResponse.NextCaptureGivenAuthResponse();
                while (captureGivenAuthResponse != null)
                {
                    Assert.AreEqual("000", captureGivenAuthResponse.Response);

                    captureGivenAuthResponse = litleBatchResponse.NextCaptureGivenAuthResponse();
                }

                CreditResponse creditResponse = litleBatchResponse.NextCreditResponse();
                while (creditResponse != null)
                {
                    Assert.AreEqual("000", creditResponse.Response);

                    creditResponse = litleBatchResponse.NextCreditResponse();
                }

                EcheckCreditResponse echeckCreditResponse = litleBatchResponse.NextEcheckCreditResponse();
                while (echeckCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckCreditResponse.Response);

                    echeckCreditResponse = litleBatchResponse.NextEcheckCreditResponse();
                }

                EcheckRedepositResponse echeckRedepositResponse = litleBatchResponse.NextEcheckRedepositResponse();
                while (echeckRedepositResponse != null)
                {
                    Assert.AreEqual("360", echeckRedepositResponse.Response);

                    echeckRedepositResponse = litleBatchResponse.NextEcheckRedepositResponse();
                }

                EcheckSalesResponse echeckSalesResponse = litleBatchResponse.NextEcheckSalesResponse();
                while (echeckSalesResponse != null)
                {
                    Assert.AreEqual("000", echeckSalesResponse.Response);

                    echeckSalesResponse = litleBatchResponse.NextEcheckSalesResponse();
                }

                EcheckPreNoteSaleResponse echeckPreNoteSaleResponse = litleBatchResponse.NextEcheckPreNoteSaleResponse();
                while (echeckPreNoteSaleResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteSaleResponse.Response);

                    echeckPreNoteSaleResponse = litleBatchResponse.NextEcheckPreNoteSaleResponse();
                }

                EcheckPreNoteCreditResponse echeckPreNoteCreditResponse = litleBatchResponse.NextEcheckPreNoteCreditResponse();
                while (echeckPreNoteCreditResponse != null)
                {
                    Assert.AreEqual("000", echeckPreNoteCreditResponse.Response);

                    echeckPreNoteCreditResponse = litleBatchResponse.NextEcheckPreNoteCreditResponse();
                }

                EcheckVerificationResponse echeckVerificationResponse = litleBatchResponse.NextEcheckVerificationResponse();
                while (echeckVerificationResponse != null)
                {
                    Assert.AreEqual("957", echeckVerificationResponse.Response);

                    echeckVerificationResponse = litleBatchResponse.NextEcheckVerificationResponse();
                }

                ForceCaptureResponse forceCaptureResponse = litleBatchResponse.NextForceCaptureResponse();
                while (forceCaptureResponse != null)
                {
                    Assert.AreEqual("000", forceCaptureResponse.Response);

                    forceCaptureResponse = litleBatchResponse.NextForceCaptureResponse();
                }

                RegisterTokenResponse registerTokenResponse = litleBatchResponse.NextRegisterTokenResponse();
                while (registerTokenResponse != null)
                {
                    Assert.AreEqual("820", registerTokenResponse.Response);

                    registerTokenResponse = litleBatchResponse.NextRegisterTokenResponse();
                }

                SaleResponse saleResponse = litleBatchResponse.NextSaleResponse();
                while (saleResponse != null)
                {
                    Assert.AreEqual("000", saleResponse.Response);

                    saleResponse = litleBatchResponse.NextSaleResponse();
                }

                UpdateCardValidationNumOnTokenResponse updateCardValidationNumOnTokenResponse = litleBatchResponse.NextUpdateCardValidationNumOnTokenResponse();
                while (updateCardValidationNumOnTokenResponse != null)
                {
                    Assert.AreEqual("823", updateCardValidationNumOnTokenResponse.Response);

                    updateCardValidationNumOnTokenResponse = litleBatchResponse.NextUpdateCardValidationNumOnTokenResponse();
                }

                litleBatchResponse = litleResponse.NextBatchResponse();
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
            LitleResponse litleResponse = litle.SendToLitleWithStream();

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.Response);
            Assert.AreEqual("Valid Format", litleResponse.Message);

            BatchResponse litleBatchResponse = litleResponse.NextBatchResponse();
            while (litleBatchResponse != null)
            {
                AccountUpdateResponse accountUpdateResponse = litleBatchResponse.NextAccountUpdateResponse();
                Assert.NotNull(accountUpdateResponse);
                while (accountUpdateResponse != null)
                {
                    Assert.AreEqual("301", accountUpdateResponse.Response);

                    accountUpdateResponse = litleBatchResponse.NextAccountUpdateResponse();
                }
                litleBatchResponse = litleResponse.NextBatchResponse();
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
            LitleResponse litleResponse = litle.SendToLitleWithStream();

            Assert.NotNull(litleResponse);

            BatchResponse litleBatchResponse = litleResponse.NextBatchResponse();
            Assert.NotNull(litleBatchResponse);
            while (litleBatchResponse != null)
            {
                AccountUpdateResponse accountUpdateResponse = litleBatchResponse.NextAccountUpdateResponse();
                Assert.NotNull(accountUpdateResponse);
                while (accountUpdateResponse != null)
                {
                    Assert.AreEqual("000", accountUpdateResponse.Response);

                    accountUpdateResponse = litleBatchResponse.NextAccountUpdateResponse();
                }
                litleBatchResponse = litleResponse.NextBatchResponse();
            }

            LitleRequest litleRfr = new LitleRequest();
            RfrRequest rfrRequest = new RfrRequest();
            AccountUpdateFileRequestData accountUpdateFileRequestData = new AccountUpdateFileRequestData();
            accountUpdateFileRequestData.MerchantId = Properties.Settings.Default.merchantId;
            accountUpdateFileRequestData.PostDay = DateTime.Now;
            rfrRequest.AccountUpdateFileRequestData = accountUpdateFileRequestData;

            litleRfr.AddRfrRequest(rfrRequest);            

            try
            {
                LitleResponse litleRfrResponse = litleRfr.SendToLitleWithStream();
                Assert.NotNull(litleRfrResponse);

                RFRResponse rfrResponse = litleRfrResponse.NextRFRResponse();
                Assert.NotNull(rfrResponse);
                while (rfrResponse != null)
                {
                    Assert.AreEqual("1", rfrResponse.Response);
                    Assert.AreEqual("The account update file is not ready yet.  Please try again later.", rfrResponse.Message);
                    rfrResponse = litleResponse.NextRFRResponse();
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
            authorization.ReportGroup = "Planets";
            authorization.OrderId = "12344";
            authorization.Amount = 106;
            authorization.OrderSource = OrderSourceType.Ecommerce;
            CardType card = new CardType();
            card.Type = MethodOfPaymentTypeEnum.VI;
            card.Number = "414100000000000000";
            card.ExpDate = "1210";
            authorization.Card = card; //This needs to compile      

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
            echeck.AccType = EcheckAccountTypeEnum.Checking;
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
            echeckredeposit.LitleTxnId = 123456;
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
            registerTokenRequest.ReportGroup = "Planets";

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
            BatchRequest litleBatchRequest = new BatchRequest();

            Authorization authorization = new Authorization();
            authorization.ReportGroup = "Planets";
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
            authorization2.ReportGroup = "Planets";
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
            echeck.AccType = EcheckAccountTypeEnum.Checking;
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
            echeck2.AccType = EcheckAccountTypeEnum.Checking;
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
            echeckredeposit.LitleTxnId = 123456;
            echeckredeposit.Echeck = echeck;

            litleBatchRequest.AddEcheckRedeposit(echeckredeposit);

            EcheckRedeposit echeckredeposit2 = new EcheckRedeposit();
            echeckredeposit2.LitleTxnId = 123457;
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
            registerTokenRequest.ReportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest);

            RegisterTokenRequestType registerTokenRequest2 = new RegisterTokenRequestType();
            registerTokenRequest2.OrderId = "12345";
            registerTokenRequest2.AccountNumber = "1233456789103801";
            registerTokenRequest2.ReportGroup = "Planets";

            litleBatchRequest.AddRegisterTokenRequest(registerTokenRequest2);

            litle.AddBatch(litleBatchRequest);

            try
            {
                LitleResponse litleResponse = litle.SendToLitleWithStream();
            }
            catch (LitleOnlineException e)
            {
                Assert.AreEqual("Error establishing a network connection", e.Message);
            }
        }

        [Test]
        public void EcheckPreNoteTestAll()
        {
            BatchRequest litleBatchRequest = new BatchRequest();

            Contact billToAddress = new Contact();
            billToAddress.Name = "Mike";
            billToAddress.City = "Lowell";
            billToAddress.State = "MA";
            billToAddress.Email = "litle.com";

            EcheckType echeckSuccess = new EcheckType();
            echeckSuccess.AccType = EcheckAccountTypeEnum.Corporate;
            echeckSuccess.AccNum = "1092969901";
            echeckSuccess.RoutingNum = "011075150";
            echeckSuccess.CheckNum = "123456";

            EcheckType echeckRoutErr = new EcheckType();
            echeckRoutErr.AccType = EcheckAccountTypeEnum.Checking;
            echeckRoutErr.AccNum = "6099999992";
            echeckRoutErr.RoutingNum = "053133052";
            echeckRoutErr.CheckNum = "123457";

            EcheckType echeckAccErr = new EcheckType();
            echeckAccErr.AccType = EcheckAccountTypeEnum.Corporate;
            echeckAccErr.AccNum = "10@2969901";
            echeckAccErr.RoutingNum = "011100012";
            echeckAccErr.CheckNum = "123458";

            EcheckPreNoteSale echeckPreNoteSaleSuccess = new EcheckPreNoteSale();
            echeckPreNoteSaleSuccess.OrderId = "000";
            echeckPreNoteSaleSuccess.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleSuccess.Echeck = echeckSuccess;
            echeckPreNoteSaleSuccess.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleSuccess);

            EcheckPreNoteSale echeckPreNoteSaleRoutErr = new EcheckPreNoteSale();
            echeckPreNoteSaleRoutErr.OrderId = "900";
            echeckPreNoteSaleRoutErr.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleRoutErr.Echeck = echeckRoutErr;
            echeckPreNoteSaleRoutErr.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleRoutErr);

            EcheckPreNoteSale echeckPreNoteSaleAccErr = new EcheckPreNoteSale();
            echeckPreNoteSaleAccErr.OrderId = "301";
            echeckPreNoteSaleAccErr.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteSaleAccErr.Echeck = echeckAccErr;
            echeckPreNoteSaleAccErr.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteSale(echeckPreNoteSaleAccErr);

            EcheckPreNoteCredit echeckPreNoteCreditSuccess = new EcheckPreNoteCredit();
            echeckPreNoteCreditSuccess.OrderId = "000";
            echeckPreNoteCreditSuccess.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditSuccess.Echeck = echeckSuccess;
            echeckPreNoteCreditSuccess.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditSuccess);

            EcheckPreNoteCredit echeckPreNoteCreditRoutErr = new EcheckPreNoteCredit();
            echeckPreNoteCreditRoutErr.OrderId = "900";
            echeckPreNoteCreditRoutErr.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditRoutErr.Echeck = echeckRoutErr;
            echeckPreNoteCreditRoutErr.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditRoutErr);

            EcheckPreNoteCredit echeckPreNoteCreditAccErr = new EcheckPreNoteCredit();
            echeckPreNoteCreditAccErr.OrderId = "301";
            echeckPreNoteCreditAccErr.OrderSource = OrderSourceType.Ecommerce;
            echeckPreNoteCreditAccErr.Echeck = echeckAccErr;
            echeckPreNoteCreditAccErr.BillToAddress = billToAddress;
            litleBatchRequest.AddEcheckPreNoteCredit(echeckPreNoteCreditAccErr);

            litle.AddBatch(litleBatchRequest);

            LitleResponse litleResponse = litle.SendToLitleWithStream();

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.Response);
            Assert.AreEqual("Valid Format", litleResponse.Message);

            BatchResponse litleBatchResponse = litleResponse.NextBatchResponse();
            while (litleBatchResponse != null)
            {
                EcheckPreNoteSaleResponse echeckPreNoteSaleResponse = litleBatchResponse.NextEcheckPreNoteSaleResponse();
                while (echeckPreNoteSaleResponse != null)
                {
                    Assert.AreEqual(echeckPreNoteSaleResponse.OrderId, echeckPreNoteSaleResponse.Response);

                    echeckPreNoteSaleResponse = litleBatchResponse.NextEcheckPreNoteSaleResponse();
                }

                EcheckPreNoteCreditResponse echeckPreNoteCreditResponse = litleBatchResponse.NextEcheckPreNoteCreditResponse();
                while (echeckPreNoteCreditResponse != null)
                {
                    Assert.AreEqual(echeckPreNoteCreditResponse.OrderId, echeckPreNoteCreditResponse.Response);

                    echeckPreNoteCreditResponse = litleBatchResponse.NextEcheckPreNoteCreditResponse();
                }

                litleBatchResponse = litleResponse.NextBatchResponse();
            }
        }

        [Test]
        public void PFIFInstructionTxnTest()
        {
            
            Dictionary<string, string> configOverride = new Dictionary<string, string>();
            configOverride["url"] = Properties.Settings.Default.url;
            configOverride["reportGroup"] = Properties.Settings.Default.reportGroup;
            configOverride["username"] = "BATCHSDKA";
            configOverride["printxml"] = Properties.Settings.Default.printxml;
            configOverride["timeout"] = Properties.Settings.Default.timeout;
            configOverride["proxyHost"] = Properties.Settings.Default.proxyHost;
            configOverride["merchantId"] = "0180";
            configOverride["password"] = "certpass";
            configOverride["proxyPort"] = Properties.Settings.Default.proxyPort;
            configOverride["sftpUrl"] = Properties.Settings.Default.sftpUrl;
            configOverride["sftpUsername"] = Properties.Settings.Default.sftpUsername;
            configOverride["sftpPassword"] = Properties.Settings.Default.sftpPassword;
            configOverride["knownHostsFile"] = Properties.Settings.Default.knownHostsFile;
            configOverride["onlineBatchUrl"] = Properties.Settings.Default.onlineBatchUrl;
            configOverride["onlineBatchPort"] = Properties.Settings.Default.onlineBatchPort;
            configOverride["requestDirectory"] = Properties.Settings.Default.requestDirectory;
            configOverride["responseDirectory"] = Properties.Settings.Default.responseDirectory;

            LitleRequest litleOverride = new LitleRequest(configOverride);

            BatchRequest litleBatchRequest = new BatchRequest(configOverride);

            EcheckType echeck = new EcheckType();
            echeck.AccType = EcheckAccountTypeEnum.Corporate;
            echeck.AccNum = "1092969901";
            echeck.RoutingNum = "011075150";
            echeck.CheckNum = "123455";

            SubmerchantCredit submerchantCredit = new SubmerchantCredit();
            submerchantCredit.FundingSubmerchantId = "123456";
            submerchantCredit.SubmerchantName = "merchant";
            submerchantCredit.FundsTransferId = "123467";
            submerchantCredit.Amount = 106L;
            submerchantCredit.AccountInfo = echeck;
            litleBatchRequest.AddSubmerchantCredit(submerchantCredit);

            PayFacCredit payFacCredit = new PayFacCredit();
            payFacCredit.FundingSubmerchantId = "123456";
            payFacCredit.FundsTransferId = "123467";
            payFacCredit.Amount = 107L;
            litleBatchRequest.AddPayFacCredit(payFacCredit);

            ReserveCredit reserveCredit = new ReserveCredit();
            reserveCredit.FundingSubmerchantId = "123456";
            reserveCredit.FundsTransferId = "123467";
            reserveCredit.Amount = 107L;
            litleBatchRequest.AddReserveCredit(reserveCredit);

            VendorCredit vendorCredit = new VendorCredit();
            vendorCredit.FundingSubmerchantId = "123456";
            vendorCredit.VendorName = "merchant";
            vendorCredit.FundsTransferId = "123467";
            vendorCredit.Amount = 106L;
            vendorCredit.AccountInfo = echeck;
            litleBatchRequest.AddVendorCredit(vendorCredit);

            PhysicalCheckCredit physicalCheckCredit = new PhysicalCheckCredit();
            physicalCheckCredit.FundingSubmerchantId = "123456";
            physicalCheckCredit.FundsTransferId = "123467";
            physicalCheckCredit.Amount = 107L;
            litleBatchRequest.AddPhysicalCheckCredit(physicalCheckCredit);

            SubmerchantDebit submerchantDebit = new SubmerchantDebit();
            submerchantDebit.FundingSubmerchantId = "123456";
            submerchantDebit.SubmerchantName = "merchant";
            submerchantDebit.FundsTransferId = "123467";
            submerchantDebit.Amount = 106L;
            submerchantDebit.AccountInfo = echeck;
            litleBatchRequest.AddSubmerchantDebit(submerchantDebit);

            PayFacDebit payFacDebit = new PayFacDebit();
            payFacDebit.FundingSubmerchantId = "123456";
            payFacDebit.FundsTransferId = "123467";
            payFacDebit.Amount = 107L;
            litleBatchRequest.AddPayFacDebit(payFacDebit);

            ReserveDebit reserveDebit = new ReserveDebit();
            reserveDebit.FundingSubmerchantId = "123456";
            reserveDebit.FundsTransferId = "123467";
            reserveDebit.Amount = 107L;
            litleBatchRequest.AddReserveDebit(reserveDebit);

            VendorDebit vendorDebit = new VendorDebit();
            vendorDebit.FundingSubmerchantId = "123456";
            vendorDebit.VendorName = "merchant";
            vendorDebit.FundsTransferId = "123467";
            vendorDebit.Amount = 106L;
            vendorDebit.AccountInfo = echeck;
            litleBatchRequest.AddVendorDebit(vendorDebit);

            PhysicalCheckDebit physicalCheckDebit = new PhysicalCheckDebit();
            physicalCheckDebit.FundingSubmerchantId = "123456";
            physicalCheckDebit.FundsTransferId = "123467";
            physicalCheckDebit.Amount = 107L;
            litleBatchRequest.AddPhysicalCheckDebit(physicalCheckDebit);

            litleOverride.AddBatch(litleBatchRequest);

            LitleResponse litleResponse = litleOverride.SendToLitleWithStream();

            Assert.NotNull(litleResponse);
            Assert.AreEqual("0", litleResponse.Response);
            Assert.AreEqual("Valid Format", litleResponse.Message);

            BatchResponse litleBatchResponse = litleResponse.NextBatchResponse();
            while (litleBatchResponse != null)
            {
                SubmerchantCreditResponse submerchantCreditResponse = litleBatchResponse.NextSubmerchantCreditResponse();
                while (submerchantCreditResponse != null)
                {
                    Assert.AreEqual("000", submerchantCreditResponse.Response);
                    submerchantCreditResponse = litleBatchResponse.NextSubmerchantCreditResponse();
                }

                PayFacCreditResponse payFacCreditResponse = litleBatchResponse.NextPayFacCreditResponse();
                while (payFacCreditResponse != null)
                {
                    Assert.AreEqual("000", payFacCreditResponse.Response);
                    payFacCreditResponse = litleBatchResponse.NextPayFacCreditResponse();
                }

                VendorCreditResponse vendorCreditResponse = litleBatchResponse.NextVendorCreditResponse();
                while (vendorCreditResponse != null)
                {
                    Assert.AreEqual("000", vendorCreditResponse.Response);
                    vendorCreditResponse = litleBatchResponse.NextVendorCreditResponse();
                }

                ReserveCreditResponse reserveCreditResponse = litleBatchResponse.NextReserveCreditResponse();
                while (reserveCreditResponse != null)
                {
                    Assert.AreEqual("000", reserveCreditResponse.Response);
                    reserveCreditResponse = litleBatchResponse.NextReserveCreditResponse();
                }

                PhysicalCheckCreditResponse physicalCheckCreditResponse = litleBatchResponse.NextPhysicalCheckCreditResponse();
                while (physicalCheckCreditResponse != null)
                {
                    Assert.AreEqual("000", physicalCheckCreditResponse.Response);
                    physicalCheckCreditResponse = litleBatchResponse.NextPhysicalCheckCreditResponse();
                }

                SubmerchantDebitResponse submerchantDebitResponse = litleBatchResponse.NextSubmerchantDebitResponse();
                while (submerchantDebitResponse != null)
                {
                    Assert.AreEqual("000", submerchantDebitResponse.Response);
                    submerchantDebitResponse = litleBatchResponse.NextSubmerchantDebitResponse();
                }

                PayFacDebitResponse payFacDebitResponse = litleBatchResponse.NextPayFacDebitResponse();
                while (payFacDebitResponse != null)
                {
                    Assert.AreEqual("000", payFacDebitResponse.Response);
                    payFacDebitResponse = litleBatchResponse.NextPayFacDebitResponse();
                }

                VendorDebitResponse vendorDebitResponse = litleBatchResponse.NextVendorDebitResponse();
                while (vendorDebitResponse != null)
                {
                    Assert.AreEqual("000", vendorDebitResponse.Response);
                    vendorDebitResponse = litleBatchResponse.NextVendorDebitResponse();
                }

                ReserveDebitResponse reserveDebitResponse = litleBatchResponse.NextReserveDebitResponse();
                while (reserveDebitResponse != null)
                {
                    Assert.AreEqual("000", reserveDebitResponse.Response);
                    reserveDebitResponse = litleBatchResponse.NextReserveDebitResponse();
                }

                PhysicalCheckDebitResponse physicalCheckDebitResponse = litleBatchResponse.NextPhysicalCheckDebitResponse();
                while (physicalCheckDebitResponse != null)
                {
                    Assert.AreEqual("000", physicalCheckDebitResponse.Response);
                    physicalCheckDebitResponse = litleBatchResponse.NextPhysicalCheckDebitResponse();
                }

                litleBatchResponse = litleResponse.NextBatchResponse();
            }
        }
    }
}

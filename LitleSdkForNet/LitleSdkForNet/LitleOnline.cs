using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class LitleOnline : ILitleOnline
    {
        private readonly Dictionary<string, string> _config;
        private Communications _communication;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */

        public LitleOnline(IDictionary<string, StringBuilder> memoryStreams)
        {
            _config = new Dictionary<string, string>
            {
                ["url"] = Settings.Default.url,
                ["reportGroup"] = Settings.Default.reportGroup,
                ["username"] = Settings.Default.username,
                ["printxml"] = Settings.Default.printxml,
                ["timeout"] = Settings.Default.timeout,
                ["proxyHost"] = Settings.Default.proxyHost,
                ["merchantId"] = Settings.Default.merchantId,
                ["password"] = Settings.Default.password,
                ["proxyPort"] = Settings.Default.proxyPort,
                ["logFile"] = Settings.Default.logFile,
                ["neuterAccountNums"] = Settings.Default.neuterAccountNums
            };
            _communication = new Communications(memoryStreams);
        }

        /**
         * Construct a LitleOnline specifying the configuration in code.  This should be used by integration that have another way
         * to specify their configuration settings or where different configurations are needed for different instances of LitleOnline.
         * 
         * Properties that *must* be set are:
         * url (eg https://payments.litle.com/vap/communicator/online)
         * reportGroup (eg "Default Report Group")
         * username
         * merchantId
         * password
         * timeout (in seconds)
         * Optional properties are:
         * proxyHost
         * proxyPort
         * printxml (possible values "true" and "false" - defaults to false)
         */

        public LitleOnline(IDictionary<string, StringBuilder> memoryStreams, Dictionary<string, string> config)
        {
            _config = config;
            _communication = new Communications(memoryStreams);
        }

        public void setCommunication(Communications communication)
        {
            _communication = communication;
        }

        public authorizationResponse Authorize(Authorization auth)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(auth);
            request.Authorization = auth;

            var response = SendToLitle(request);
            var authResponse = response.authorizationResponse;
            return authResponse;
        }

        public authReversalResponse AuthReversal(AuthReversal reversal)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(reversal);
            request.AuthReversal = reversal;

            var response = SendToLitle(request);
            var reversalResponse = response.authReversalResponse;
            return reversalResponse;
        }

        public captureResponse Capture(Capture capture)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(capture);
            request.Capture = capture;

            var response = SendToLitle(request);
            var captureResponse = response.captureResponse;
            return captureResponse;
        }

        public captureGivenAuthResponse CaptureGivenAuth(CaptureGivenAuth captureGivenAuth)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(captureGivenAuth);
            request.CaptureGivenAuth = captureGivenAuth;

            var response = SendToLitle(request);
            var captureGivenAuthResponse = response.captureGivenAuthResponse;
            return captureGivenAuthResponse;
        }

        public creditResponse Credit(Credit credit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(credit);
            request.Credit = credit;

            var response = SendToLitle(request);
            var creditResponse = response.creditResponse;
            return creditResponse;
        }

        public echeckCreditResponse EcheckCredit(EcheckCredit echeckCredit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckCredit);
            request.EcheckCredit = echeckCredit;

            var response = SendToLitle(request);
            var echeckCreditResponse = response.echeckCreditResponse;
            return echeckCreditResponse;
        }

        public echeckRedepositResponse EcheckRedeposit(EcheckRedeposit echeckRedeposit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckRedeposit);
            request.EcheckRedeposit = echeckRedeposit;

            var response = SendToLitle(request);
            var echeckRedepositResponse = response.echeckRedepositResponse;
            return echeckRedepositResponse;
        }

        public echeckSalesResponse EcheckSale(EcheckSale echeckSale)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckSale);
            request.EcheckSale = echeckSale;

            var response = SendToLitle(request);
            var echeckSalesResponse = response.echeckSalesResponse;
            return echeckSalesResponse;
        }

        public echeckVerificationResponse EcheckVerification(EcheckVerification echeckVerification)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckVerification);
            request.EcheckVerification = echeckVerification;

            var response = SendToLitle(request);
            var echeckVerificationResponse = response.echeckVerificationResponse;
            return echeckVerificationResponse;
        }

        public forceCaptureResponse ForceCapture(ForceCapture forceCapture)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(forceCapture);
            request.ForceCapture = forceCapture;

            var response = SendToLitle(request);
            var forceCaptureResponse = response.forceCaptureResponse;
            return forceCaptureResponse;
        }

        public saleResponse Sale(Sale sale)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(sale);
            request.Sale = sale;

            var response = SendToLitle(request);
            var saleResponse = response.saleResponse;
            return saleResponse;
        }

        public registerTokenResponse RegisterToken(RegisterTokenRequestType tokenRequest)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(tokenRequest);
            request.RegisterTokenRequest = tokenRequest;

            var response = SendToLitle(request);
            var registerTokenResponse = response.registerTokenResponse;
            return registerTokenResponse;
        }

        public litleOnlineResponseTransactionResponseVoidResponse DoVoid(VoidTxn v)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.VoidTxn = v;

            var response = SendToLitle(request);
            var voidResponse = response.voidResponse;
            return voidResponse;
        }

        public litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(EcheckVoid v)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.EcheckVoid = v;

            var response = SendToLitle(request);
            var voidResponse = response.echeckVoidResponse;
            return voidResponse;
        }

        public updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(
            UpdateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(updateCardValidationNumOnToken);
            request.UpdateCardValidationNumOnToken = updateCardValidationNumOnToken;

            var response = SendToLitle(request);
            var updateResponse = response.updateCardValidationNumOnTokenResponse;
            return updateResponse;
        }

        public cancelSubscriptionResponse CancelSubscription(CancelSubscription cancelSubscription)
        {
            var request = CreateLitleOnlineRequest();
            request.CancelSubscription = cancelSubscription;

            var response = SendToLitle(request);
            var cancelResponse = response.cancelSubscriptionResponse;
            return cancelResponse;
        }

        public updateSubscriptionResponse UpdateSubscription(UpdateSubscription updateSubscription)
        {
            var request = CreateLitleOnlineRequest();
            request.UpdateSubscription = updateSubscription;

            var response = SendToLitle(request);
            var updateResponse = response.updateSubscriptionResponse;
            return updateResponse;
        }

        public activateResponse Activate(Activate activate)
        {
            var request = CreateLitleOnlineRequest();
            request.Activate = activate;

            var response = SendToLitle(request);
            var activateResponse = response.activateResponse;
            return activateResponse;
        }

        public deactivateResponse Deactivate(Deactivate deactivate)
        {
            var request = CreateLitleOnlineRequest();
            request.Deactivate = deactivate;

            var response = SendToLitle(request);
            var deactivateResponse = response.deactivateResponse;
            return deactivateResponse;
        }

        public loadResponse Load(Load load)
        {
            var request = CreateLitleOnlineRequest();
            request.Load = load;

            var response = SendToLitle(request);
            var loadResponse = response.loadResponse;
            return loadResponse;
        }

        public unloadResponse Unload(Unload unload)
        {
            var request = CreateLitleOnlineRequest();
            request.Unload = unload;

            var response = SendToLitle(request);
            var unloadResponse = response.unloadResponse;
            return unloadResponse;
        }

        public balanceInquiryResponse BalanceInquiry(BalanceInquiry balanceInquiry)
        {
            var request = CreateLitleOnlineRequest();
            request.BalanceInquiry = balanceInquiry;

            var response = SendToLitle(request);
            var balanceInquiryResponse = response.balanceInquiryResponse;
            return balanceInquiryResponse;
        }

        public createPlanResponse CreatePlan(CreatePlan createPlan)
        {
            var request = CreateLitleOnlineRequest();
            request.CreatePlan = createPlan;

            var response = SendToLitle(request);
            var createPlanResponse = response.createPlanResponse;
            return createPlanResponse;
        }

        public updatePlanResponse UpdatePlan(UpdatePlan updatePlan)
        {
            var request = CreateLitleOnlineRequest();
            request.UpdatePlan = updatePlan;

            var response = SendToLitle(request);
            var updatePlanResponse = response.updatePlanResponse;
            return updatePlanResponse;
        }

        public refundReversalResponse RefundReversal(RefundReversal refundReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.RefundReversal = refundReversal;

            var response = SendToLitle(request);
            var refundReversalResponse = response.refundReversalResponse;
            return refundReversalResponse;
        }

        public depositReversalResponse DepositReversal(DepositReversal depositReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.DepositReversal = depositReversal;

            var response = SendToLitle(request);
            var depositReversalResponse = response.depositReversalResponse;
            return depositReversalResponse;
        }

        public activateReversalResponse ActivateReversal(ActivateReversal activateReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.ActivateReversal = activateReversal;

            var response = SendToLitle(request);
            var activateReversalResponse = response.activateReversalResponse;
            return activateReversalResponse;
        }

        public deactivateReversalResponse DeactivateReversal(DeactivateReversal deactivateReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.DeactivateReversal = deactivateReversal;

            var response = SendToLitle(request);
            var deactivateReversalResponse = response.deactivateReversalResponse;
            return deactivateReversalResponse;
        }

        public loadReversalResponse LoadReversal(LoadReversal loadReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.LoadReversal = loadReversal;

            var response = SendToLitle(request);
            var loadReversalResponse = response.loadReversalResponse;
            return loadReversalResponse;
        }

        public unloadReversalResponse UnloadReversal(UnloadReversal unloadReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.UnloadReversal = unloadReversal;

            var response = SendToLitle(request);
            var unloadReversalResponse = response.unloadReversalResponse;
            return unloadReversalResponse;
        }

        private LitleOnlineRequest CreateLitleOnlineRequest()
        {
            var request = new LitleOnlineRequest
            {
                MerchantId = _config["merchantId"],
                MerchantSdk = "DotNet;9.3.2"
            };
            var authentication = new Authentication
            {
                Password = _config["password"],
                User = _config["username"]
            };
            request.Authentication = authentication;
            return request;
        }

        private litleOnlineResponse SendToLitle(LitleOnlineRequest request)
        {
            var xmlRequest = request.Serialize();
            var xmlResponse = _communication.HttpPost(xmlRequest, _config);
            try
            {
                var litleOnlineResponse = DeserializeObject(xmlResponse);
                if ("1".Equals(litleOnlineResponse.response))
                {
                    throw new LitleOnlineException(litleOnlineResponse.message);
                }
                return litleOnlineResponse;
            }
            catch (InvalidOperationException ioe)
            {
                throw new LitleOnlineException("Error validating xml data against the schema", ioe);
            }
        }

        public static string SerializeObject(LitleOnlineRequest req)
        {
            var serializer = new XmlSerializer(typeof (LitleOnlineRequest));
            var ms = new MemoryStream();
            serializer.Serialize(ms, req);
            return Encoding.UTF8.GetString(ms.GetBuffer()); //return string is UTF8 encoded.
        } // serialize the xml

        public static litleOnlineResponse DeserializeObject(string response)
        {
            var serializer = new XmlSerializer(typeof (litleOnlineResponse));
            var reader = new StringReader(response);
            var i = (litleOnlineResponse) serializer.Deserialize(reader);
            return i;
        } // deserialize the object

        private void FillInReportGroup(transactionTypeWithReportGroup txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = _config["reportGroup"];
            }
        }

        private void FillInReportGroup(TransactionTypeWithReportGroupAndPartial txn)
        {
            if (txn.ReportGroup == null)
            {
                txn.ReportGroup = _config["reportGroup"];
            }
        }
    }

    public interface ILitleOnline
    {
        authorizationResponse Authorize(Authorization auth);
        authReversalResponse AuthReversal(AuthReversal reversal);
        captureResponse Capture(Capture capture);
        captureGivenAuthResponse CaptureGivenAuth(CaptureGivenAuth captureGivenAuth);
        creditResponse Credit(Credit credit);
        echeckCreditResponse EcheckCredit(EcheckCredit echeckCredit);
        echeckRedepositResponse EcheckRedeposit(EcheckRedeposit echeckRedeposit);
        echeckSalesResponse EcheckSale(EcheckSale echeckSale);
        echeckVerificationResponse EcheckVerification(EcheckVerification echeckVerification);
        forceCaptureResponse ForceCapture(ForceCapture forceCapture);
        saleResponse Sale(Sale sale);
        registerTokenResponse RegisterToken(RegisterTokenRequestType tokenRequest);
        litleOnlineResponseTransactionResponseVoidResponse DoVoid(VoidTxn v);
        litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(EcheckVoid v);
        updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(UpdateCardValidationNumOnToken update);
    }
}

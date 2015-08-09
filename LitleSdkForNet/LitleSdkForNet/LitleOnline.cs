using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Litle.Sdk.Properties;
using Litle.Sdk.Requests;

namespace Litle.Sdk
{
    public class LitleOnline : ILitleOnline
    {
        private readonly Dictionary<String, String> _config;
        private Communications _communication;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */
        public LitleOnline()
        {
            _config = new Dictionary<String, String>();
            _config["url"] = Settings.Default.url;
            _config["reportGroup"] = Settings.Default.reportGroup;
            _config["username"] = Settings.Default.username;
            _config["printxml"] = Settings.Default.printxml;
            _config["timeout"] = Settings.Default.timeout;
            _config["proxyHost"] = Settings.Default.proxyHost;
            _config["merchantId"] = Settings.Default.merchantId;
            _config["password"] = Settings.Default.password;
            _config["proxyPort"] = Settings.Default.proxyPort;
            _config["logFile"] = Settings.Default.logFile;
            _config["neuterAccountNums"] = Settings.Default.neuterAccountNums;
            _communication = new Communications();
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

        public LitleOnline(Dictionary<String, String> config)
        {
            _config = config;
            _communication = new Communications();
        }

        public void SetCommunication(Communications communication)
        {
            _communication = communication;
        }

        public authorizationResponse Authorize(Authorization auth)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(auth);
            request.Authorization = auth;

            litleOnlineResponse response = SendToLitle(request);
            return response.authorizationResponse;
        }

        public authReversalResponse AuthReversal(AuthReversal reversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(reversal);
            request.AuthReversal = reversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.authReversalResponse;
        }

        public captureResponse Capture(Capture capture)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(capture);
            request.Capture = capture;

            litleOnlineResponse response = SendToLitle(request);
            return response.captureResponse;
        }

        public captureGivenAuthResponse CaptureGivenAuth(CaptureGivenAuth captureGivenAuth)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(captureGivenAuth);
            request.CaptureGivenAuth = captureGivenAuth;

            litleOnlineResponse response = SendToLitle(request);
            return response.captureGivenAuthResponse;
        }

        public creditResponse Credit(Credit credit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(credit);
            request.Credit = credit;

            litleOnlineResponse response = SendToLitle(request);
            return response.creditResponse;
        }

        public echeckCreditResponse EcheckCredit(EcheckCredit echeckCredit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckCredit);
            request.EcheckCredit = echeckCredit;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckCreditResponse;
        }

        public echeckRedepositResponse EcheckRedeposit(EcheckRedeposit echeckRedeposit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckRedeposit);
            request.EcheckRedeposit = echeckRedeposit;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckRedepositResponse;
        }

        public echeckSalesResponse EcheckSale(EcheckSale echeckSale)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckSale);
            request.EcheckSale = echeckSale;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckSalesResponse;
        }

        public echeckVerificationResponse EcheckVerification(EcheckVerification echeckVerification)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckVerification);
            request.EcheckVerification = echeckVerification;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckVerificationResponse;
        }

        public forceCaptureResponse ForceCapture(ForceCapture forceCapture)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(forceCapture);
            request.ForceCapture = forceCapture;

            litleOnlineResponse response = SendToLitle(request);
            return response.forceCaptureResponse;
        }

        public saleResponse Sale(Sale sale)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(sale);
            request.Sale = sale;

            litleOnlineResponse response = SendToLitle(request);
            return response.saleResponse;
        }

        public registerTokenResponse RegisterToken(RegisterTokenRequestType tokenRequest)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(tokenRequest);
            request.RegisterTokenRequest = tokenRequest;

            litleOnlineResponse response = SendToLitle(request);
            return response.registerTokenResponse;
        }

        public litleOnlineResponseTransactionResponseVoidResponse DoVoid(VoidTxn v)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.VoidTxn = v;

            litleOnlineResponse response = SendToLitle(request);
            return response.voidResponse;
        }

        public litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(EcheckVoid v)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.EcheckVoid = v;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckVoidResponse;
        }

        public updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(
            UpdateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(updateCardValidationNumOnToken);
            request.UpdateCardValidationNumOnToken = updateCardValidationNumOnToken;

            litleOnlineResponse response = SendToLitle(request);
            return response.updateCardValidationNumOnTokenResponse;
        }

        public cancelSubscriptionResponse CancelSubscription(CancelSubscription cancelSubscription)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.CancelSubscription = cancelSubscription;

            litleOnlineResponse response = SendToLitle(request);
            return response.cancelSubscriptionResponse;
        }

        public updateSubscriptionResponse UpdateSubscription(UpdateSubscription updateSubscription)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UpdateSubscription = updateSubscription;

            litleOnlineResponse response = SendToLitle(request);
            return response.updateSubscriptionResponse;
        }

        public activateResponse Activate(Activate activate)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Activate = activate;

            litleOnlineResponse response = SendToLitle(request);
            return response.activateResponse;
        }

        public deactivateResponse Deactivate(Deactivate deactivate)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Deactivate = deactivate;

            litleOnlineResponse response = SendToLitle(request);
            return response.deactivateResponse;
        }

        public loadResponse Load(Load load)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Load = load;

            litleOnlineResponse response = SendToLitle(request);
            return response.loadResponse;
        }

        public unloadResponse Unload(Unload unload)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Unload = unload;

            litleOnlineResponse response = SendToLitle(request);
            return response.unloadResponse;
        }

        public balanceInquiryResponse BalanceInquiry(BalanceInquiry balanceInquiry)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.BalanceInquiry = balanceInquiry;

            litleOnlineResponse response = SendToLitle(request);
            return response.balanceInquiryResponse;
        }

        public createPlanResponse CreatePlan(CreatePlan createPlan)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.CreatePlan = createPlan;

            litleOnlineResponse response = SendToLitle(request);
            return response.createPlanResponse;
        }

        public updatePlanResponse UpdatePlan(UpdatePlan updatePlan)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UpdatePlan = updatePlan;

            litleOnlineResponse response = SendToLitle(request);
            return response.updatePlanResponse;
        }

        public refundReversalResponse RefundReversal(RefundReversal refundReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.RefundReversal = refundReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.refundReversalResponse;
        }

        public depositReversalResponse DepositReversal(DepositReversal depositReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.DepositReversal = depositReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.depositReversalResponse;
        }

        public activateReversalResponse ActivateReversal(ActivateReversal activateReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.ActivateReversal = activateReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.activateReversalResponse;
        }

        public deactivateReversalResponse DeactivateReversal(DeactivateReversal deactivateReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.DeactivateReversal = deactivateReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.deactivateReversalResponse;
        }

        public loadReversalResponse LoadReversal(LoadReversal loadReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.LoadReversal = loadReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.loadReversalResponse;
        }

        public unloadReversalResponse UnloadReversal(UnloadReversal unloadReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UnloadReversal = unloadReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.unloadReversalResponse;
        }

        private LitleOnlineRequest CreateLitleOnlineRequest()
        {
            return new LitleOnlineRequest
            {
                MerchantId = _config["merchantId"],
                MerchantSdk = "DotNet;9.3.2",
                Authentication = new Authentication {Password = _config["password"], User = _config["username"]}
            };
        }

        private litleOnlineResponse SendToLitle(LitleOnlineRequest request)
        {
            string xmlRequest = request.Serialize();
            string xmlResponse = _communication.HttpPost(xmlRequest, _config);
            try
            {
                litleOnlineResponse litleOnlineResponse = DeserializeObject(xmlResponse);
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

        public static String SerializeObject(LitleOnlineRequest req)
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
            return (litleOnlineResponse) serializer.Deserialize(reader);
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
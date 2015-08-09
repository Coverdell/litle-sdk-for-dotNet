using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Litle.Sdk.Properties;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;

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

        public AuthorizationResponse Authorize(Authorization auth)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(auth);
            request.Authorization = auth;

            LitleOnlineResponse response = SendToLitle(request);
            return response.AuthorizationResponse;
        }

        public AuthReversalResponse AuthReversal(AuthReversal reversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(reversal);
            request.AuthReversal = reversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.AuthReversalResponse;
        }

        public CaptureResponse Capture(Capture capture)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(capture);
            request.Capture = capture;

            LitleOnlineResponse response = SendToLitle(request);
            return response.CaptureResponse;
        }

        public CaptureGivenAuthResponse CaptureGivenAuth(CaptureGivenAuth captureGivenAuth)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(captureGivenAuth);
            request.CaptureGivenAuth = captureGivenAuth;

            LitleOnlineResponse response = SendToLitle(request);
            return response.CaptureGivenAuthResponse;
        }

        public CreditResponse Credit(Credit credit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(credit);
            request.Credit = credit;

            LitleOnlineResponse response = SendToLitle(request);
            return response.CreditResponse;
        }

        public EcheckCreditResponse EcheckCredit(EcheckCredit echeckCredit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckCredit);
            request.EcheckCredit = echeckCredit;

            LitleOnlineResponse response = SendToLitle(request);
            return response.EcheckCreditResponse;
        }

        public EcheckRedepositResponse EcheckRedeposit(EcheckRedeposit echeckRedeposit)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckRedeposit);
            request.EcheckRedeposit = echeckRedeposit;

            LitleOnlineResponse response = SendToLitle(request);
            return response.EcheckRedepositResponse;
        }

        public EcheckSalesResponse EcheckSale(EcheckSale echeckSale)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckSale);
            request.EcheckSale = echeckSale;

            LitleOnlineResponse response = SendToLitle(request);
            return response.EcheckSalesResponse;
        }

        public EcheckVerificationResponse EcheckVerification(EcheckVerification echeckVerification)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckVerification);
            request.EcheckVerification = echeckVerification;

            LitleOnlineResponse response = SendToLitle(request);
            return response.EcheckVerificationResponse;
        }

        public ForceCaptureResponse ForceCapture(ForceCapture forceCapture)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(forceCapture);
            request.ForceCapture = forceCapture;

            LitleOnlineResponse response = SendToLitle(request);
            return response.ForceCaptureResponse;
        }

        public SaleResponse Sale(Sale sale)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(sale);
            request.Sale = sale;

            LitleOnlineResponse response = SendToLitle(request);
            return response.SaleResponse;
        }

        public RegisterTokenResponse RegisterToken(RegisterTokenRequestType tokenRequest)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(tokenRequest);
            request.RegisterTokenRequest = tokenRequest;

            LitleOnlineResponse response = SendToLitle(request);
            return response.RegisterTokenResponse;
        }

        public LitleOnlineResponseTransactionResponseVoidResponse DoVoid(VoidTxn v)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.VoidTxn = v;

            LitleOnlineResponse response = SendToLitle(request);
            return response.VoidResponse;
        }

        public LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(EcheckVoid v)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.EcheckVoid = v;

            LitleOnlineResponse response = SendToLitle(request);
            return response.EcheckVoidResponse;
        }

        public UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(
            UpdateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(updateCardValidationNumOnToken);
            request.UpdateCardValidationNumOnToken = updateCardValidationNumOnToken;

            LitleOnlineResponse response = SendToLitle(request);
            return response.UpdateCardValidationNumOnTokenResponse;
        }

        public CancelSubscriptionResponse CancelSubscription(CancelSubscription cancelSubscription)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.CancelSubscription = cancelSubscription;

            LitleOnlineResponse response = SendToLitle(request);
            return response.CancelSubscriptionResponse;
        }

        public UpdateSubscriptionResponse UpdateSubscription(UpdateSubscription updateSubscription)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UpdateSubscription = updateSubscription;

            LitleOnlineResponse response = SendToLitle(request);
            return response.UpdateSubscriptionResponse;
        }

        public ActivateResponse Activate(Activate activate)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Activate = activate;

            LitleOnlineResponse response = SendToLitle(request);
            return response.ActivateResponse;
        }

        public DeactivateResponse Deactivate(Deactivate deactivate)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Deactivate = deactivate;

            LitleOnlineResponse response = SendToLitle(request);
            return response.DeactivateResponse;
        }

        public LoadResponse Load(Load load)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Load = load;

            LitleOnlineResponse response = SendToLitle(request);
            return response.LoadResponse;
        }

        public UnloadResponse Unload(Unload unload)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.Unload = unload;

            LitleOnlineResponse response = SendToLitle(request);
            return response.UnloadResponse;
        }

        public BalanceInquiryResponse BalanceInquiry(BalanceInquiry balanceInquiry)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.BalanceInquiry = balanceInquiry;

            LitleOnlineResponse response = SendToLitle(request);
            return response.BalanceInquiryResponse;
        }

        public CreatePlanResponse CreatePlan(CreatePlan createPlan)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.CreatePlan = createPlan;

            LitleOnlineResponse response = SendToLitle(request);
            return response.CreatePlanResponse;
        }

        public UpdatePlanResponse UpdatePlan(UpdatePlan updatePlan)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UpdatePlan = updatePlan;

            LitleOnlineResponse response = SendToLitle(request);
            return response.UpdatePlanResponse;
        }

        public RefundReversalResponse RefundReversal(RefundReversal refundReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.RefundReversal = refundReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.RefundReversalResponse;
        }

        public DepositReversalResponse DepositReversal(DepositReversal depositReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.DepositReversal = depositReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.DepositReversalResponse;
        }

        public ActivateReversalResponse ActivateReversal(ActivateReversal activateReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.ActivateReversal = activateReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.ActivateReversalResponse;
        }

        public DeactivateReversalResponse DeactivateReversal(DeactivateReversal deactivateReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.DeactivateReversal = deactivateReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.DeactivateReversalResponse;
        }

        public LoadReversalResponse LoadReversal(LoadReversal loadReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.LoadReversal = loadReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.LoadReversalResponse;
        }

        public UnloadReversalResponse UnloadReversal(UnloadReversal unloadReversal)
        {
            LitleOnlineRequest request = CreateLitleOnlineRequest();
            request.UnloadReversal = unloadReversal;

            LitleOnlineResponse response = SendToLitle(request);
            return response.UnloadReversalResponse;
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

        private LitleOnlineResponse SendToLitle(LitleOnlineRequest request)
        {
            var xmlRequest = request.Serialize();
            var xmlResponse = _communication.HttpPost(xmlRequest, _config);
            try
            {
                LitleOnlineResponse litleOnlineResponse = DeserializeObject(xmlResponse);
                if ("1".Equals(litleOnlineResponse.Response))
                {
                    throw new LitleOnlineException(litleOnlineResponse.Message);
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

        public static LitleOnlineResponse DeserializeObject(string response)
        {
            var serializer = new XmlSerializer(typeof (LitleOnlineResponse), "litleOnlineResponse");
            var reader = new StringReader(response);
            return (LitleOnlineResponse) serializer.Deserialize(reader);
        } // deserialize the object

        private void FillInReportGroup(TransactionTypeWithReportGroup txn)
        {
            if (txn.ReportGroup == null)
            {
                txn.ReportGroup = _config["reportGroup"];
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
}
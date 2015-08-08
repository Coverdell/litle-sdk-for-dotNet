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

        public authorizationResponse Authorize(authorization auth)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(auth);
            request.authorization = auth;

            litleOnlineResponse response = SendToLitle(request);
            return response.authorizationResponse;
        }

        public authReversalResponse AuthReversal(authReversal reversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(reversal);
            request.authReversal = reversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.authReversalResponse;
        }

        public captureResponse Capture(capture capture)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(capture);
            request.capture = capture;

            litleOnlineResponse response = SendToLitle(request);
            return response.captureResponse;
        }

        public captureGivenAuthResponse CaptureGivenAuth(captureGivenAuth captureGivenAuth)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(captureGivenAuth);
            request.captureGivenAuth = captureGivenAuth;

            litleOnlineResponse response = SendToLitle(request);
            return response.captureGivenAuthResponse;
        }

        public creditResponse Credit(credit credit)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(credit);
            request.credit = credit;

            litleOnlineResponse response = SendToLitle(request);
            return response.creditResponse;
        }

        public echeckCreditResponse EcheckCredit(echeckCredit echeckCredit)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckCredit);
            request.echeckCredit = echeckCredit;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckCreditResponse;
        }

        public echeckRedepositResponse EcheckRedeposit(echeckRedeposit echeckRedeposit)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckRedeposit);
            request.echeckRedeposit = echeckRedeposit;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckRedepositResponse;
        }

        public echeckSalesResponse EcheckSale(echeckSale echeckSale)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckSale);
            request.echeckSale = echeckSale;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckSalesResponse;
        }

        public echeckVerificationResponse EcheckVerification(echeckVerification echeckVerification)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckVerification);
            request.echeckVerification = echeckVerification;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckVerificationResponse;
        }

        public forceCaptureResponse ForceCapture(forceCapture forceCapture)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(forceCapture);
            request.forceCapture = forceCapture;

            litleOnlineResponse response = SendToLitle(request);
            return response.forceCaptureResponse;
        }

        public saleResponse Sale(sale sale)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(sale);
            request.sale = sale;

            litleOnlineResponse response = SendToLitle(request);
            return response.saleResponse;
        }

        public registerTokenResponse RegisterToken(registerTokenRequestType tokenRequest)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(tokenRequest);
            request.registerTokenRequest = tokenRequest;

            litleOnlineResponse response = SendToLitle(request);
            return response.registerTokenResponse;
        }

        public litleOnlineResponseTransactionResponseVoidResponse DoVoid(voidTxn v)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.voidTxn = v;

            litleOnlineResponse response = SendToLitle(request);
            return response.voidResponse;
        }

        public litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(echeckVoid v)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.echeckVoid = v;

            litleOnlineResponse response = SendToLitle(request);
            return response.echeckVoidResponse;
        }

        public updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(
            updateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            FillInReportGroup(updateCardValidationNumOnToken);
            request.updateCardValidationNumOnToken = updateCardValidationNumOnToken;

            litleOnlineResponse response = SendToLitle(request);
            return response.updateCardValidationNumOnTokenResponse;
        }

        public cancelSubscriptionResponse CancelSubscription(cancelSubscription cancelSubscription)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.cancelSubscription = cancelSubscription;

            litleOnlineResponse response = SendToLitle(request);
            return response.cancelSubscriptionResponse;
        }

        public updateSubscriptionResponse UpdateSubscription(updateSubscription updateSubscription)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.updateSubscription = updateSubscription;

            litleOnlineResponse response = SendToLitle(request);
            return response.updateSubscriptionResponse;
        }

        public activateResponse Activate(activate activate)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.activate = activate;

            litleOnlineResponse response = SendToLitle(request);
            return response.activateResponse;
        }

        public deactivateResponse Deactivate(deactivate deactivate)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.deactivate = deactivate;

            litleOnlineResponse response = SendToLitle(request);
            return response.deactivateResponse;
        }

        public loadResponse Load(load load)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.load = load;

            litleOnlineResponse response = SendToLitle(request);
            return response.loadResponse;
        }

        public unloadResponse Unload(unload unload)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.unload = unload;

            litleOnlineResponse response = SendToLitle(request);
            return response.unloadResponse;
        }

        public balanceInquiryResponse BalanceInquiry(balanceInquiry balanceInquiry)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.balanceInquiry = balanceInquiry;

            litleOnlineResponse response = SendToLitle(request);
            return response.balanceInquiryResponse;
        }

        public createPlanResponse CreatePlan(createPlan createPlan)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.createPlan = createPlan;

            litleOnlineResponse response = SendToLitle(request);
            return response.createPlanResponse;
        }

        public updatePlanResponse UpdatePlan(updatePlan updatePlan)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.updatePlan = updatePlan;

            litleOnlineResponse response = SendToLitle(request);
            return response.updatePlanResponse;
        }

        public refundReversalResponse RefundReversal(refundReversal refundReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.refundReversal = refundReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.refundReversalResponse;
        }

        public depositReversalResponse DepositReversal(depositReversal depositReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.depositReversal = depositReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.depositReversalResponse;
        }

        public activateReversalResponse ActivateReversal(activateReversal activateReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.activateReversal = activateReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.activateReversalResponse;
        }

        public deactivateReversalResponse DeactivateReversal(deactivateReversal deactivateReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.deactivateReversal = deactivateReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.deactivateReversalResponse;
        }

        public loadReversalResponse LoadReversal(loadReversal loadReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.loadReversal = loadReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.loadReversalResponse;
        }

        public unloadReversalResponse UnloadReversal(unloadReversal unloadReversal)
        {
            litleOnlineRequest request = CreateLitleOnlineRequest();
            request.unloadReversal = unloadReversal;

            litleOnlineResponse response = SendToLitle(request);
            return response.unloadReversalResponse;
        }

        private litleOnlineRequest CreateLitleOnlineRequest()
        {
            return new litleOnlineRequest
            {
                merchantId = _config["merchantId"],
                merchantSdk = "DotNet;9.3.2",
                authentication = new authentication {password = _config["password"], user = _config["username"]}
            };
        }

        private litleOnlineResponse SendToLitle(litleOnlineRequest request)
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

        public static String SerializeObject(litleOnlineRequest req)
        {
            var serializer = new XmlSerializer(typeof (litleOnlineRequest));
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

        private void FillInReportGroup(transactionTypeWithReportGroupAndPartial txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = _config["reportGroup"];
            }
        }
    }

    public interface ILitleOnline
    {
        authorizationResponse Authorize(authorization auth);
        authReversalResponse AuthReversal(authReversal reversal);
        captureResponse Capture(capture capture);
        captureGivenAuthResponse CaptureGivenAuth(captureGivenAuth captureGivenAuth);
        creditResponse Credit(credit credit);
        echeckCreditResponse EcheckCredit(echeckCredit echeckCredit);
        echeckRedepositResponse EcheckRedeposit(echeckRedeposit echeckRedeposit);
        echeckSalesResponse EcheckSale(echeckSale echeckSale);
        echeckVerificationResponse EcheckVerification(echeckVerification echeckVerification);
        forceCaptureResponse ForceCapture(forceCapture forceCapture);
        saleResponse Sale(sale sale);
        registerTokenResponse RegisterToken(registerTokenRequestType tokenRequest);
        litleOnlineResponseTransactionResponseVoidResponse DoVoid(voidTxn v);
        litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(echeckVoid v);
        updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(updateCardValidationNumOnToken update);
    }
}
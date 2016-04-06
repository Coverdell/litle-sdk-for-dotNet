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
        internal static readonly Dictionary<string, string> DefaultConfig = new Dictionary<string, string>
        {
            ["url"] = Settings.Default.url,
            ["reportGroup"] = Settings.Default.reportGroup,
            ["username"] = Settings.Default.username,
            ["timeout"] = Settings.Default.timeout,
            ["proxyHost"] = Settings.Default.proxyHost,
            ["merchantId"] = Settings.Default.merchantId,
            ["password"] = Settings.Default.password,
            ["proxyPort"] = Settings.Default.proxyPort
        };

        private readonly Dictionary<string, string> _config;
        private Communications _communications;

        /**
         * Construct a Litle online using the configuration specified in LitleSdkForNet.dll.config
         */
        public LitleOnline() : this(DefaultConfig)
        {
        }

        public LitleOnline(IDictionary<string, StringBuilder> cache) : this(cache, DefaultConfig)
        {
        }

        public LitleOnline(Communications communications) : this(communications, DefaultConfig)
        {
        }

        /// <summary>
        ///     Construct a LitleOnline specifying the configuration in code.  This should be used by integration that have another way
        ///     to specify their configuration settings or where different configurations are needed for different instances of LitleOnline.
        /// </summary>
        /// 
        /// <param name="config">
        ///     Properties that *must* be set are:
        ///         url (eg https://payments.litle.com/vap/communicator/online)
        ///         reportGroup (eg "Default Report Group")
        ///         username
        ///         merchantId
        ///         password
        ///         timeout (in seconds)
        ///     Optional properties are:
        ///         proxyHost
        ///         proxyPort
        ///         printxml (possible values "true" and "false" - defaults to false)
        /// </param>
        public LitleOnline(Dictionary<string, string> config) 
            : this(new Dictionary<string, StringBuilder>(), config)
        {
        }

        public LitleOnline(IDictionary<string, StringBuilder> cache, Dictionary<string, string> config) 
            : this(new Communications(cache), config)
        {
        }

        public LitleOnline(Communications communications, Dictionary<string, string> config)
        {
            _config = config;
            _communications = communications;
        }

        public void setCommunication(Communications communications)
        {
            _communications = communications;
        }

        public authorizationResponse Authorize(authorization auth)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(auth);
            request.authorization = auth;

            var response = SendToLitle(request);
            var authResponse = response.authorizationResponse;
            return authResponse;
        }

        public authReversalResponse AuthReversal(authReversal reversal)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(reversal);
            request.authReversal = reversal;

            var response = SendToLitle(request);
            var reversalResponse = response.authReversalResponse;
            return reversalResponse;
        }

        public captureResponse Capture(capture capture)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(capture);
            request.capture = capture;

            var response = SendToLitle(request);
            var captureResponse = response.captureResponse;
            return captureResponse;
        }

        public captureGivenAuthResponse CaptureGivenAuth(captureGivenAuth captureGivenAuth)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(captureGivenAuth);
            request.captureGivenAuth = captureGivenAuth;

            var response = SendToLitle(request);
            var captureGivenAuthResponse = response.captureGivenAuthResponse;
            return captureGivenAuthResponse;
        }

        public creditResponse Credit(credit credit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(credit);
            request.credit = credit;

            var response = SendToLitle(request);
            var creditResponse = response.creditResponse;
            return creditResponse;
        }

        public echeckCreditResponse EcheckCredit(echeckCredit echeckCredit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckCredit);
            request.echeckCredit = echeckCredit;

            var response = SendToLitle(request);
            var echeckCreditResponse = response.echeckCreditResponse;
            return echeckCreditResponse;
        }

        public echeckRedepositResponse EcheckRedeposit(echeckRedeposit echeckRedeposit)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckRedeposit);
            request.echeckRedeposit = echeckRedeposit;

            var response = SendToLitle(request);
            var echeckRedepositResponse = response.echeckRedepositResponse;
            return echeckRedepositResponse;
        }

        public echeckSalesResponse EcheckSale(echeckSale echeckSale)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckSale);
            request.echeckSale = echeckSale;

            var response = SendToLitle(request);
            var echeckSalesResponse = response.echeckSalesResponse;
            return echeckSalesResponse;
        }

        public echeckVerificationResponse EcheckVerification(echeckVerification echeckVerification)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(echeckVerification);
            request.echeckVerification = echeckVerification;

            var response = SendToLitle(request);
            var echeckVerificationResponse = response.echeckVerificationResponse;
            return echeckVerificationResponse;
        }

        public forceCaptureResponse ForceCapture(forceCapture forceCapture)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(forceCapture);
            request.forceCapture = forceCapture;

            var response = SendToLitle(request);
            var forceCaptureResponse = response.forceCaptureResponse;
            return forceCaptureResponse;
        }

        public saleResponse Sale(sale sale)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(sale);
            request.sale = sale;

            var response = SendToLitle(request);
            var saleResponse = response.saleResponse;
            return saleResponse;
        }

        public registerTokenResponse RegisterToken(registerTokenRequestType tokenRequest)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(tokenRequest);
            request.registerTokenRequest = tokenRequest;

            var response = SendToLitle(request);
            var registerTokenResponse = response.registerTokenResponse;
            return registerTokenResponse;
        }

        public litleOnlineResponseTransactionResponseVoidResponse DoVoid(voidTxn v)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.voidTxn = v;

            var response = SendToLitle(request);
            var voidResponse = response.voidResponse;
            return voidResponse;
        }

        public litleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(echeckVoid v)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(v);
            request.echeckVoid = v;

            var response = SendToLitle(request);
            var voidResponse = response.echeckVoidResponse;
            return voidResponse;
        }

        public updateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(
            updateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            var request = CreateLitleOnlineRequest();
            FillInReportGroup(updateCardValidationNumOnToken);
            request.updateCardValidationNumOnToken = updateCardValidationNumOnToken;

            var response = SendToLitle(request);
            var updateResponse = response.updateCardValidationNumOnTokenResponse;
            return updateResponse;
        }

        public cancelSubscriptionResponse CancelSubscription(cancelSubscription cancelSubscription)
        {
            var request = CreateLitleOnlineRequest();
            request.cancelSubscription = cancelSubscription;

            var response = SendToLitle(request);
            var cancelResponse = response.cancelSubscriptionResponse;
            return cancelResponse;
        }

        public updateSubscriptionResponse UpdateSubscription(updateSubscription updateSubscription)
        {
            var request = CreateLitleOnlineRequest();
            request.updateSubscription = updateSubscription;

            var response = SendToLitle(request);
            var updateResponse = response.updateSubscriptionResponse;
            return updateResponse;
        }

        public activateResponse Activate(activate activate)
        {
            var request = CreateLitleOnlineRequest();
            request.activate = activate;

            var response = SendToLitle(request);
            var activateResponse = response.activateResponse;
            return activateResponse;
        }

        public deactivateResponse Deactivate(deactivate deactivate)
        {
            var request = CreateLitleOnlineRequest();
            request.deactivate = deactivate;

            var response = SendToLitle(request);
            var deactivateResponse = response.deactivateResponse;
            return deactivateResponse;
        }

        public loadResponse Load(load load)
        {
            var request = CreateLitleOnlineRequest();
            request.load = load;

            var response = SendToLitle(request);
            var loadResponse = response.loadResponse;
            return loadResponse;
        }

        public unloadResponse Unload(unload unload)
        {
            var request = CreateLitleOnlineRequest();
            request.unload = unload;

            var response = SendToLitle(request);
            var unloadResponse = response.unloadResponse;
            return unloadResponse;
        }

        public balanceInquiryResponse BalanceInquiry(balanceInquiry balanceInquiry)
        {
            var request = CreateLitleOnlineRequest();
            request.balanceInquiry = balanceInquiry;

            var response = SendToLitle(request);
            var balanceInquiryResponse = response.balanceInquiryResponse;
            return balanceInquiryResponse;
        }

        public createPlanResponse CreatePlan(createPlan createPlan)
        {
            var request = CreateLitleOnlineRequest();
            request.createPlan = createPlan;

            var response = SendToLitle(request);
            var createPlanResponse = response.createPlanResponse;
            return createPlanResponse;
        }

        public updatePlanResponse UpdatePlan(updatePlan updatePlan)
        {
            var request = CreateLitleOnlineRequest();
            request.updatePlan = updatePlan;

            var response = SendToLitle(request);
            var updatePlanResponse = response.updatePlanResponse;
            return updatePlanResponse;
        }

        public refundReversalResponse RefundReversal(refundReversal refundReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.refundReversal = refundReversal;

            var response = SendToLitle(request);
            var refundReversalResponse = response.refundReversalResponse;
            return refundReversalResponse;
        }

        public depositReversalResponse DepositReversal(depositReversal depositReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.depositReversal = depositReversal;

            var response = SendToLitle(request);
            var depositReversalResponse = response.depositReversalResponse;
            return depositReversalResponse;
        }

        public activateReversalResponse ActivateReversal(activateReversal activateReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.activateReversal = activateReversal;

            var response = SendToLitle(request);
            var activateReversalResponse = response.activateReversalResponse;
            return activateReversalResponse;
        }

        public deactivateReversalResponse DeactivateReversal(deactivateReversal deactivateReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.deactivateReversal = deactivateReversal;

            var response = SendToLitle(request);
            var deactivateReversalResponse = response.deactivateReversalResponse;
            return deactivateReversalResponse;
        }

        public loadReversalResponse LoadReversal(loadReversal loadReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.loadReversal = loadReversal;

            var response = SendToLitle(request);
            var loadReversalResponse = response.loadReversalResponse;
            return loadReversalResponse;
        }

        public unloadReversalResponse UnloadReversal(unloadReversal unloadReversal)
        {
            var request = CreateLitleOnlineRequest();
            request.unloadReversal = unloadReversal;

            var response = SendToLitle(request);
            var unloadReversalResponse = response.unloadReversalResponse;
            return unloadReversalResponse;
        }

        private litleOnlineRequest CreateLitleOnlineRequest() => new litleOnlineRequest
        {
            merchantId = _config["merchantId"],
            merchantSdk = "DotNet;9.3.2",
            authentication = new authentication
            {
                password = _config["password"],
                user = _config["username"]
            }
        };

        private litleOnlineResponse SendToLitle(litleOnlineRequest request)
        {
            var xmlRequest = request.Serialize();
            var xmlResponse = _communications.HttpPost(xmlRequest, _config);
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

        public static string SerializeObject(litleOnlineRequest req)
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

using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false, ElementName = "litleOnlineResponse")]
    public class LitleOnlineResponse
    {
        private string _responseField;
        private string _messageField;
        private string _versionField;

        [XmlElement("authReversalResponse")]
        public AuthReversalResponse AuthReversalResponse;
        [XmlElement("authorizationResponse")]
        public AuthorizationResponse AuthorizationResponse;
        [XmlElement("captureGivenAuthResponse")]
        public CaptureGivenAuthResponse CaptureGivenAuthResponse;
        [XmlElement("captureResponse")]
        public CaptureResponse CaptureResponse;
        [XmlElement("creditResponse")]
        public CreditResponse CreditResponse;
        [XmlElement("echeckCreditResponse")]
        public EcheckCreditResponse EcheckCreditResponse;
        [XmlElement("echeckRedepositResponse")]
        public EcheckRedepositResponse EcheckRedepositResponse;
        [XmlElement("echeckSalesResponse")]
        public EcheckSalesResponse EcheckSalesResponse;
        [XmlElement("echeckVerificationResponse")]
        public EcheckVerificationResponse EcheckVerificationResponse;
        [XmlElement("echeckVoidResponse")]
        public LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoidResponse;
        [XmlElement("forceCaptureResponse")]
        public ForceCaptureResponse ForceCaptureResponse;
        [XmlElement("registerTokenResponse")]
        public RegisterTokenResponse RegisterTokenResponse;
        [XmlElement("saleResponse")]
        public SaleResponse SaleResponse;
        [XmlElement("voidResponse")]
        public LitleOnlineResponseTransactionResponseVoidResponse VoidResponse;
        [XmlElement("updateCardValidationNumOnTokenResponse")]
        public UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnTokenResponse;
        [XmlElement("cancelSubscriptionResponse")]
        public CancelSubscriptionResponse CancelSubscriptionResponse;
        [XmlElement("updateSubscriptionResponse")]
        public UpdateSubscriptionResponse UpdateSubscriptionResponse;
        [XmlElement("activateResponse")]
        public ActivateResponse ActivateResponse;
        [XmlElement("deactivateResponse")]
        public DeactivateResponse DeactivateResponse;
        [XmlElement("loadResponse")]
        public LoadResponse LoadResponse;
        [XmlElement("unloadResponse")]
        public UnloadResponse UnloadResponse;
        [XmlElement("balanceInquiryResponse")]
        public BalanceInquiryResponse BalanceInquiryResponse;
        [XmlElement("createPlanResponse")]
        public CreatePlanResponse CreatePlanResponse;
        [XmlElement("updatePlanResponse")]
        public UpdatePlanResponse UpdatePlanResponse;
        [XmlElement("refundReversalResponse")]
        public RefundReversalResponse RefundReversalResponse;
        [XmlElement("depositReversalResponse")]
        public DepositReversalResponse DepositReversalResponse;
        [XmlElement("activateReversalResponse")]
        public ActivateReversalResponse ActivateReversalResponse;
        [XmlElement("deactivateReversalResponse")]
        public DeactivateReversalResponse DeactivateReversalResponse;
        [XmlElement("loadReversalResponse")]
        public LoadReversalResponse LoadReversalResponse;
        [XmlElement("unloadReversalResponse")]
        public UnloadReversalResponse UnloadReversalResponse;

        [XmlAttribute("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlAttribute("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute("version")]
        public string Version
        {
            get { return _versionField; }
            set { _versionField = value; }
        }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlRoot("litleOnlineResponse", Namespace = "http://www.litle.com/schema", IsNullable = false, ElementName = "litleOnlineResponse")]
    public class LitleOnlineResponse
    {
        [XmlElement("authReversalResponse")]
        public AuthReversalResponse AuthReversalResponse { get; set; }
        [XmlElement("authorizationResponse")]
        public AuthorizationResponse AuthorizationResponse { get; set; }
        [XmlElement("captureGivenAuthResponse")]
        public CaptureGivenAuthResponse CaptureGivenAuthResponse { get; set; }
        [XmlElement("captureResponse")]
        public CaptureResponse CaptureResponse { get; set; }
        [XmlElement("creditResponse")]
        public CreditResponse CreditResponse { get; set; }
        [XmlElement("echeckCreditResponse")]
        public EcheckCreditResponse EcheckCreditResponse { get; set; }
        [XmlElement("echeckRedepositResponse")]
        public EcheckRedepositResponse EcheckRedepositResponse { get; set; }
        [XmlElement("echeckSalesResponse")]
        public EcheckSalesResponse EcheckSalesResponse { get; set; }
        [XmlElement("echeckVerificationResponse")]
        public EcheckVerificationResponse EcheckVerificationResponse { get; set; }
        [XmlElement("echeckVoidResponse")]
        public LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoidResponse { get; set; }
        [XmlElement("forceCaptureResponse")]
        public ForceCaptureResponse ForceCaptureResponse { get; set; }
        [XmlElement("registerTokenResponse")]
        public RegisterTokenResponse RegisterTokenResponse { get; set; }
        [XmlElement("saleResponse")]
        public SaleResponse SaleResponse { get; set; }
        [XmlElement("voidResponse")]
        public LitleOnlineResponseTransactionResponseVoidResponse VoidResponse { get; set; }
        [XmlElement("updateCardValidationNumOnTokenResponse")]
        public UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnTokenResponse { get; set; }
        [XmlElement("cancelSubscriptionResponse")]
        public CancelSubscriptionResponse CancelSubscriptionResponse { get; set; }
        [XmlElement("updateSubscriptionResponse")]
        public UpdateSubscriptionResponse UpdateSubscriptionResponse { get; set; }
        [XmlElement("activateResponse")]
        public ActivateResponse ActivateResponse { get; set; }
        [XmlElement("deactivateResponse")]
        public DeactivateResponse DeactivateResponse { get; set; }
        [XmlElement("loadResponse")]
        public LoadResponse LoadResponse { get; set; }
        [XmlElement("unloadResponse")]
        public UnloadResponse UnloadResponse { get; set; }
        [XmlElement("balanceInquiryResponse")]
        public BalanceInquiryResponse BalanceInquiryResponse { get; set; }
        [XmlElement("createPlanResponse")]
        public CreatePlanResponse CreatePlanResponse { get; set; }
        [XmlElement("updatePlanResponse")]
        public UpdatePlanResponse UpdatePlanResponse { get; set; }
        [XmlElement("refundReversalResponse")]
        public RefundReversalResponse RefundReversalResponse { get; set; }
        [XmlElement("depositReversalResponse")]
        public DepositReversalResponse DepositReversalResponse { get; set; }
        [XmlElement("activateReversalResponse")]
        public ActivateReversalResponse ActivateReversalResponse { get; set; }
        [XmlElement("deactivateReversalResponse")]
        public DeactivateReversalResponse DeactivateReversalResponse { get; set; }
        [XmlElement("loadReversalResponse")]
        public LoadReversalResponse LoadReversalResponse { get; set; }
        [XmlElement("unloadReversalResponse")]
        public UnloadReversalResponse UnloadReversalResponse { get; set; }

        [XmlAttribute("response")]
        public string Response { get; set; }

        [XmlAttribute("message")]
        public string Message { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }
    }
}
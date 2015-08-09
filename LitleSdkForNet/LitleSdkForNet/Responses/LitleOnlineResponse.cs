using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponse
    {
        private string _responseField;
        private string _messageField;
        private string _versionField;

        public AuthReversalResponse AuthReversalResponse;
        public AuthorizationResponse AuthorizationResponse;
        public CaptureGivenAuthResponse CaptureGivenAuthResponse;
        public CaptureResponse CaptureResponse;
        public CreditResponse CreditResponse;
        public EcheckCreditResponse EcheckCreditResponse;
        public EcheckRedepositResponse EcheckRedepositResponse;
        public EcheckSalesResponse EcheckSalesResponse;
        public EcheckVerificationResponse EcheckVerificationResponse;
        public LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoidResponse;
        public ForceCaptureResponse ForceCaptureResponse;
        public RegisterTokenResponse RegisterTokenResponse;
        public SaleResponse SaleResponse;
        public LitleOnlineResponseTransactionResponseVoidResponse VoidResponse;
        public UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnTokenResponse;
        public CancelSubscriptionResponse CancelSubscriptionResponse;
        public UpdateSubscriptionResponse UpdateSubscriptionResponse;
        public ActivateResponse ActivateResponse;
        public DeactivateResponse DeactivateResponse;
        public LoadResponse LoadResponse;
        public UnloadResponse UnloadResponse;
        public BalanceInquiryResponse BalanceInquiryResponse;
        public CreatePlanResponse CreatePlanResponse;
        public UpdatePlanResponse UpdatePlanResponse;
        public RefundReversalResponse RefundReversalResponse;
        public DepositReversalResponse DepositReversalResponse;
        public ActivateReversalResponse ActivateReversalResponse;
        public DeactivateReversalResponse DeactivateReversalResponse;
        public LoadReversalResponse LoadReversalResponse;
        public UnloadReversalResponse UnloadReversalResponse;

        [XmlAttribute]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlAttribute]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute]
        public string Version
        {
            get { return _versionField; }
            set { _versionField = value; }
        }
    }
}
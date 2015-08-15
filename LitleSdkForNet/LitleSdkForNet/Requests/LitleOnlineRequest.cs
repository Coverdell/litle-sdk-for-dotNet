namespace Litle.Sdk.Requests
{
    public class LitleOnlineRequest
    {
        public string MerchantId { get; set; }
        public string MerchantSdk { get; set; }
        public Authentication Authentication { get; set; }
        public Authorization Authorization { get; set; }
        public Capture Capture { get; set; }
        public Credit Credit { get; set; }
        public VoidTxn VoidTxn { get; set; }
        public Sale Sale { get; set; }
        public AuthReversal AuthReversal { get; set; }
        public EcheckCredit EcheckCredit { get; set; }
        public EcheckVerification EcheckVerification { get; set; }
        public EcheckSale EcheckSale { get; set; }
        public RegisterTokenRequestType RegisterTokenRequest { get; set; }
        public ForceCapture ForceCapture { get; set; }
        public CaptureGivenAuth CaptureGivenAuth { get; set; }
        public EcheckRedeposit EcheckRedeposit { get; set; }
        public EcheckVoid EcheckVoid { get; set; }
        public UpdateCardValidationNumOnToken UpdateCardValidationNumOnToken { get; set; }
        public UpdateSubscription UpdateSubscription { get; set; }
        public CancelSubscription CancelSubscription { get; set; }
        public Activate Activate { get; set; }
        public Deactivate Deactivate { get; set; }
        public Load Load { get; set; }
        public Unload Unload { get; set; }
        public BalanceInquiry BalanceInquiry { get; set; }
        public CreatePlan CreatePlan { get; set; }
        public UpdatePlan UpdatePlan { get; set; }
        public RefundReversal RefundReversal { get; set; }
        public LoadReversal LoadReversal { get; set; }
        public DepositReversal DepositReversal { get; set; }
        public ActivateReversal ActivateReversal { get; set; }
        public DeactivateReversal DeactivateReversal { get; set; }
        public UnloadReversal UnloadReversal { get; set; }

        public string Serialize()
        {
            var xml = "<?xml version='1.0' encoding='utf-8'?>\r\n<litleOnlineRequest merchantId=\"" + MerchantId +
                      "\" version=\"9.3\" merchantSdk=\"" + MerchantSdk + "\" xmlns=\"http://www.litle.com/schema\">"
                      + Authentication.Serialize();

            if (Authorization != null) xml += Authorization.Serialize();
            else if (Capture != null) xml += Capture.Serialize();
            else if (Credit != null) xml += Credit.Serialize();
            else if (VoidTxn != null) xml += VoidTxn.Serialize();
            else if (Sale != null) xml += Sale.Serialize();
            else if (AuthReversal != null) xml += AuthReversal.Serialize();
            else if (EcheckCredit != null) xml += EcheckCredit.Serialize();
            else if (EcheckVerification != null) xml += EcheckVerification.Serialize();
            else if (EcheckSale != null) xml += EcheckSale.Serialize();
            else if (RegisterTokenRequest != null) xml += RegisterTokenRequest.Serialize();
            else if (ForceCapture != null) xml += ForceCapture.Serialize();
            else if (CaptureGivenAuth != null) xml += CaptureGivenAuth.Serialize();
            else if (EcheckRedeposit != null) xml += EcheckRedeposit.Serialize();
            else if (EcheckVoid != null) xml += EcheckVoid.Serialize();
            else if (UpdateCardValidationNumOnToken != null) xml += UpdateCardValidationNumOnToken.Serialize();
            else if (UpdateSubscription != null) xml += UpdateSubscription.Serialize();
            else if (CancelSubscription != null) xml += CancelSubscription.Serialize();
            else if (Activate != null) xml += Activate.Serialize();
            else if (Deactivate != null) xml += Deactivate.Serialize();
            else if (Load != null) xml += Load.Serialize();
            else if (Unload != null) xml += Unload.Serialize();
            else if (BalanceInquiry != null) xml += BalanceInquiry.Serialize();
            else if (CreatePlan != null) xml += CreatePlan.Serialize();
            else if (UpdatePlan != null) xml += UpdatePlan.Serialize();
            else if (RefundReversal != null) xml += RefundReversal.Serialize();
            else if (LoadReversal != null) xml += LoadReversal.Serialize();
            else if (DepositReversal != null) xml += DepositReversal.Serialize();
            else if (ActivateReversal != null) xml += ActivateReversal.Serialize();
            else if (DeactivateReversal != null) xml += DeactivateReversal.Serialize();
            else if (UnloadReversal != null) xml += UnloadReversal.Serialize();
            xml += "\r\n</litleOnlineRequest>";

            return xml;
        }
    }
}
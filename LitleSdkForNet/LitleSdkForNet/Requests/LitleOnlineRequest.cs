namespace Litle.Sdk.Requests
{
    public class LitleOnlineRequest
    {
        public string MerchantId;
        public string MerchantSdk;
        public Authentication Authentication;
        public Authorization Authorization;
        public Capture Capture;
        public Credit Credit;
        public VoidTxn VoidTxn;
        public Sale Sale;
        public AuthReversal AuthReversal;
        public EcheckCredit EcheckCredit;
        public EcheckVerification EcheckVerification;
        public EcheckSale EcheckSale;
        public RegisterTokenRequestType RegisterTokenRequest;
        public ForceCapture ForceCapture;
        public CaptureGivenAuth CaptureGivenAuth;
        public EcheckRedeposit EcheckRedeposit;
        public EcheckVoid EcheckVoid;
        public UpdateCardValidationNumOnToken UpdateCardValidationNumOnToken;
        public UpdateSubscription UpdateSubscription;
        public CancelSubscription CancelSubscription;
        public Activate Activate;
        public Deactivate Deactivate;
        public Load Load;
        public Unload Unload;
        public BalanceInquiry BalanceInquiry;
        public CreatePlan CreatePlan;
        public UpdatePlan UpdatePlan;
        public RefundReversal RefundReversal;
        public LoadReversal LoadReversal;
        public DepositReversal DepositReversal;
        public ActivateReversal ActivateReversal;
        public DeactivateReversal DeactivateReversal;
        public UnloadReversal UnloadReversal;

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
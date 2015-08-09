using Litle.Sdk.Requests;
using Litle.Sdk.Responses;

namespace Litle.Sdk
{
    public interface ILitleOnline
    {
        AuthorizationResponse Authorize(Authorization auth);
        AuthReversalResponse AuthReversal(AuthReversal reversal);
        CaptureResponse Capture(Capture capture);
        CaptureGivenAuthResponse CaptureGivenAuth(CaptureGivenAuth captureGivenAuth);
        CreditResponse Credit(Credit credit);
        EcheckCreditResponse EcheckCredit(EcheckCredit echeckCredit);
        EcheckRedepositResponse EcheckRedeposit(EcheckRedeposit echeckRedeposit);
        EcheckSalesResponse EcheckSale(EcheckSale echeckSale);
        EcheckVerificationResponse EcheckVerification(EcheckVerification echeckVerification);
        ForceCaptureResponse ForceCapture(ForceCapture forceCapture);
        SaleResponse Sale(Sale sale);
        RegisterTokenResponse RegisterToken(RegisterTokenRequestType tokenRequest);
        LitleOnlineResponseTransactionResponseVoidResponse DoVoid(VoidTxn v);
        LitleOnlineResponseTransactionResponseEcheckVoidResponse EcheckVoid(EcheckVoid v);
        UpdateCardValidationNumOnTokenResponse UpdateCardValidationNumOnToken(UpdateCardValidationNumOnToken update);
    }
}
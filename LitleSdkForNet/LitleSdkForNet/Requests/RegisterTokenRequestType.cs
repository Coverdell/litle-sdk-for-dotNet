using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class RegisterTokenRequestType : TransactionTypeWithReportGroup
    {
        public string OrderId;
        public string AccountNumber;
        public EcheckForTokenType EcheckForToken;
        public string PaypageRegistrationId;
        public string CardValidationNum;
        public ApplepayType Applepay;

        public override string Serialize()
        {
            var xml = "\r\n<registerTokenRequest";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
            xml += ">";

            xml += "\r\n<orderId>" + OrderId + "</orderId>";
            if (AccountNumber != null) xml += "\r\n<accountNumber>" + AccountNumber + "</accountNumber>";
            else if (EcheckForToken != null)
                xml += "\r\n<echeckForToken>" + EcheckForToken.Serialize() + "</echeckForToken>";
            else if (PaypageRegistrationId != null)
                xml += "\r\n<paypageRegistrationId>" + PaypageRegistrationId + "</paypageRegistrationId>";
            else if (Applepay != null) xml += "\r\n<applepay>" + Applepay.Serialize() + "\r\n</applepay>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + CardValidationNum + "</cardValidationNum>";
            xml += "\r\n</registerTokenRequest>";
            return xml;
        }
    }
}
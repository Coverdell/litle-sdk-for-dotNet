using System.Security;

namespace Litle.Sdk.Requests
{
    public class PayPal
    {
        public string PayerId;
        public string PayerEmail;
        public string Token;
        public string TransactionId;

        public string Serialize()
        {
            var xml = "";
            if (PayerId != null) xml += "\r\n<payerId>" + SecurityElement.Escape(PayerId) + "</payerId>";
            if (PayerEmail != null) xml += "\r\n<payerEmail>" + SecurityElement.Escape(PayerEmail) + "</payerEmail>";
            if (Token != null) xml += "\r\n<token>" + SecurityElement.Escape(Token) + "</token>";
            if (TransactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(TransactionId) + "</transactionId>";
            return xml;
        }
    }
}
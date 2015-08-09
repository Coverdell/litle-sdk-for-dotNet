using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class AccountUpdate : TransactionTypeWithReportGroup
    {
        public string OrderId { get; set; }
        public CardType Card { get; set; }
        public CardTokenType Token { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<accountUpdate ";

            if (ID != null)
            {
                xml += "id=\"" + SecurityElement.Escape(ID) + "\" ";
            }
            if (CustomerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(CustomerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";

            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";

            if (Card != null)
            {
                xml += "\r\n<card>";
                xml += Card.Serialize();
                xml += "\r\n</card>";
            }
            else if (Token != null)
            {
                xml += "\r\n<token>";
                xml += Token.Serialize();
                xml += "\r\n</token>";
            }

            xml += "\r\n</accountUpdate>";

            return xml;
        }
    }
}
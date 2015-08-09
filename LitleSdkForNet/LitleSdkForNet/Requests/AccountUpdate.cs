using System.Security;

namespace Litle.Sdk.Requests
{
    public class AccountUpdate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public CardType Card;
        public CardTokenType Token;

        public override string Serialize()
        {
            var xml = "\r\n<accountUpdate ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";

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
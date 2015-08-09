using System.Security;

namespace Litle.Sdk.Requests
{
    public class UpdateCardValidationNumOnToken : transactionTypeWithReportGroup
    {
        public string OrderId;
        public string LitleToken;
        public string CardValidationNum;

        public override string Serialize()
        {
            var xml = "\r\n<updateCardValidationNumOnToken";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\"";
            xml += ">";

            if (OrderId != null) xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            if (LitleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (CardValidationNum != null)
                xml += "\r\n<cardValidationNum>" + SecurityElement.Escape(CardValidationNum) + "</cardValidationNum>";
            xml += "\r\n</updateCardValidationNumOnToken>";
            return xml;
        }
    }
}
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class UpdateCardValidationNumOnToken : TransactionTypeWithReportGroup
    {
        public string OrderId { get; set; }
        public string LitleToken { get; set; }
        public string CardValidationNum { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<updateCardValidationNumOnToken";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\"";
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
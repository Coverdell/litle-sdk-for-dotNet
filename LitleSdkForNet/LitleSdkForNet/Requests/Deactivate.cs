using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class Deactivate : TransactionTypeWithReportGroup
    {
        public string OrderId { get; set; }
        public OrderSourceType OrderSource { get; set; }
        public CardType Card { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<deactivate";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</deactivate>";
            return xml;
        }
    }
}
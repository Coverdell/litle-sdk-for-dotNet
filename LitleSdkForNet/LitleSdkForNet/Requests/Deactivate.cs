using System.Security;

namespace Litle.Sdk.Requests
{
    public class Deactivate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public OrderSourceType OrderSource;
        public CardType Card;

        public override string Serialize()
        {
            var xml = "\r\n<deactivate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            xml += "\r\n</deactivate>";
            return xml;
        }
    }
}
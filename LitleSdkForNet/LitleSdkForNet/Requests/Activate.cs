using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class Activate : TransactionTypeWithReportGroup
    {
        public string OrderId { get; set; }
        public long Amount { get; set; }
        public OrderSourceType OrderSource { get; set; }
        public CardType Card { get; set; }
        public VirtualGiftCardType VirtualGiftCard { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<activate";
            xml += " id=\"" + SecurityElement.Escape(ID) + "\"";
            if (CustomerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(CustomerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(ReportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(OrderId) + "</orderId>";
            xml += "\r\n<amount>" + Amount + "</amount>";
            xml += "\r\n<orderSource>" + OrderSource.Serialize() + "</orderSource>";
            if (Card != null) xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            else if (VirtualGiftCard != null)
                xml += "\r\n<virtualGiftCard>" + VirtualGiftCard.Serialize() + "\r\n</virtualGiftCard>";
            xml += "\r\n</activate>";
            return xml;
        }
    }
}
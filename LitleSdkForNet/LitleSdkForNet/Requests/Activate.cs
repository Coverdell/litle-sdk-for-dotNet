using System.Security;

namespace Litle.Sdk.Requests
{
    public class Activate : transactionTypeWithReportGroup
    {
        public string OrderId;
        public long Amount;
        public OrderSourceType OrderSource;
        public CardType Card;
        public VirtualGiftCardType VirtualGiftCard;

        public override string Serialize()
        {
            var xml = "\r\n<activate";
            xml += " id=\"" + SecurityElement.Escape(id) + "\"";
            if (customerId != null)
            {
                xml += " customerId=\"" + SecurityElement.Escape(customerId) + "\"";
            }
            xml += " reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
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
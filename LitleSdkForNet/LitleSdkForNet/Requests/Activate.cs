using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("activate")]
    public class Activate : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
        [XmlElement("virtualGiftCard")]
        public VirtualGiftCardType VirtualGiftCard { get; set; }
    }
}
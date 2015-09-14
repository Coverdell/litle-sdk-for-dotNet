using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("balanceInquiry")]
    public class BalanceInquiry : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
    }
}
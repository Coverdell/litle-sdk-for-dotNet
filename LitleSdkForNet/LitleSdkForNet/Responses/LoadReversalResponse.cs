using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("loadReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("loadReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LoadReversalResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public string LitleTxnId { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("response")]
        public string Response { get; set; }
        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
        [XmlElement("postDate")]
        public DateTime PostDate { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse { get; set; }
    }
}
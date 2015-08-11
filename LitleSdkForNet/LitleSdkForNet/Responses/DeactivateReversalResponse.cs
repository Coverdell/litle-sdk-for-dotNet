using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("deactivateReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("deactivateReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DeactivateReversalResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public string LitleTxnId;
        [XmlElement("orderId")]
        public string OrderId;
        [XmlElement("response")]
        public string Response;
        [XmlElement("responseTime")]
        public DateTime ResponseTime;
        [XmlElement("postDate")]
        public DateTime PostDate;
        [XmlElement("message")]
        public string Message;
        [XmlElement("fraudResult")]
        public FraudResult FraudResult;
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse;
    }
}
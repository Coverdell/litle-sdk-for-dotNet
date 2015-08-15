using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("authReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("authReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AuthReversalResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse;

        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate { get; set; }

        [XmlIgnore]
        public bool PostDateSpecified { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
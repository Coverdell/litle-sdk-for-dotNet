using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("updateCardValidationNumOnTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("updateCardValidationNumOnTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateCardValidationNumOnTokenResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
    }
}
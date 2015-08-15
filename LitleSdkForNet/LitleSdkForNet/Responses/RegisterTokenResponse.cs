using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("registerTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("registerTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RegisterTokenResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("litleToken")]
        public string LitleToken { get; set; }

        [XmlElement("bin")]
        public string Bin { get; set; }

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum? Type { get; set; }

        [XmlElement("eCheckAccountSuffix")]
        public string ECheckAccountSuffix { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse { get; set; }
    }
}
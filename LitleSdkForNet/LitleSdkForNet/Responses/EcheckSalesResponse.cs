using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckSalesResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckSalesResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckSalesResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("verificationCode")]
        public string VerificationCode { get; set; }

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate { get; set; }

        [XmlIgnore]
        public bool PostDateSpecified { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
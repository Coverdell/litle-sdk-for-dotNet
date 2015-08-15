using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckSalesResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckSalesResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckSalesResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlElement("verificationCode")]
        public string VerificationCode { get; set; }

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
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckVerificationResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckVerificationResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckVerificationResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
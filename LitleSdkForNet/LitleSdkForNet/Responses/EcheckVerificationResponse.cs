using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("echeckVerificationResponse")]
    public class EcheckVerificationResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("captureGivenAuthResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("captureGivenAuthResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CaptureGivenAuthResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
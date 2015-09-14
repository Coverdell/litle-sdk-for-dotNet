using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("captureGivenAuthResponse")]
    [LitleXmlRoot("captureGivenAuthResponse")]
    public class CaptureGivenAuthResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
using System.Xml.Serialization;

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
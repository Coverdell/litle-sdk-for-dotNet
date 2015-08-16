using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("forceCaptureResponse")]
    [LitleXmlRoot("forceCaptureResponse")]
    public class ForceCaptureResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
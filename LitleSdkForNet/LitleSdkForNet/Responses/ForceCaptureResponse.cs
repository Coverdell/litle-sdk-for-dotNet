using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("forceCaptureResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("forceCaptureResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ForceCaptureResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
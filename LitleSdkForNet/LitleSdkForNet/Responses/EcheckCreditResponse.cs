using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("echeckCreditResponse")]
    public class EcheckCreditResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
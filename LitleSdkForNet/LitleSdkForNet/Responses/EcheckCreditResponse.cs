using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckCreditResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("creditResponse")]
    public class CreditResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("accountUpdater")]
    [LitleXmlRoot("accountUpdater")]
    public class AccountUpdater
    {
        [XmlElement("extendedCardResponse")]
        public ExtendedCardResponseType ExtendedCardResponse { get; set; }
        [XmlElement("newAccountInfo")]
        public EcheckAccountInfoType NewAccountInfo { get; set; }
        [XmlElement("newCardInfo")]
        public CardAccountInfoType NewCardInfo { get; set; }
        [XmlElement("newCardTokenInfo")]
        public CardTokenInfoType NewCardTokenInfo { get; set; }
        [XmlElement("newTokenInfo")]
        public EcheckTokenInfoType NewTokenInfo { get; set; }
        [XmlElement("originalAccountInfo")]
        public EcheckAccountInfoType OriginalAccountInfo { get; set; }
        [XmlElement("originalCardInfo")]
        public CardAccountInfoType OriginalCardInfo { get; set; }
        [XmlElement("originalCardTokenInfo")]
        public CardTokenInfoType OriginalCardTokenInfo { get; set; }
        [XmlElement("originalTokenInfo")]
        public EcheckTokenInfoType OriginalTokenInfo { get; set; }
    }
}
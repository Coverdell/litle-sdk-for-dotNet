using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("accountUpdater", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("accountUpdater", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdater
    {
        [XmlElement("extendedCardResponse")]
        public ExtendedCardResponseType ExtendedCardResponse;
        [XmlElement("newAccountInfo")]
        public EcheckAccountInfoType NewAccountInfo;
        [XmlElement("newCardInfo")]
        public CardAccountInfoType NewCardInfo;
        [XmlElement("newCardTokenInfo")]
        public CardTokenInfoType NewCardTokenInfo;
        [XmlElement("newTokenInfo")]
        public EcheckTokenInfoType NewTokenInfo;
        [XmlElement("originalAccountInfo")]
        public EcheckAccountInfoType OriginalAccountInfo;
        [XmlElement("originalCardInfo")]
        public CardAccountInfoType OriginalCardInfo;
        [XmlElement("originalCardTokenInfo")]
        public CardTokenInfoType OriginalCardTokenInfo;
        [XmlElement("originalTokenInfo")]
        public EcheckTokenInfoType OriginalTokenInfo;
    }
}
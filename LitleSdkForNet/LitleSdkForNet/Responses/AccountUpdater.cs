using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("accountUpdater", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("accountUpdater", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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
using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdater
    {
        public ExtendedCardResponseType ExtendedCardResponse;
        public EcheckAccountInfoType NewAccountInfo;
        public CardAccountInfoType NewCardInfo;
        public CardTokenInfoType NewCardTokenInfo;
        public EcheckTokenInfoType NewTokenInfo;
        public EcheckAccountInfoType OriginalAccountInfo;
        public CardAccountInfoType OriginalCardInfo;
        public CardTokenInfoType OriginalCardTokenInfo;
        public EcheckTokenInfoType OriginalTokenInfo;
    }
}
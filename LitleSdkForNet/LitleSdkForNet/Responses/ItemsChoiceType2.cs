using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {
        ExtendedCardResponse,
        NewAccountInfo,
        NewCardInfo,
        NewCardTokenInfo,
        NewTokenInfo,
        OriginalAccountInfo,
        OriginalCardInfo,
        OriginalCardTokenInfo,
        OriginalTokenInfo,
    }
}
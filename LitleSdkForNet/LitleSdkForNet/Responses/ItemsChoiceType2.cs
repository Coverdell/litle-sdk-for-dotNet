using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemsChoiceType2", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
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
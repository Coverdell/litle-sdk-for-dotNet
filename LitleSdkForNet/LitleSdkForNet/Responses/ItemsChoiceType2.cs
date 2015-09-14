using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("ItemsChoiceType2", IncludeInSchema = false)]
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
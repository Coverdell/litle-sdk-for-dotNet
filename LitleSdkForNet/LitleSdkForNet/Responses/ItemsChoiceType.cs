using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("ItemsChoiceType", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        ExpDate,
        Number,
        Track,
        Type,
    }
}
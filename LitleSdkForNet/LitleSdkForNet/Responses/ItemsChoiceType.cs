using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemsChoiceType", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        ExpDate,
        Number,
        Track,
        Type,
    }
}
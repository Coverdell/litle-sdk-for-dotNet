using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemChoiceType1", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {
        City,
        Phone,
        Url,
    }
}
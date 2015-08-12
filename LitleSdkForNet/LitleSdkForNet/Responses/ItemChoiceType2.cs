using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("ItemChoiceType2", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {
        PayerEmail,
        PayerId,
    }
}
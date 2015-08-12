using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("Item1ChoiceType", Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum Item1ChoiceType
    {
        CardholderAuthentication,
        FraudCheck,
    }
}
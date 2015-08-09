using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {
        City,
        Phone,
        Url,
    }
}
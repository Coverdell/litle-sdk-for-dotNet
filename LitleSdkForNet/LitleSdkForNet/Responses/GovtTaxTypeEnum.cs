using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("GovtTaxTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum GovtTaxTypeEnum
    {
        Payment,
        Fee,
    }
}
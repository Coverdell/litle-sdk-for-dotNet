using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cardProductTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum CardProductTypeEnum
    {
        [XmlEnum("UNKNOWN")] 
        Unknown,
        [XmlEnum("COMMERCIAL")]
        Commercial,
        [XmlEnum("CONSUMER")]
        Consumer,
    }
}
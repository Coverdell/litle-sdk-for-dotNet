using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("cardProductTypeEnum")]
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
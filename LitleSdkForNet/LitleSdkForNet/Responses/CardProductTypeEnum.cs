using System.Xml.Serialization;
using Litle.Sdk.Xml;

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
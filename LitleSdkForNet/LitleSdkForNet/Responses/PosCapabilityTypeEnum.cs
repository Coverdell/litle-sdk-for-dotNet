using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("posCapabilityTypeEnum")]
    public enum PosCapabilityTypeEnum
    {
        [XmlEnum("notused")]
        Notused,
        [XmlEnum("magstripe")]
        Magstripe,
        [XmlEnum("keyedonly")]
        Keyedonly,
    }
}
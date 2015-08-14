using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("posCapabilityTypeEnum", Namespace = "http://www.litle.com/schema")]
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
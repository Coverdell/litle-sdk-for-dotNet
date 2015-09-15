using System.Xml.Serialization;
using Litle.Sdk.Xml;

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
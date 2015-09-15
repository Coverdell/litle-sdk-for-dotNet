using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("posEntryModeTypeEnum")]
    public enum PosEntryModeTypeEnum
    {
        [XmlEnum("notused")]
        Notused,
        [XmlEnum("keyed")]
        Keyed,
        [XmlEnum("track1")]
        Track1,
        [XmlEnum("track2")]
        Track2,
        [XmlEnum("completeread")]
        Completeread,
    }
}
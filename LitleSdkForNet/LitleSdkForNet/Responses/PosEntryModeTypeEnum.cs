using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("posEntryModeTypeEnum", Namespace = "http://www.litle.com/schema")]
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
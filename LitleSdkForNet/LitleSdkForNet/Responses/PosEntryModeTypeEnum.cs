using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosEntryModeTypeEnum
    {
        Notused,
        Keyed,
        Track1,
        Track2,
        Completeread,
    }
}
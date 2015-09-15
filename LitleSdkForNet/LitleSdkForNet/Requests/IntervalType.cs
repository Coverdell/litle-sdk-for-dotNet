using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("intervalType")]
    public enum IntervalType
    {
        [XmlEnum("ANNUAL")]
        Annual,
        [XmlEnum("SEMIANNUAL")]
        Semiannual,
        [XmlEnum("QUARTERLY")]
        Quarterly,
        [XmlEnum("MONTHLY")]
        Monthly,
        [XmlEnum("WEEKLY")]
        Weekly
    }
}
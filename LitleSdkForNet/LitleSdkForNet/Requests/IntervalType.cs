using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Requests
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
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
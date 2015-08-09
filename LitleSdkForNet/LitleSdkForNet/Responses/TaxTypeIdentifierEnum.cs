using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum TaxTypeIdentifierEnum
    {
        [XmlEnum("00")] Item00,
        [XmlEnum("01")] Item01,
        [XmlEnum("02")] Item02,
        [XmlEnum("03")] Item03,
        [XmlEnum("04")] Item04,
        [XmlEnum("05")] Item05,
        [XmlEnum("06")] Item06,
        [XmlEnum("10")] Item10,
        [XmlEnum("11")] Item11,
        [XmlEnum("12")] Item12,
        [XmlEnum("13")] Item13,
        [XmlEnum("14")] Item14,
        [XmlEnum("20")] Item20,
        [XmlEnum("21")] Item21,
        [XmlEnum("22")] Item22,
    }
}
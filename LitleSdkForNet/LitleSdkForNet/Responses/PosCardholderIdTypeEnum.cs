using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("posCardholderIdTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum PosCardholderIdTypeEnum
    {
        [XmlEnum("signature")]
        Signature,
        [XmlEnum("pin")]
        Pin,
        [XmlEnum("nopin")]
        Nopin,
        [XmlEnum("directmarket")]
        Directmarket,
    }
}
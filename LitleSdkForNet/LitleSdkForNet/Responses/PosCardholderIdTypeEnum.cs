using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("posCardholderIdTypeEnum")]
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
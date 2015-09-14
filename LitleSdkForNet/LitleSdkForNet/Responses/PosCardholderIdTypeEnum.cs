using System.Xml.Serialization;
using Litle.Sdk.Xml;

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
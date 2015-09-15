using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk
{
    [LitleXmlType("methodOfPaymentTypeEnum")]
    public enum MethodOfPaymentTypeEnum
    {
        MC,
        VI,
        AX,
        DC,
        DI,
        PP,
        JC,
        BL,
        EC,
        GC,
        [XmlEnum("")] Item,
    }
}
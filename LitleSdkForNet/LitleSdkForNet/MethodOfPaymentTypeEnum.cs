using System;
using System.Xml.Serialization;

namespace Litle.Sdk
{
    [Serializable]
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
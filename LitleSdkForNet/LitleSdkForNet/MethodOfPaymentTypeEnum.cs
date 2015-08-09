using System;
using System.Xml.Serialization;

namespace Litle.Sdk
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
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
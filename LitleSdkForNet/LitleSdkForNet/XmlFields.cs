using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Litle.Sdk
{
    [GeneratedCode("xsd", "2.0.50727.42")]
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

    public abstract class MethodOfPaymentSerializer
    {
        public static String Serialize(MethodOfPaymentTypeEnum mop)
        {
            return mop == MethodOfPaymentTypeEnum.Item ? "" : mop.ToString();
        }
    }
}
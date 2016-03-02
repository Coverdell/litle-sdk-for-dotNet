using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Litle.Sdk
{
    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum MethodOfPaymentTypeEnum
    {
        /// <remarks />
        MC,

        /// <remarks />
        VI,

        /// <remarks />
        AX,

        /// <remarks />
        DC,

        /// <remarks />
        DI,

        /// <remarks />
        PP,

        /// <remarks />
        JC,

        /// <remarks />
        BL,

        /// <remarks />
        EC,

        /// <remarks />
        GC,

        /// <remarks />
        [XmlEnum("")] Item
    }

    public abstract class MethodOfPaymentSerializer
    {
        public static string Serialize(MethodOfPaymentTypeEnum mop)
        {
            return mop == MethodOfPaymentTypeEnum.Item ? "" : mop.ToString();
        }
    }
}
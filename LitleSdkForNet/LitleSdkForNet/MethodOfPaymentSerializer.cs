using System;

namespace Litle.Sdk
{
    public abstract class MethodOfPaymentSerializer
    {
        public static String Serialize(MethodOfPaymentTypeEnum mop)
        {
            return mop == MethodOfPaymentTypeEnum.Item ? "" : mop.ToString();
        }
    }
}
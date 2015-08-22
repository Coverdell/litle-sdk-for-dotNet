namespace Litle.Sdk
{
    public abstract class MethodOfPaymentSerializer
    {
        public static string Serialize(MethodOfPaymentTypeEnum mop)
        {
            return mop == MethodOfPaymentTypeEnum.Item ? "" : mop.ToString();
        }
    }
}
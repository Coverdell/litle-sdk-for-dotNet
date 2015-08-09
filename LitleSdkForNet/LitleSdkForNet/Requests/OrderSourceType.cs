using System;

namespace Litle.Sdk.Requests
{
    public sealed class OrderSourceType
    {
        public static readonly OrderSourceType Ecommerce = new OrderSourceType("ecommerce");
        public static readonly OrderSourceType Installment = new OrderSourceType("installment");
        public static readonly OrderSourceType Mailorder = new OrderSourceType("mailorder");
        public static readonly OrderSourceType Recurring = new OrderSourceType("recurring");
        public static readonly OrderSourceType Retail = new OrderSourceType("retail");
        public static readonly OrderSourceType Telephone = new OrderSourceType("telephone");
        public static readonly OrderSourceType Item3DsAuthenticated = new OrderSourceType("3dsAuthenticated");
        public static readonly OrderSourceType Item3DsAttempted = new OrderSourceType("3dsAttempted");
        public static readonly OrderSourceType Recurringtel = new OrderSourceType("recurringtel");
        public static readonly OrderSourceType Echeckppd = new OrderSourceType("echeckppd");
        public static readonly OrderSourceType Applepay = new OrderSourceType("applepay");

        private OrderSourceType(String value)
        {
            _value = value;
        }

        public string Serialize()
        {
            return _value;
        }

        private readonly string _value;
    }
}
using System.Security;

namespace Litle.Sdk.Requests
{
    public class DeleteDiscount
    {
        public string DiscountCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            return xml;
        }
    }
}
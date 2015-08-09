using System.Security;

namespace Litle.Sdk.Requests
{
    public class AmexAggregatorData
    {
        public string SellerId;
        public string SellerMerchantCategoryCode;

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<sellerId>" + SecurityElement.Escape(SellerId) + "</sellerId>";
            xml += "\r\n<sellerMerchantCategoryCode>" + SecurityElement.Escape(SellerMerchantCategoryCode) +
                   "</sellerMerchantCategoryCode>";
            return xml;
        }
    }
}
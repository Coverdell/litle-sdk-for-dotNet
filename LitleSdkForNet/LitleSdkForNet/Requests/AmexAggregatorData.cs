using System.Security;

namespace Litle.Sdk.Requests
{
    public class AmexAggregatorData
    {
        public string SellerId { get; set; }
        public string SellerMerchantCategoryCode { get; set; }

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
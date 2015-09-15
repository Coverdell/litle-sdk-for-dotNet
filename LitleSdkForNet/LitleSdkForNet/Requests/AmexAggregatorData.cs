using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("amexAggregatorData")]
    public class AmexAggregatorData
    {
        [XmlElement("sellerId")]
        public string SellerId { get; set; }
        [XmlElement("sellerMerchantCategoryCode")]
        public string SellerMerchantCategoryCode { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("billMeLaterRequest")]
    public class BillMeLaterRequest
    {
        [XmlElement("bmlMerchantId", IsNullable = true)]
        public long? BmlMerchantId { get; set; }
        [XmlElement("bmlProductType", IsNullable = true)]
        public long? BmlProductType { get; set; }
        [XmlElement("termsAndConditions", IsNullable = true)]
        public int? TermsAndConditions { get; set; }
        [XmlElement("preapprovalNumber")]
        public string PreapprovalNumber { get; set; }
        [XmlElement("merchantPromotionalCode", IsNullable = true)]
        public int? MerchantPromotionalCode { get; set; }
        [XmlElement("virtualAuthenticationKeyPresenceIndicator")]
        public string VirtualAuthenticationKeyPresenceIndicator { get; set; }
        [XmlElement("virtualAuthenticationKeyData")]
        public string VirtualAuthenticationKeyData { get; set; }
        [XmlElement("itemCategoryCode", IsNullable = true)]
        public int? ItemCategoryCode { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
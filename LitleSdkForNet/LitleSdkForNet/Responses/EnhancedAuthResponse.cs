using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("enhancedAuthResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("enhancedAuthResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EnhancedAuthResponse
    {
        [XmlElement("fundingSource")]
        public EnhancedAuthResponseFundingSource FundingSource { get; set; }

        [XmlElement("affluence", IsNullable = true)]
        public AffluenceTypeEnum? Affluence { get; set; }

        [XmlElement("issuerCountry")]
        public string IssuerCountry { get; set; }

        [XmlElement("cardProductType", IsNullable = true)]
        public CardProductTypeEnum? CardProductType { get; set; }

        [XmlElement("virtualAccountNumber")]
        public bool VirtualAccountNumber { get; set; }
    }
}
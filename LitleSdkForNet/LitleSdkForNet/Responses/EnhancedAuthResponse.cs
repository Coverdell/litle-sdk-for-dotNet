using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("enhancedAuthResponse")]
    [LitleXmlRoot("enhancedAuthResponse")]
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
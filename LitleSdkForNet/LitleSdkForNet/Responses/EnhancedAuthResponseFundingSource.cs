using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("enhancedAuthResponseFundingSource", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class EnhancedAuthResponseFundingSource
    {
        [XmlElement("type")]
        public FundingSourceTypeEnum Type { get; set; }

        [XmlElement("availableBalance")]
        public string AvailableBalance { get; set; }

        [XmlElement("reloadable")]
        public string Reloadable { get; set; }

        [XmlElement("prepaidCardType")]
        public string PrepaidCardType { get; set; }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("enhancedAuthResponseFundingSource")]
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
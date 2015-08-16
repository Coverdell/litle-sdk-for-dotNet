using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("advancedFraudResultsType")]
    [LitleXmlRoot("advancedFraudResultsType")]
    public class AdvancedFraudResultsType
    {
        [XmlElement("deviceReviewStatus")]
        public string DeviceReviewStatus { get; set; }
        [XmlElement("deviceReputationScore")]
        public int DeviceReputationScore { get; set; }
        [XmlElement("triggeredRule")]
        public string TriggeredRule { get; set; }
    }
}
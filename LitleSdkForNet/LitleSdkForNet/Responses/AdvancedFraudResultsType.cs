using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("advancedFraudResultsType", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("advancedFraudResultsType", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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
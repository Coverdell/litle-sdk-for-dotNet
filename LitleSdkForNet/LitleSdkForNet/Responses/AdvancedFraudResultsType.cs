using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AdvancedFraudResultsType
    {
        [XmlElement("deviceReviewStatus")]
        public string DeviceReviewStatus;
        [XmlElement("deviceReputationScore")]
        public int DeviceReputationScore;
        [XmlElement("triggeredRule")]
        public string TriggeredRule;
    }
}
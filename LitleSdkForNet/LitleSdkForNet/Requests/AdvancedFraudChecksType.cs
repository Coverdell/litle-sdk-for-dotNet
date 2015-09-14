using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("advancedFraudChecksType")]
    public class AdvancedFraudChecksType
    {
        [XmlElement("threatMetrixSessionId")]
        public string ThreatMetrixSessionId { get; set; }
        [XmlElement("customAttribute1")]
        public string CustomAttribute1 { get; set; }
        [XmlElement("customAttribute2")]
        public string CustomAttribute2 { get; set; }
        [XmlElement("customAttribute3")]
        public string CustomAttribute3 { get; set; }
        [XmlElement("customAttribute4")]
        public string CustomAttribute4 { get; set; }
        [XmlElement("customAttribute5")]
        public string CustomAttribute5 { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
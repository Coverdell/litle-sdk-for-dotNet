using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recyclingType", Namespace = "http://www.litle.com/schema")]
    public class RecyclingType
    {
        [XmlElement("recycleAdvice")]
        public RecycleAdviceType RecycleAdvice { get; set; }

        [XmlElement("recycleEngineActive")]
        public bool RecycleEngineActive { get; set; }
    }
}
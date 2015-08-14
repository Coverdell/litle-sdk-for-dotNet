using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecyclingType
    {
        private RecycleAdviceType _recycleAdviceField;
        private bool _recycleEngineActiveField;

        [XmlElement("recycleAdvice")]
        public RecycleAdviceType RecycleAdvice
        {
            get { return _recycleAdviceField; }
            set { _recycleAdviceField = value; }
        }

        [XmlElement("recycleEngineActive")]
        public bool RecycleEngineActive
        {
            get { return _recycleEngineActiveField; }
            set { _recycleEngineActiveField = value; }
        }
    }
}
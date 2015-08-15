using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recycleAdviceType", Namespace = "http://www.litle.com/schema")]
    public class RecycleAdviceType
    {
        [XmlElement("nextRecycleTime", typeof (DateTime)), XmlElement("recycleAdviceEnd", typeof (string))]
        public object Item { get; set; }
    }
}
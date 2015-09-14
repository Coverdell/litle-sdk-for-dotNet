using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("recycleAdviceType")]
    public class RecycleAdviceType
    {
        [XmlElement("nextRecycleTime", typeof (DateTime))]
        [XmlElement("recycleAdviceEnd", typeof (string))]
        public object Item { get; set; }
    }
}
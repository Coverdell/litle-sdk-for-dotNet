using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecycleAdviceType
    {
        private object _itemField;

        [XmlElement("nextRecycleTime", typeof (DateTime))]
        [XmlElement("recycleAdviceEnd", typeof (string))]
        public object Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }
    }
}
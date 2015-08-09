using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecyclingType
    {
        private RecycleAdviceType _recycleAdviceField;
        private bool _recycleEngineActiveField;

        public RecycleAdviceType RecycleAdvice
        {
            get { return _recycleAdviceField; }
            set { _recycleAdviceField = value; }
        }

        public bool RecycleEngineActive
        {
            get { return _recycleEngineActiveField; }
            set { _recycleEngineActiveField = value; }
        }
    }
}
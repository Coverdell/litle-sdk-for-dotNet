using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class EcheckAccountInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _accNumField;
        private string _routingNumField;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        public string AccNum
        {
            get { return _accNumField; }
            set { _accNumField = value; }
        }

        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }
}
using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class EcheckTokenInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _litleTokenField;
        private string _routingNumField;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }
}
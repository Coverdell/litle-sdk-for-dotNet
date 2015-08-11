using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckTokenInfoType", Namespace = "http://www.litle.com/schema")]
    public class EcheckTokenInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _litleTokenField;
        private string _routingNumField;

        [XmlElement("accType")]
        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        [XmlElement("litleToken")]
        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        [XmlElement("routingNum")]
        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }
}
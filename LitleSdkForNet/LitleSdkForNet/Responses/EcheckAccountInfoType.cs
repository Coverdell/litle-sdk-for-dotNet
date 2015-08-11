using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckAccountInfoType", Namespace = "http://www.litle.com/schema")]
    public class EcheckAccountInfoType
    {
        private EcheckAccountTypeEnum _accTypeField;
        private string _accNumField;
        private string _routingNumField;

        [XmlElement("accType")]
        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set { _accTypeField = value; }
        }

        [XmlElement("accNum")]
        public string AccNum
        {
            get { return _accNumField; }
            set { _accNumField = value; }
        }

        [XmlElement("routingNum")]
        public string RoutingNum
        {
            get { return _routingNumField; }
            set { _routingNumField = value; }
        }
    }
}
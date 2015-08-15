using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckTokenInfoType", Namespace = "http://www.litle.com/schema")]
    public class EcheckTokenInfoType
    {
        [XmlElement("accType")]
        public EcheckAccountTypeEnum AccType { get; set; }

        [XmlElement("litleToken")]
        public string LitleToken { get; set; }

        [XmlElement("routingNum")]
        public string RoutingNum { get; set; }
    }
}
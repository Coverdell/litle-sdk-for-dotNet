using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("echeckTokenInfoType")]
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
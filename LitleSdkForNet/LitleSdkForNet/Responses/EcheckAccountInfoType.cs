using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("echeckAccountInfoType")]
    public class EcheckAccountInfoType
    {
        [XmlElement("accType")]
        public EcheckAccountTypeEnum AccType { get; set; }

        [XmlElement("accNum")]
        public string AccNum { get; set; }

        [XmlElement("routingNum")]
        public string RoutingNum { get; set; }
    }
}
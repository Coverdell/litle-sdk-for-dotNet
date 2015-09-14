using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckTokenType")]
    public class EcheckTokenType
    {
        [XmlElement("litleToken")]
        public string LitleToken { get; set; }
        [XmlElement("routingNum")]
        public string RoutingNum { get; set; }
        [XmlElement("accType")]
        public EcheckAccountTypeEnum? AccType { get; set; }
        [XmlElement("checkNum")]
        public string CheckNum { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
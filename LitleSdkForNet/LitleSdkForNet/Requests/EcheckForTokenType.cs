using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckForTokenType")]
    public class EcheckForTokenType
    {
        [XmlElement("accNum")]
        public string AccNum { get; set; }
        [XmlElement("routingNum")]
        public string RoutingNum { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("RFRResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("RFRResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RFRResponse
    {
        [XmlAttribute("response")] 
        public string Response;
        [XmlAttribute("message")] 
        public string Message;
    }
}
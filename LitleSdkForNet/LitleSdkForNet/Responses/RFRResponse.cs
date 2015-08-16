using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("RFRResponse")]
    public class RFRResponse
    {
        [XmlAttribute("response")] 
        public string Response;
        [XmlAttribute("message")] 
        public string Message;
    }
}
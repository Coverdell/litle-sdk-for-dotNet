using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("extendedCardResponseType", Namespace = "http://www.litle.com/schema")]
    public class ExtendedCardResponseType
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("extendedCardResponseType")]
    public class ExtendedCardResponseType
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }
    }
}
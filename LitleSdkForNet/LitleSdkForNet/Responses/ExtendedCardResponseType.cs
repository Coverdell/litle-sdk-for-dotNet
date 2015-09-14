using System.Xml.Serialization;
using Litle.Sdk.Xml;

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
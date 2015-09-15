using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("authentication")]
    [LitleXmlRoot("authentication")]
    public class Authentication
    {
        [XmlElement("user")]
        public string User { get; set; }
        [XmlElement("password")]
        public string Password { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
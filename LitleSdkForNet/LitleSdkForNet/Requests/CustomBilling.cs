using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("customBilling")]
    public class CustomBilling
    {
        [XmlElement("phone")]
        public string Phone { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("url")]
        public string Url { get; set; }
        [XmlElement("descriptor")]
        public string Descriptor { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
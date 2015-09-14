using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("applepay")]
    public class ApplepayType
    {
        [XmlElement("data")]
        public string Data { get; set; }
        [XmlElement("header")]
        public ApplepayHeaderType Header { get; set; }
        [XmlElement("signature")]
        public string Signature { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
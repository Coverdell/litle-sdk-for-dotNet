using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("filteringType")]
    public class FilteringType
    {
        [XmlElement("prepaid")]
        public bool? Prepaid { get; set; }
        [XmlElement("international")]
        public bool? International { get; set; }
        [XmlElement("chargeback")]
        public bool? Chargeback { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
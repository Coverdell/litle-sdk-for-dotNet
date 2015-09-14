using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("recyclingRequestType")]
    public class RecyclingRequestType
    {
        [XmlElement("recycleBy")]
        public RecycleByTypeEnum? RecycleBy { get; set; }
        [XmlElement("recycleId")]
        public string RecycleId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
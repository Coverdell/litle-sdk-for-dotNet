using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("merchantDataType")]
    public class MerchantDataType
    {
        [XmlElement("campaign")]
        public string Campaign { get; set; }
        [XmlElement("affiliate")]
        public string Affiliate { get; set; }
        [XmlElement("merchantGroupingId")]
        public string MerchantGroupingId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
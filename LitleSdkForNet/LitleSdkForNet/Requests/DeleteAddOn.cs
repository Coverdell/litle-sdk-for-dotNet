using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("deleteAddOn")]
    public class DeleteAddOn
    {
        [XmlElement("addOnCode")]
        public string AddOnCode { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
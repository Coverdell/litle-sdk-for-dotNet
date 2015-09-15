using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("processingInstructions")]
    public class ProcessingInstructions
    {
        [XmlElement("bypassVelocityCheck")]
        public bool? BypassVelocityCheck { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
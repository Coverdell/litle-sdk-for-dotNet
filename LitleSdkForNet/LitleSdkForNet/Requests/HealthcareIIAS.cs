using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("helthcareIIAS")]
    public class HealthcareIIAS
    {
        [XmlElement("healthcareAmounts")]
        public HealthcareAmounts HealthcareAmounts { get; set; }
        [XmlElement("IIASFlag")]
        public IIASFlagType? IIASFlag { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
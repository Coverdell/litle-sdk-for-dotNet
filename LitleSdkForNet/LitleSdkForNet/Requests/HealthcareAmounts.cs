using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("healthcardAmounts")]
    public class HealthcareAmounts
    {
        [XmlElement("totalHealthcareAmount")]
        public int? TotalHealthcareAmount { get; set; }
        [XmlElement("rxAmount")]
        public int? RxAmount { get; set; }
        [XmlElement("visionAmount")]
        public int? VisionAmount { get; set; }
        [XmlElement("clinicOtherAmount")]
        public int? ClinicOtherAmount { get; set; }
        [XmlElement("dentalAmount")]
        public int? DentalAmount { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
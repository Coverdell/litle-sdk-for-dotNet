using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("driversLicenseInfo")]
    public class DriversLicenseInfo
    {
        [XmlElement("licenseNumber")]
        public string LicenseNumber { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("dateOfBirth")]
        public string DateOfBirth { get; set; }
    }
}
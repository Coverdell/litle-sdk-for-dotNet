using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("driversLicenseInfo", Namespace = "http://www.litle.com/schema")]
    public class DriversLicenseInfo
    {
        private string _licenseNumberField;
        private string _stateField;
        private string _dateOfBirthField;

        [XmlElement("licenseNumber")]
        public string LicenseNumber
        {
            get { return _licenseNumberField; }
            set { _licenseNumberField = value; }
        }

        [XmlElement("state")]
        public string State
        {
            get { return _stateField; }
            set { _stateField = value; }
        }

        [XmlElement("dateOfBirth")]
        public string DateOfBirth
        {
            get { return _dateOfBirthField; }
            set { _dateOfBirthField = value; }
        }
    }
}
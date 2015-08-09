using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class DriversLicenseInfo
    {
        private string _licenseNumberField;
        private string _stateField;
        private string _dateOfBirthField;

        public string LicenseNumber
        {
            get { return _licenseNumberField; }
            set { _licenseNumberField = value; }
        }

        public string State
        {
            get { return _stateField; }
            set { _stateField = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirthField; }
            set { _dateOfBirthField = value; }
        }
    }
}
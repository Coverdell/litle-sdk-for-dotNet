using System.Security;

namespace Litle.Sdk.Requests
{
    public class Contact
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        private CountryTypeEnum _countryField;
        private bool _countrySpecified;

        public CountryTypeEnum Country
        {
            get { return _countryField; }
            set
            {
                _countryField = value;
                _countrySpecified = true;
            }
        }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Name != null) xml += "\r\n<name>" + SecurityElement.Escape(Name) + "</name>";
            if (FirstName != null) xml += "\r\n<firstName>" + SecurityElement.Escape(FirstName) + "</firstName>";
            if (MiddleInitial != null)
                xml += "\r\n<middleInitial>" + SecurityElement.Escape(MiddleInitial) + "</middleInitial>";
            if (LastName != null) xml += "\r\n<lastName>" + SecurityElement.Escape(LastName) + "</lastName>";
            if (CompanyName != null)
                xml += "\r\n<companyName>" + SecurityElement.Escape(CompanyName) + "</companyName>";
            if (AddressLine1 != null)
                xml += "\r\n<addressLine1>" + SecurityElement.Escape(AddressLine1) + "</addressLine1>";
            if (AddressLine2 != null)
                xml += "\r\n<addressLine2>" + SecurityElement.Escape(AddressLine2) + "</addressLine2>";
            if (AddressLine3 != null)
                xml += "\r\n<addressLine3>" + SecurityElement.Escape(AddressLine3) + "</addressLine3>";
            if (City != null) xml += "\r\n<city>" + SecurityElement.Escape(City) + "</city>";
            if (State != null) xml += "\r\n<state>" + SecurityElement.Escape(State) + "</state>";
            if (Zip != null) xml += "\r\n<zip>" + SecurityElement.Escape(Zip) + "</zip>";
            if (_countrySpecified) xml += "\r\n<country>" + _countryField + "</country>";
            if (Email != null) xml += "\r\n<email>" + SecurityElement.Escape(Email) + "</email>";
            if (Phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(Phone) + "</phone>";
            return xml;
        }
    }
}
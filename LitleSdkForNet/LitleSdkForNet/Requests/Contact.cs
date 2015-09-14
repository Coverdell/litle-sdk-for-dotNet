using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("contact")]
    public class Contact
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("middleInitial")]
        public string MiddleInitial { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlElement("companyName")]
        public string CompanyName { get; set; }
        [XmlElement("addressLine1")]
        public string AddressLine1 { get; set; }
        [XmlElement("addressLine2")]
        public string AddressLine2 { get; set; }
        [XmlElement("addressLine3")]
        public string AddressLine3 { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("state")]
        public string State { get; set; }
        [XmlElement("zip")]
        public string Zip { get; set; }
        [XmlElement("country", IsNullable = true)]
        public CountryTypeEnum? Country { get; set; }
        [XmlElement("email")]
        public string Email { get; set; }
        [XmlElement("phone")]
        public string Phone { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
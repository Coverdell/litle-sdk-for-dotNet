using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("createDiscount")]
    public class CreateDiscount
    {
        [XmlElement("discountCode")]
        public string DiscountCode { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("startDate")]
        public DateTime StartDate { get; set; }
        [XmlElement("endDate")]
        public DateTime EndDate { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
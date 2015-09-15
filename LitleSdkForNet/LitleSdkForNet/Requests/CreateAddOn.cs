using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("createAddOn")]
    public class CreateAddOn
    {
        [XmlElement("addOnCode")]
        public string AddOnCode { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("startDate", DataType = "date")]
        public DateTime StartDate { get; set; }
        [XmlElement("endDate", DataType = "date")]
        public DateTime EndDate { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
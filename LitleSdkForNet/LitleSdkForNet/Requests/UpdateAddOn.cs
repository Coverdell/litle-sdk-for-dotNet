using System;
using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("updateAddOn")]
    public class UpdateAddOn
    {
        [XmlElement("addOnCode")]
        public string AddOnCode { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("amount")]
        public long? Amount { get; set; }
        [XmlElement("startDate")]
        public DateTime? StartDate { get; set; }
        [XmlElement("endDate")]
        public DateTime? EndDate { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
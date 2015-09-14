using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("subscription")]
    public class Subscription
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
        [XmlElement("numberOfPayments", IsNullable = true)]
        public int? NumberOfPayments { get; set; }
        [XmlElement("startDate", DataType = "date", IsNullable = true)]
        public DateTime? StartDate { get; set; }
        [XmlElement("amount", IsNullable = true)]
        public long? Amount { get; set; }
        [XmlArray("createDiscount", IsNullable = true)]
        public List<CreateDiscount> CreateDiscounts { get; set; }
        [XmlArray("createAddOn", IsNullable = true)]
        public List<CreateAddOn> CreateAddOns { get; set; }

        public Subscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            CreateAddOns = new List<CreateAddOn>();
        }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
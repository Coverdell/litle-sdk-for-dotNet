using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("updateSubscription")]
    public class UpdateSubscription : RecurringTransactionType
    {
        [XmlElement("subscriptionId")]
        public long? SubscriptionId { get; set; }
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
        [XmlElement("token")]
        public CardTokenType Token { get; set; }
        [XmlElement("paypage")]
        public CardPaypageType Paypage { get; set; }
        [XmlElement("billingDate")]
        public DateTime? BillingDate { get; set; }
        [XmlArray("createDiscount")]
        public List<CreateDiscount> CreateDiscounts { get; set; }
        [XmlArray("updateDiscount")]
        public List<UpdateDiscount> UpdateDiscounts { get; set; }
        [XmlArray("deleteDiscount")]
        public List<DeleteDiscount> DeleteDiscounts { get; set; }
        [XmlArray("createAddOn")]
        public List<CreateAddOn> CreateAddOns { get; set; }
        [XmlArray("updateAddOn")]
        public List<UpdateAddOn> UpdateAddOns { get; set; }
        [XmlArray("deleteAddOn")]
        public List<DeleteAddOn> DeleteAddOns { get; set; }

        public UpdateSubscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            UpdateDiscounts = new List<UpdateDiscount>();
            DeleteDiscounts = new List<DeleteDiscount>();
            CreateAddOns = new List<CreateAddOn>();
            UpdateAddOns = new List<UpdateAddOn>();
            DeleteAddOns = new List<DeleteAddOn>();
        }
    }
}
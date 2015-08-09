using System;
using System.Collections.Generic;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class UpdateSubscription : recurringTransactionType
    {
        private long _subscriptionIdField;
        private bool _subscriptionIdSet;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set
            {
                _subscriptionIdField = value;
                _subscriptionIdSet = true;
            }
        }

        public string PlanCode;
        public Contact BillToAddress;
        public CardType Card;
        public CardTokenType Token;
        public CardPaypageType Paypage;
        private DateTime _billingDateField;
        private bool _billingDateSet;

        public DateTime BillingDate
        {
            get { return _billingDateField; }
            set
            {
                _billingDateField = value;
                _billingDateSet = true;
            }
        }

        public List<CreateDiscount> CreateDiscounts;
        public List<UpdateDiscount> UpdateDiscounts;
        public List<DeleteDiscount> DeleteDiscounts;
        public List<CreateAddOn> CreateAddOns;
        public List<UpdateAddOn> UpdateAddOns;
        public List<DeleteAddOn> DeleteAddOns;

        public UpdateSubscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            UpdateDiscounts = new List<UpdateDiscount>();
            DeleteDiscounts = new List<DeleteDiscount>();
            CreateAddOns = new List<CreateAddOn>();
            UpdateAddOns = new List<UpdateAddOn>();
            DeleteAddOns = new List<DeleteAddOn>();
        }

        public override String Serialize()
        {
            var xml = "\r\n<updateSubscription>";
            if (_subscriptionIdSet) xml += "\r\n<subscriptionId>" + _subscriptionIdField + "</subscriptionId>";
            if (PlanCode != null) xml += "\r\n<planCode>" + SecurityElement.Escape(PlanCode) + "</planCode>";
            if (BillToAddress != null)
                xml += "\r\n<billToAddress>" + BillToAddress.Serialize() + "\r\n</billToAddress>";
            if (Card != null) xml += "\r\n<card>" + Card.Serialize() + "\r\n</card>";
            else if (Token != null) xml += "\r\n<token>" + Token.Serialize() + "\r\n</token>";
            else if (Paypage != null) xml += "\r\n<paypage>" + Paypage.Serialize() + "\r\n</paypage>";
            if (_billingDateSet) xml += "\r\n<billingDate>" + XmlUtil.ToXsdDate(_billingDateField) + "</billingDate>";
            foreach (var createDiscount in CreateDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var updateDiscount in UpdateDiscounts)
            {
                xml += "\r\n<updateDiscount>" + updateDiscount.Serialize() + "\r\n</updateDiscount>";
            }
            foreach (var deleteDiscount in DeleteDiscounts)
            {
                xml += "\r\n<deleteDiscount>" + deleteDiscount.Serialize() + "\r\n</deleteDiscount>";
            }
            foreach (var createAddOn in CreateAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }
            foreach (var updateAddOn in UpdateAddOns)
            {
                xml += "\r\n<updateAddOn>" + updateAddOn.Serialize() + "\r\n</updateAddOn>";
            }
            foreach (var deleteAddOn in DeleteAddOns)
            {
                xml += "\r\n<deleteAddOn>" + deleteAddOn.Serialize() + "\r\n</deleteAddOn>";
            }
            xml += "\r\n</updateSubscription>";
            return xml;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Litle.Sdk.Requests
{
    public class Subscription
    {
        public string PlanCode { get; set; }
        private bool _numberOfPaymentsSet;
        private int _numberOfPaymentsField;

        public int NumberOfPayments
        {
            get { return _numberOfPaymentsField; }
            set
            {
                _numberOfPaymentsField = value;
                _numberOfPaymentsSet = true;
            }
        }

        private bool _startDateSet;
        private DateTime _startDateField;

        public DateTime StartDate
        {
            get { return _startDateField; }
            set
            {
                _startDateField = value;
                _startDateSet = true;
            }
        }

        private bool _amountSet;
        private long _amountField;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        public List<CreateDiscount> CreateDiscounts { get; set; }
        public List<CreateAddOn> CreateAddOns { get; set; }

        public Subscription()
        {
            CreateDiscounts = new List<CreateDiscount>();
            CreateAddOns = new List<CreateAddOn>();
        }


        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<planCode>" + PlanCode + "</planCode>";
            if (_numberOfPaymentsSet) xml += "\r\n<numberOfPayments>" + NumberOfPayments + "</numberOfPayments>";
            if (_startDateSet) xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(_startDateField) + "</startDate>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            foreach (var createDiscount in CreateDiscounts)
            {
                xml += "\r\n<createDiscount>" + createDiscount.Serialize() + "\r\n</createDiscount>";
            }
            foreach (var createAddOn in CreateAddOns)
            {
                xml += "\r\n<createAddOn>" + createAddOn.Serialize() + "\r\n</createAddOn>";
            }

            return xml;
        }
    }
}
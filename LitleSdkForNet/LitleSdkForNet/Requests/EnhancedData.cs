using System;
using System.Collections.Generic;
using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EnhancedData
    {
        public string CustomerReference { get; set; }
        private long _salesTaxField;
        private bool _salesTaxSet;

        public long SalesTax
        {
            get { return _salesTaxField; }
            set
            {
                _salesTaxField = value;
                _salesTaxSet = true;
            }
        }

        private EnhancedDataDeliveryType _deliveryTypeField;
        private bool _deliveryTypeSet;

        public EnhancedDataDeliveryType DeliveryType
        {
            get { return _deliveryTypeField; }
            set
            {
                _deliveryTypeField = value;
                _deliveryTypeSet = true;
            }
        }

        public bool TaxExemptField { get; set; }
        public bool TaxExemptSet { get; set; }

        public bool TaxExempt
        {
            get { return TaxExemptField; }
            set
            {
                TaxExemptField = value;
                TaxExemptSet = true;
            }
        }

        private long _discountAmountField;
        private bool _discountAmountSet;

        public long DiscountAmount
        {
            get { return _discountAmountField; }
            set
            {
                _discountAmountField = value;
                _discountAmountSet = true;
            }
        }

        private long _shippingAmountField;
        private bool _shippingAmountSet;

        public long ShippingAmount
        {
            get { return _shippingAmountField; }
            set
            {
                _shippingAmountField = value;
                _shippingAmountSet = true;
            }
        }

        private long _dutyAmountField;
        private bool _dutyAmountSet;

        public long DutyAmount
        {
            get { return _dutyAmountField; }
            set
            {
                _dutyAmountField = value;
                _dutyAmountSet = true;
            }
        }

        public string ShipFromPostalCode { get; set; }
        public string DestinationPostalCode { get; set; }
        private CountryTypeEnum _destinationCountryCodeField;
        private bool _destinationCountryCodeSet;

        public CountryTypeEnum DestinationCountry
        {
            get { return _destinationCountryCodeField; }
            set
            {
                _destinationCountryCodeField = value;
                _destinationCountryCodeSet = true;
            }
        }

        public string InvoiceReferenceNumber { get; set; }
        private DateTime _orderDateField;
        private bool _orderDateSet;

        public DateTime OrderDate
        {
            get { return _orderDateField; }
            set
            {
                _orderDateField = value;
                _orderDateSet = true;
            }
        }

        public List<DetailTax> DetailTaxes { get; set; }
        public List<LineItemData> LineItems { get; set; }

        public EnhancedData()
        {
            LineItems = new List<LineItemData>();
            DetailTaxes = new List<DetailTax>();
        }

        public string Serialize()
        {
            var xml = "";
            if (CustomerReference != null)
                xml += "\r\n<customerReference>" + SecurityElement.Escape(CustomerReference) + "</customerReference>";
            if (_salesTaxSet) xml += "\r\n<salesTax>" + _salesTaxField + "</salesTax>";
            if (_deliveryTypeSet) xml += "\r\n<deliveryType>" + _deliveryTypeField + "</deliveryType>";
            if (TaxExemptSet) xml += "\r\n<taxExempt>" + TaxExemptField.ToString().ToLower() + "</taxExempt>";
            if (_discountAmountSet) xml += "\r\n<discountAmount>" + _discountAmountField + "</discountAmount>";
            if (_shippingAmountSet) xml += "\r\n<shippingAmount>" + _shippingAmountField + "</shippingAmount>";
            if (_dutyAmountSet) xml += "\r\n<dutyAmount>" + _dutyAmountField + "</dutyAmount>";
            if (ShipFromPostalCode != null)
                xml += "\r\n<shipFromPostalCode>" + SecurityElement.Escape(ShipFromPostalCode) + "</shipFromPostalCode>";
            if (DestinationPostalCode != null)
                xml += "\r\n<destinationPostalCode>" + SecurityElement.Escape(DestinationPostalCode) +
                       "</destinationPostalCode>";
            if (_destinationCountryCodeSet)
                xml += "\r\n<destinationCountryCode>" + _destinationCountryCodeField + "</destinationCountryCode>";
            if (InvoiceReferenceNumber != null)
                xml += "\r\n<invoiceReferenceNumber>" + SecurityElement.Escape(InvoiceReferenceNumber) +
                       "</invoiceReferenceNumber>";
            if (_orderDateSet) xml += "\r\n<orderDate>" + XmlUtil.ToXsdDate(_orderDateField) + "</orderDate>";
            foreach (var detailTax in DetailTaxes)
            {
                xml += "\r\n<detailTax>" + detailTax.Serialize() + "\r\n</detailTax>";
            }
            foreach (var lineItem in LineItems)
            {
                xml += "\r\n<lineItemData>" + lineItem.Serialize() + "\r\n</lineItemData>";
            }
            return xml;
        }
    }
}
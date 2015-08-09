using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class UpdateDiscount
    {
        public string DiscountCode;

        private string _nameField;
        private bool _nameSet;

        public string Name
        {
            get { return _nameField; }
            set
            {
                _nameField = value;
                _nameSet = true;
            }
        }

        private long _amountField;
        private bool _amountSet;

        public long Amount
        {
            get { return _amountField; }
            set
            {
                _amountField = value;
                _amountSet = true;
            }
        }

        private DateTime _startDateField;
        private bool _startDateSet;

        public DateTime StartDate
        {
            get { return _startDateField; }
            set
            {
                _startDateField = value;
                _startDateSet = true;
            }
        }

        private DateTime _endDateField;
        private bool _endDateSet;

        public DateTime EndDate
        {
            get { return _endDateField; }
            set
            {
                _endDateField = value;
                _endDateSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<discountCode>" + SecurityElement.Escape(DiscountCode) + "</discountCode>";
            if (_nameSet) xml += "\r\n<name>" + SecurityElement.Escape(_nameField) + "</name>";
            if (_amountSet) xml += "\r\n<amount>" + _amountField + "</amount>";
            if (_startDateSet) xml += "\r\n<startDate>" + XmlUtil.ToXsdDate(_startDateField) + "</startDate>";
            if (_endDateSet) xml += "\r\n<endDate>" + XmlUtil.ToXsdDate(_endDateField) + "</endDate>";
            return xml;
        }
    }
}
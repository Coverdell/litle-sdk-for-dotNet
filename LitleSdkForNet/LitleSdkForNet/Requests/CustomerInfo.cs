using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class CustomerInfo
    {
        public string Ssn { get; set; }

        public DateTime Dob { get; set; }

        public DateTime CustomerRegistrationDate { get; set; }

        private CustomerInfoCustomerType _customerTypeField;
        private bool _customerTypeSet;

        public CustomerInfoCustomerType CustomerType
        {
            get { return _customerTypeField; }
            set
            {
                _customerTypeField = value;
                _customerTypeSet = true;
            }
        }

        private long _incomeAmountField;
        private bool _incomeAmountSet;

        public long IncomeAmount
        {
            get { return _incomeAmountField; }
            set
            {
                _incomeAmountField = value;
                _incomeAmountSet = true;
            }
        }

        private CurrencyCodeEnum _incomeCurrencyField;
        private bool _incomeCurrencySet;

        public CurrencyCodeEnum IncomeCurrency
        {
            get { return _incomeCurrencyField; }
            set
            {
                _incomeCurrencyField = value;
                _incomeCurrencySet = true;
            }
        }

        private bool _customerCheckingAccountField;
        private bool _customerCheckingAccountSet;

        public bool CustomerCheckingAccount
        {
            get { return _customerCheckingAccountField; }
            set
            {
                _customerCheckingAccountField = value;
                _customerCheckingAccountSet = true;
            }
        }

        private bool _customerSavingAccountField;
        private bool _customerSavingAccountSet;

        public bool CustomerSavingAccount
        {
            get { return _customerSavingAccountField; }
            set
            {
                _customerSavingAccountField = value;
                _customerSavingAccountSet = true;
            }
        }

        public string EmployerName { get; set; }

        public string CustomerWorkTelephone { get; set; }

        private CustomerInfoResidenceStatus _residenceStatusField;
        private bool _residenceStatusSet;

        public CustomerInfoResidenceStatus ResidenceStatus
        {
            get { return _residenceStatusField; }
            set
            {
                _residenceStatusField = value;
                _residenceStatusSet = true;
            }
        }

        private int _yearsAtResidenceField;
        private bool _yearsAtResidenceSet;

        public int YearsAtResidence
        {
            get { return _yearsAtResidenceField; }
            set
            {
                _yearsAtResidenceField = value;
                _yearsAtResidenceSet = true;
            }
        }

        private int _yearsAtEmployerField;
        private bool _yearsAtEmployerSet;

        public int YearsAtEmployer
        {
            get { return _yearsAtEmployerField; }
            set
            {
                _yearsAtEmployerField = value;
                _yearsAtEmployerSet = true;
            }
        }

        public CustomerInfo()
        {
            IncomeCurrency = CurrencyCodeEnum.USD;
        }

        public string Serialize()
        {
            var xml = "";
            if (Ssn != null)
            {
                xml += "\r\n<ssn>" + SecurityElement.Escape(Ssn) + "</ssn>";
            }
            xml += "\r\n<dob>" + XmlUtil.ToXsdDate(Dob) + "</dob>";
            xml += "\r\n<customerRegistrationDate>" + XmlUtil.ToXsdDate(CustomerRegistrationDate) +
                   "</customerRegistrationDate>";
            if (_customerTypeSet)
            {
                xml += "\r\n<customerType>" + _customerTypeField + "</customerType>";
            }
            if (_incomeAmountSet)
            {
                xml += "\r\n<incomeAmount>" + _incomeAmountField + "</incomeAmount>";
            }
            if (_incomeCurrencySet)
            {
                xml += "\r\n<incomeCurrency>" + _incomeCurrencyField + "</incomeCurrency>";
            }
            if (_customerCheckingAccountSet)
            {
                xml += "\r\n<customerCheckingAccount>" + _customerCheckingAccountField.ToString().ToLower() +
                       "</customerCheckingAccount>";
            }
            if (_customerSavingAccountSet)
            {
                xml += "\r\n<customerSavingAccount>" + _customerSavingAccountField.ToString().ToLower() +
                       "</customerSavingAccount>";
            }
            if (EmployerName != null)
            {
                xml += "\r\n<employerName>" + SecurityElement.Escape(EmployerName) + "</employerName>";
            }
            if (CustomerWorkTelephone != null)
            {
                xml += "\r\n<customerWorkTelephone>" + SecurityElement.Escape(CustomerWorkTelephone) +
                       "</customerWorkTelephone>";
            }
            if (_residenceStatusSet)
            {
                xml += "\r\n<residenceStatus>" + _residenceStatusField + "</residenceStatus>";
            }
            if (_yearsAtResidenceSet)
            {
                xml += "\r\n<yearsAtResidence>" + _yearsAtResidenceField + "</yearsAtResidence>";
            }
            if (_yearsAtEmployerSet)
            {
                xml += "\r\n<yearsAtEmployer>" + _yearsAtEmployerField + "</yearsAtEmployer>";
            }
            return xml;
        }
    }
}
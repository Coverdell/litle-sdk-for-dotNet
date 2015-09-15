using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("customerInfo")]
    public class CustomerInfo
    {
        [XmlElement("ssn")]
        public string Ssn { get; set; }
        [XmlElement("dob", DataType = "date")]
        public DateTime Dob { get; set; }
        [XmlElement("customerRegistrationDate", DataType = "date")]
        public DateTime CustomerRegistrationDate { get; set; }
        [XmlElement("customerType", IsNullable = true)]
        public CustomerInfoCustomerType? CustomerType { get; set; }
        [XmlElement("incomeAmount", IsNullable = true)]
        public long? IncomeAmount { get; set; }
        [XmlElement("incomeCurrency", IsNullable = true)]
        public CurrencyCodeEnum? IncomeCurrency { get; set; }
        [XmlElement("customerCheckingAccount", IsNullable = true)]
        public bool? CustomerCheckingAccount { get; set; }
        [XmlElement("customerSavingAccount", IsNullable = true)]
        public bool? CustomerSavingAccount { get; set; }
        [XmlElement("employerName")]
        public string EmployerName { get; set; }
        [XmlElement("customerWorkTelephone")]
        public string CustomerWorkTelephone { get; set; }
        [XmlElement("residenceStatus", IsNullable = true)]
        public CustomerInfoResidenceStatus? ResidenceStatus { get; set; }
        [XmlElement("yearsAtResidence", IsNullable = true)]
        public int? YearsAtResidence { get; set; }
        [XmlElement("yearsAtEmployer", IsNullable = true)]
        public int? YearsAtEmployer { get; set; }

        public CustomerInfo()
        {
            IncomeCurrency = CurrencyCodeEnum.USD;
        }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
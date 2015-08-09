using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EnhancedAuthResponse
    {
        private EnhancedAuthResponseFundingSource _fundingSourceField;
        private AffluenceTypeEnum? _affluenceField;
        private bool _affluenceFieldSpecified;
        private string _issuerCountryField;
        private CardProductTypeEnum? _cardProductTypeField;
        private bool _cardProductTypeFieldSpecified;
        private bool _virtualAccountNumberField;
        private bool _virtualAccountNumberFieldSpecified;

        public EnhancedAuthResponseFundingSource FundingSource
        {
            get { return _fundingSourceField; }
            set { _fundingSourceField = value; }
        }

        public AffluenceTypeEnum? Affluence
        {
            get { return _affluenceFieldSpecified ? _affluenceField : null; }
            set { _affluenceField = value; }
        }

        [XmlIgnore]
        public bool AffluenceSpecified
        {
            get { return _affluenceFieldSpecified; }
            set { _affluenceFieldSpecified = value; }
        }

        public string IssuerCountry
        {
            get { return _issuerCountryField; }
            set { _issuerCountryField = value; }
        }

        public CardProductTypeEnum? CardProductType
        {
            get { return _cardProductTypeFieldSpecified ? _cardProductTypeField : null; }
            set { _cardProductTypeField = value; }
        }

        [XmlIgnore]
        public bool CardProductTypeSpecified
        {
            get { return _cardProductTypeFieldSpecified; }
            set { _cardProductTypeFieldSpecified = value; }
        }

        public bool VirtualAccountNumber
        {
            get { return _virtualAccountNumberField; }
            set { _virtualAccountNumberField = value; }
        }

        [XmlIgnore]
        public bool VirtualAccountNumberSpecified
        {
            get { return _virtualAccountNumberFieldSpecified; }
            set { _virtualAccountNumberFieldSpecified = value; }
        }
    }
}
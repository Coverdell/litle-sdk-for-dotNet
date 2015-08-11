using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("enhancedAuthResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("enhancedAuthResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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

        [XmlElement("fundingSource")]
        public EnhancedAuthResponseFundingSource FundingSource
        {
            get { return _fundingSourceField; }
            set { _fundingSourceField = value; }
        }

        [XmlElement("affluence")]
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

        [XmlElement("issuerCountry")]
        public string IssuerCountry
        {
            get { return _issuerCountryField; }
            set { _issuerCountryField = value; }
        }

        [XmlElement("cardProductType")]
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

        [XmlElement("virtualAccountNumber")]
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
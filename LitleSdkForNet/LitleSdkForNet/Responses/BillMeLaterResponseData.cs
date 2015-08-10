using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("billMeLaterResponseData", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("billMeLaterResponseData", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BillMeLaterResponseData
    {
        private long _bmlMerchantIdField;
        private string _promotionalOfferCodeField;
        private int _approvedTermsCodeField;
        private bool _approvedTermsCodeFieldSpecified;
        private string _creditLineField;
        private string _addressIndicatorField;
        private string _loanToValueEstimatorField;
        private string _riskEstimatorField;
        private string _riskQueueAssignmentField;

        [XmlElement("bmlMerchantId")]
        public long BmlMerchantId
        {
            get { return _bmlMerchantIdField; }
            set { _bmlMerchantIdField = value; }
        }

        [XmlElement("promotionalOfferCode")]
        public string PromotionalOfferCode
        {
            get { return _promotionalOfferCodeField; }
            set { _promotionalOfferCodeField = value; }
        }

        [XmlElement("approvedTermsCode")]
        public int ApprovedTermsCode
        {
            get { return _approvedTermsCodeField; }
            set { _approvedTermsCodeField = value; }
        }

        [XmlIgnore]
        public bool ApprovedTermsCodeSpecified
        {
            get { return _approvedTermsCodeFieldSpecified; }
            set { _approvedTermsCodeFieldSpecified = value; }
        }

        [XmlElement("creditLine", DataType = "integer")]
        public string CreditLine
        {
            get { return _creditLineField; }
            set { _creditLineField = value; }
        }

        [XmlElement("addressIndicator")]
        public string AddressIndicator
        {
            get { return _addressIndicatorField; }
            set { _addressIndicatorField = value; }
        }

        [XmlElement("loanToValueEstimator")]
        public string LoanToValueEstimator
        {
            get { return _loanToValueEstimatorField; }
            set { _loanToValueEstimatorField = value; }
        }

        [XmlElement("riskEstimator")]
        public string RiskEstimator
        {
            get { return _riskEstimatorField; }
            set { _riskEstimatorField = value; }
        }

        [XmlElement("riskQueueAssignment")]
        public string RiskQueueAssignment
        {
            get { return _riskQueueAssignmentField; }
            set { _riskQueueAssignmentField = value; }
        }
    }
}
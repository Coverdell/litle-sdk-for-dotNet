using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("billMeLaterResponseData", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("billMeLaterResponseData", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BillMeLaterResponseData
    {
        [XmlElement("bmlMerchantId")]
        public long BmlMerchantId { get; set; }

        [XmlElement("promotionalOfferCode")]
        public string PromotionalOfferCode { get; set; }

        [XmlElement("approvedTermsCode")]
        public int ApprovedTermsCode { get; set; }

        [XmlIgnore]
        public bool ApprovedTermsCodeSpecified { get; set; }

        [XmlElement("creditLine", DataType = "integer")]
        public string CreditLine { get; set; }

        [XmlElement("addressIndicator")]
        public string AddressIndicator { get; set; }

        [XmlElement("loanToValueEstimator")]
        public string LoanToValueEstimator { get; set; }

        [XmlElement("riskEstimator")]
        public string RiskEstimator { get; set; }

        [XmlElement("riskQueueAssignment")]
        public string RiskQueueAssignment { get; set; }
    }
}
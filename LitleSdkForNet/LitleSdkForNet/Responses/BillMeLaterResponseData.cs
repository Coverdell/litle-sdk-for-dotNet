using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("billMeLaterResponseData")]
    [LitleXmlRoot("billMeLaterResponseData")]
    public class BillMeLaterResponseData
    {
        [XmlElement("bmlMerchantId")]
        public long BmlMerchantId { get; set; }

        [XmlElement("promotionalOfferCode")]
        public string PromotionalOfferCode { get; set; }

        [XmlElement("approvedTermsCode", IsNullable = true)]
        public int? ApprovedTermsCode { get; set; }

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
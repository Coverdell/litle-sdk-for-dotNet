using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("fraudCheck")]
    public class FraudCheck : TransactionTypeWithReportGroup
    {
        [XmlElement("advancedFraudChecks")]
        public AdvancedFraudChecksType AdvancedFraudChecks { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("shipToAddress")]
        public Contact ShipToAddress { get; set; }
        [XmlElement("amount")]
        public int? Amount { get; set; }
    }
}
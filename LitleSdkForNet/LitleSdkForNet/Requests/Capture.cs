using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("capture")]
    public class Capture : TransactionTypeWithReportGroupAndPartial
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }
        [XmlElement("amount", IsNullable = true)]
        public long? Amount { get; set; }
        [XmlElement("surchargeAmount", IsNullable = true)]
        public long? SurchargeAmount { get; set; }
        [XmlElement("enhancedData")]
        public EnhancedData EnhancedData { get; set; }
        [XmlElement("processingInstructions")]
        public ProcessingInstructions ProcessingInstructions { get; set; }
        [XmlElement("payPalOrderComplete", IsNullable = true)]
        public bool? PayPalOrderComplete { get; set; }
        [XmlElement("payPalNotes")]
        public string PayPalNotes { get; set; }
    }
}
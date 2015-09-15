using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("authReversal")]
    public class AuthReversal : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }
        [XmlElement("amount", IsNullable = true)]
        public long? Amount { get; set; }
        [XmlElement("surchargeAmount", IsNullable = true)]
        public long? SurchargeAmount { get; set; }
        [XmlElement("payPalNotes")]
        public string PayPalNotes { get; set; }
        [XmlElement("actionReason")]
        public string ActionReason { get; set; }
    }
}
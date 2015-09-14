using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("payFacDebit")]
    public class PayFacDebit : TransactionTypeWithReportGroup
    {
        [XmlElement("fundingSubmerchantId")]
        public string FundingSubmerchantId { get; set; }
        [XmlElement("fundsTransferId")]
        public string FundsTransferId { get; set; }
        [XmlElement("amount")]
        public long? Amount { get; set; }
    }
}
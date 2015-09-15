using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("submerchantDebit")]
    public class SubmerchantDebit : TransactionTypeWithReportGroup
    {
        [XmlElement("fundingSubmerchantId")]
        public string FundingSubmerchantId { get; set; }
        [XmlElement("submerchantName")]
        public string SubmerchantName { get; set; }
        [XmlElement("fundsTransferId")]
        public string FundsTransferId { get; set; }
        [XmlElement("amount")]
        public long? Amount { get; set; }
        [XmlElement("accountInfo")]
        public EcheckType AccountInfo { get; set; }
    }
}
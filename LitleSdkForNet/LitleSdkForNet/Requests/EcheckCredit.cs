using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckCredit")]
    public class EcheckCredit : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long? LitleTxnId { get; set; }
        [XmlElement("amount")]
        public long? Amount { get; set; }
        [XmlElement("secondaryAmount")]
        public long? SecondaryAmount { get; set; }
        [XmlElement("customBilling")]
        public CustomBilling CustomBilling { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("echeck")]
        public EcheckType Echeck { get; set; }
        [XmlElement("echeckToken")]
        public EcheckTokenType EcheckToken { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
    }
}
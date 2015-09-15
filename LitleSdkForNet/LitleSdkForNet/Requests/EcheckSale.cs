using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckSale")]
    public class EcheckSale : TransactionTypeWithReportGroup
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
        [XmlElement("verify")]
        public bool? Verify { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("shipToAddress")]
        public Contact ShipToAddress { get; set; }
        [XmlElement("echeck")]
        public EcheckType Echeck { get; set; }
        [XmlElement("token")]
        public EcheckTokenType Token { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckVerification")]
    public class EcheckVerification : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long? LitleTxnId { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("amount")]
        public long? Amount { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("echeck")]
        public EcheckType Echeck { get; set; }
        [XmlElement("token")]
        public EcheckTokenType Token { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
    }
}
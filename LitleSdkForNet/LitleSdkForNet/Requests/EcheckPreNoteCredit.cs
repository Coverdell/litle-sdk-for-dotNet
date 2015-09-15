using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckPreNoteCredit")]
    public class EcheckPreNoteCredit : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("echeck")]
        public EcheckType Echeck { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
    }
}
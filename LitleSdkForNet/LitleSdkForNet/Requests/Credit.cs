using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("credit")]
    public class Credit : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId", IsNullable = true)]
        public long? LitleTxnId { get; set; }
        [XmlElement("amount", IsNullable = true)]
        public long? Amount { get; set; }
        [XmlElement("secondaryAmount", IsNullable = true)]
        public long? SecondaryAmount { get; set; }
        [XmlElement("surchargeAmount", IsNullable = true)]
        public long? SurchargeAmount { get; set; }
        [XmlElement("customBilling")]
        public CustomBilling CustomBilling { get; set; }
        [XmlElement("enhancedData")]
        public EnhancedData EnhancedData { get; set; }
        [XmlElement("processingInstructions")]
        public ProcessingInstructions ProcessingInstructions { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("orderSource", IsNullable = true)]
        public OrderSourceType? OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
        [XmlElement("mpos")]
        public MposType Mpos { get; set; }
        [XmlElement("token")]
        public CardTokenType Token { get; set; }
        [XmlElement("paypage")]
        public CardPaypageType Paypage { get; set; }
        [XmlElement("paypal")]
        public PayPal Paypal { get; set; }
        [XmlElement("taxType", IsNullable = true)]
        public TaxTypeIdentifierEnum? TaxType { get; set; }
        [XmlElement("billMeLaterRequest")]
        public BillMeLaterRequest BillMeLaterRequest { get; set; }
        [XmlElement("pos")]
        public Pos Pos { get; set; }
        [XmlElement("amexAggregatorData")]
        public AmexAggregatorData AmexAggregatorData { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
        [XmlElement("payPalNotes")]
        public string PayPalNotes { get; set; }
        [XmlElement("actionReason")]
        public string ActionReason { get; set; }
    }
}
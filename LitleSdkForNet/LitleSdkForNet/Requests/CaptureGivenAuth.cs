using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("captureGivenAuth")]
    public class CaptureGivenAuth : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("authInformation")]
        public AuthInformation AuthInformation { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("secondaryAmount", IsNullable = true)]
        public long? SecondaryAmount { get; set; }
        [XmlElement("surchargeAmount", IsNullable = true)]
        public long? SurchargeAmount { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("shipToAddress")]
        public Contact ShipToAddress { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
        [XmlElement("mpos")]
        public MposType Mpos { get; set; }
        [XmlElement("token")]
        public CardTokenType Token { get; set; }
        [XmlElement("paypage")]
        public CardPaypageType Paypage { get; set; }
        [XmlElement("customBilling")]
        public CustomBilling CustomBilling { get; set; }
        [XmlElement("taxType", IsNullable = true)]
        public GovtTaxTypeEnum? TaxType { get; set; }
        [XmlElement("billMeLaterRequest")]
        public BillMeLaterRequest BillMeLaterRequest { get; set; }
        [XmlElement("enhancedData")]
        public EnhancedData EnhancedData { get; set; }
        [XmlElement("processingInstructions")]
        public ProcessingInstructions ProcessingInstructions { get; set; }
        [XmlElement("pos")]
        public Pos Pos { get; set; }
        [XmlElement("amexAggregatorData")]
        public AmexAggregatorData AmexAggregatorData { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
        [XmlElement("debtRepayment", IsNullable = true)]
        public bool? DebtRepayment { get; set; }
    }
}
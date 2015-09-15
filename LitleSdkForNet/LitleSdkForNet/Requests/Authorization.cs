using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("authorization")]
    public class Authorization : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId", IsNullable = true)]
        public long? LitleTxnId { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("secondaryAmount", IsNullable = true)]
        public long? SecondaryAmount { get; set; }
        [XmlElement("surchargeAmount", IsNullable = true)]
        public long? SurchargeAmount { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
        [XmlElement("customerInfo")]
        public CustomerInfo CustomerInfo { get; set; }
        [XmlElement("billToAddress")]
        public Contact BillToAddress { get; set; }
        [XmlElement("shipToAddress")]
        public Contact ShipToAddress { get; set; }
        [XmlElement("card")]
        public CardType Card { get; set; }
        [XmlElement("mpos")]
        public MposType Mpos { get; set; }
        [XmlElement("paypal")]
        public PayPal Paypal { get; set; }
        [XmlElement("token")]
        public CardTokenType Token { get; set; }
        [XmlElement("paypage")]
        public CardPaypageType Paypage { get; set; }
        [XmlElement("applepay")]
        public ApplepayType Applepay { get; set; }
        [XmlElement("billMeLaterRequest")]
        public BillMeLaterRequest BillMeLaterRequest { get; set; }
        [XmlElement("cardholderAuthentication")]
        public FraudCheckType CardholderAuthentication { get; set; }
        [XmlElement("processingInstructions")]
        public ProcessingInstructions ProcessingInstructions { get; set; }
        [XmlElement("pos")]
        public Pos Pos { get; set; }
        [XmlElement("customBilling")]
        public CustomBilling CustomBilling { get; set; }
        [XmlElement("taxType", IsNullable = true)]
        public GovtTaxTypeEnum? TaxType { get; set; }
        [XmlElement("enchancedData")]
        public EnhancedData EnhancedData { get; set; }
        [XmlElement("amexAggregatorData")]
        public AmexAggregatorData AmexAggregatorData { get; set; }
        [XmlElement("allowPartialAuth", IsNullable = true)]
        public bool? AllowPartialAuth { get; set; }
        [XmlElement("healthcareIIAS")]
        public HealthcareIIAS HealthcareIIAS { get; set; }
        [XmlElement("filtering")]
        public FilteringType Filtering { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
        [XmlElement("recyclingRequest")]
        public RecyclingRequestType RecyclingRequest { get; set; }
        [XmlElement("fraudFilterOverride", IsNullable = true)]
        public bool? FraudFilterOverride { get; set; }
        [XmlElement("recurringRequest")]
        public RecurringRequest RecurringRequest { get; set; }
        [XmlElement("debtRepayment", IsNullable = true)]
        public bool? DebtRepayment { get; set; }
        [XmlElement("advancedFraudChecks")]
        public AdvancedFraudChecksType AdvancedFraudChecks { get; set; }
        [XmlElement("wallet")]
        public Wallet Wallet { get; set; }
    }
}
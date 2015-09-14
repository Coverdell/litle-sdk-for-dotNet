using System;
using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("forceCapture")]
    public class ForceCapture : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("secondaryAmount")]
        public long? SecondaryAmount { get; set; }
        [XmlElement("surchargeAmount")]
        public long? SurchargeAmount { get; set; }
        [XmlElement("orderSource")]
        public OrderSourceType OrderSource { get; set; }
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
        [XmlElement("customBilling")]
        public CustomBilling CustomBilling { get; set; }
        [XmlElement("taxType")]
        public GovtTaxTypeEnum? TaxType { get; set; }
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
        [XmlElement("debtRepayment")]
        public bool? DebtRepayment { get; set; }
    }
}
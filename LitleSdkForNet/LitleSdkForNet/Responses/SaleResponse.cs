using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("saleResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("saleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SaleResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("cardProductId")]
        public string CardProductId { get; set; }

        [XmlElement("postDate", DataType = "date", IsNullable = true)]
        public DateTime? PostDate { get; set; }
        
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("authCode")]
        public string AuthCode { get; set; }

        [XmlElement("authorizationResponseSubCode")]
        public string AuthorizationResponseSubCode { get; set; }

        [XmlElement("approvedAmount", DataType = "integer")]
        public string ApprovedAmount { get; set; }

        [XmlElement("accountInformation")]
        public AccountInfoType AccountInformation { get; set; }

        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }

        [XmlElement("billMeLaterResponseData")]
        public BillMeLaterResponseData BillMeLaterResponseData { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlElement("enhancedAuthResponse")]
        public EnhancedAuthResponse EnhancedAuthResponse { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("recycling")]
        public RecyclingType Recycling { get; set; }

        [XmlElement("recurringResponse")]
        public RecurringResponse RecurringResponse { get; set; }

        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse { get; set; }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse { get; set; }

        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
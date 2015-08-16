using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("authorizationResponse")]
    [LitleXmlRoot("authorizationResponse")]
    public class AuthorizationResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlElement("cardProductId")]
        public string CardProductId { get; set; }

        [XmlElement("authCode")]
        public string AuthCode { get; set; }

        [XmlElement("authorizationResponseSubCode")]
        public string AuthorizationResponseSubCode { get; set; }

        [XmlElement("approvedAmount", DataType = "integer")]
        public string ApprovedAmount { get; set; }

        [XmlElement("accountInformation")]
        public AccountInfoType AccountInformation { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }

        [XmlElement("billMeLaterResponseData")]
        public BillMeLaterResponseData BillMeLaterResponseData { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlElement("enhancedAuthResponse")]
        public EnhancedAuthResponse EnhancedAuthResponse { get; set; }

        [XmlElement("recycling")]
        public RecyclingType Recycling { get; set; }

        [XmlElement("recurringResponse")]
        public RecurringResponse RecurringResponse { get; set; }

        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse { get; set; }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse { get; set; }
    }
}
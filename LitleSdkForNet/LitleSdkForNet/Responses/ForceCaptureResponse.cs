using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("forceCaptureResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("forceCaptureResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ForceCaptureResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse { get; set; }
        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }

        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("orderId")]
        public string OrderId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate { get; set; }

        [XmlIgnore]
        public bool PostDateSpecified { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
using System;
using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk
{
    public abstract class CommonTransactionTypeWithReportGroupAndOrder : CommonTransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
    }
    public abstract class CommonTransactionTypeWithReportGroupAndOrderAndPostDate : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlElement("postDate", DataType = "date", IsNullable = true)]
        public DateTime? PostDate { get; set; }
    }

    public abstract class CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDate
    {
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse { get; set; }
    }

    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public abstract class CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse
    {
        [XmlElement("fraudResult")]
        public FraudResult FraudResult { get; set; }
    }

    public abstract class CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }

    }
}
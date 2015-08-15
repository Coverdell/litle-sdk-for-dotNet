using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("refundReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("refundReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RefundReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
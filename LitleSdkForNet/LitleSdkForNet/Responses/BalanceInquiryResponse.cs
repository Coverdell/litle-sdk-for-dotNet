using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("balanceInquiryResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("balanceInquiryResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BalanceInquiryResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
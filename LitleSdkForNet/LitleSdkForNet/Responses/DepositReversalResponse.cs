using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("depositReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("depositReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DepositReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
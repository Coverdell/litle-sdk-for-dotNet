using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("deactivateReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("deactivateReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DeactivateReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
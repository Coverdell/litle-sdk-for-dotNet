using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("activateReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("activateReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
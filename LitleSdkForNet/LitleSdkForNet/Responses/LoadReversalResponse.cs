using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("loadReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("loadReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LoadReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
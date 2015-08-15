using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("unloadReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("unloadReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UnloadReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
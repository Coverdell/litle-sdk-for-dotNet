using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("unloadResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("unloadResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UnloadResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
    }
}
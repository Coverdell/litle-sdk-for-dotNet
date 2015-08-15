using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("loadResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("loadResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LoadResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
    }
}
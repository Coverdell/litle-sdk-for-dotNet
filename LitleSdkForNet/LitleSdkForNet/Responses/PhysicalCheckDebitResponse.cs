using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("physicalCheckDebitResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("physicalCheckDebitResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PhysicalCheckDebitResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
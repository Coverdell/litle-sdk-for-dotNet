using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("reserveDebitResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("reserveDebitResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ReserveDebitResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
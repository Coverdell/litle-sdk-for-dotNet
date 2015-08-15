using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("reserveCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("reserveCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ReserveCreditResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
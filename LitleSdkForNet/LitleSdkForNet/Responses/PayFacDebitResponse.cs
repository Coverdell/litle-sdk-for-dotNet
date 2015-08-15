using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("payFacDebitResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("payFacDebitResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PayFacDebitResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
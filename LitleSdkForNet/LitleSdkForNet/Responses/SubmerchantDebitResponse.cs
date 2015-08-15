using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("submerchantDebitResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("submerchantDebitResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SubmerchantDebitResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
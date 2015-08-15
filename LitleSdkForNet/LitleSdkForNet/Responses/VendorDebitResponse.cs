using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("vendorDebitResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("vendorDebitResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class VendorDebitResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
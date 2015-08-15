using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("vendorCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("vendorCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class VendorCreditResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
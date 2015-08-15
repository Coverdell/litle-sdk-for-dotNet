using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("submerchantCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("submerchantCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class SubmerchantCreditResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
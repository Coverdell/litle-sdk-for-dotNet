using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("physicalCheckCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("physicalCheckCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PhysicalCheckCreditResponse : CommonTransactionTypeWithReportGroupAndFraud
    {
    }
}
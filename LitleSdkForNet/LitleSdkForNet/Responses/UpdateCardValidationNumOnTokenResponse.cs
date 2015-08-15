using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("updateCardValidationNumOnTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("updateCardValidationNumOnTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateCardValidationNumOnTokenResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("deactivateResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("deactivateResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class DeactivateResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponse
    {
    }
}
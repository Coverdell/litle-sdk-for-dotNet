using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("creditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("creditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CreditResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
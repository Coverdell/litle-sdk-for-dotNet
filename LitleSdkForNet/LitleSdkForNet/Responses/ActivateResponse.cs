using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("activateResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("activateResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("virtualGiftCardResponse")]
        public VirtualGiftCardResponseType VirtualGiftCardResponse { get; set; }
    }
}
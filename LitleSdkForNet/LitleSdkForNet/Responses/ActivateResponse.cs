using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("activateResponse")]
    [LitleXmlRoot("activateResponse")]
    public class ActivateResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("virtualGiftCardResponse")]
        public VirtualGiftCardResponseType VirtualGiftCardResponse { get; set; }
    }
}
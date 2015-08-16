using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("captureResponse")]
    public class CaptureResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
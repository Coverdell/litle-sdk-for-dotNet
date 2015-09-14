using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("captureResponse")]
    public class CaptureResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
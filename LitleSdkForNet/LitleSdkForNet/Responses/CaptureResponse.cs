using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType("captureResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("captureResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CaptureResponse : CommonTransactionTypeWithReportGroupAndOrderAndFraudAndPostDateAndGiftCardResponseAndDuplicate
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }
    }
}
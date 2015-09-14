using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("activateReversal")]
    [LitleXmlRoot("activateReversal")]
    public class ActivateReversal : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public string LitleTxnId { get; set; }
    }
}
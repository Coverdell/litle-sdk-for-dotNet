using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckVoid")]
    public class EcheckVoid : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }
    }
}
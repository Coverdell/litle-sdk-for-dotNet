using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("transactionTypeOptionReportGroup")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        [XmlAttribute("reportGroup")]
        public string ReportGroup { get; set; }
    }
}
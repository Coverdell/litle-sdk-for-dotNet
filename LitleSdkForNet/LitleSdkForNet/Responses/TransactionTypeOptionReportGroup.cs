using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("transactionTypeOptionReportGroup")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        [XmlAttribute("reportGroup")]
        public string ReportGroup { get; set; }
    }
}
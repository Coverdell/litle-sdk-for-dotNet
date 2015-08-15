using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("transactionTypeOptionReportGroup", Namespace = "http://www.litle.com/schema")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        [XmlAttribute("reportGroup")]
        public string ReportGroup { get; set; }
    }
}
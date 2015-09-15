using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class TransactionTypeWithReportGroupAndPartial : TransactionType
    {
        [XmlAttribute("reportGroup")]
        public string ReportGroup { get; set; }
        [XmlElement("partial")]
        public bool? Partial { get; set; }
    }
}
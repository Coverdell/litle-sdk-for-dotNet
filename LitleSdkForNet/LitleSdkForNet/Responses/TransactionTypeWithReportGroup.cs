using System.Xml.Serialization;
using Litle.Sdk.Requests;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [XmlInclude(typeof (RegisterTokenRequestType))]
    [LitleXmlType("transactionTypeWithReportGroup")]
    public class TransactionTypeWithReportGroup : TransactionType
    {
        [XmlAttribute("reportGroup")]
        public string ReportGroup { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("transactionTypeOptionReportGroup", Namespace = "http://www.litle.com/schema")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        private string _reportGroupField;

        [XmlAttribute("reportGroup")]
        public string ReportGroup
        {
            get { return _reportGroupField; }
            set { _reportGroupField = value; }
        }
    }
}
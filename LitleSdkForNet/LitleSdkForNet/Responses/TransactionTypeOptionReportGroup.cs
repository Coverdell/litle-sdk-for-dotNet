using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TransactionTypeOptionReportGroup : TransactionType
    {
        private string _reportGroupField;

        [XmlAttribute]
        public string ReportGroup
        {
            get { return _reportGroupField; }
            set { _reportGroupField = value; }
        }
    }
}
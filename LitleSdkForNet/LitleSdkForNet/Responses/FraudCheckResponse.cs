using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("fraudCheckResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("fraudCheckResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class FraudCheckResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;
        private AdvancedFraudResultsType _advancedFraudResultsField;

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        [XmlElement("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        [XmlElement("advancedFraudResults")]
        public AdvancedFraudResultsType AdvancedFraudResults
        {
            get { return _advancedFraudResultsField; }
            set { _advancedFraudResultsField = value; }
        }
    }
}
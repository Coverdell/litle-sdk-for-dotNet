using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckPreNoteSaleResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteSaleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckPreNoteSaleResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        [XmlElement("orderId")]
        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        [XmlElement("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute("duplicate")]
        public bool Duplicate
        {
            get { return _duplicateField; }
            set { _duplicateField = value; }
        }

        [XmlIgnore]
        public bool DuplicateSpecified
        {
            get { return _duplicateFieldSpecified; }
            set { _duplicateFieldSpecified = value; }
        }
    }
}
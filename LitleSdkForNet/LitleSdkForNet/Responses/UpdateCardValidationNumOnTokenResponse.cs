using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateCardValidationNumOnTokenResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }
}
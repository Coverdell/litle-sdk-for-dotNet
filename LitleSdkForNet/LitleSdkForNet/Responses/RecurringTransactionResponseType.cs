using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecurringTransactionResponseType : TransactionResponse
    {
        private string _litleTxnIdField;

        public string LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        private string _responseField;

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        private string _messageField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        private DateTime _responseTimeField;

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }
}
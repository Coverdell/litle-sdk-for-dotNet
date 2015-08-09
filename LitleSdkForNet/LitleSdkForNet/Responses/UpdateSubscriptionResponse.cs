using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateSubscriptionResponse
    {
        private string _subscriptionIdField;

        public string SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

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

        public TokenResponseType TokenResponse;
    }
}
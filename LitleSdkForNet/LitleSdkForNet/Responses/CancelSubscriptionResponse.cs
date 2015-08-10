using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cancelSubscriptionResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("cancelSubscriptionResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CancelSubscriptionResponse
    {
        private string _subscriptionIdField;

        [XmlElement("subscriptionId")]
        public string SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        private string _litleTxnIdField;

        [XmlElement("litleTxnId")]
        public string LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        private string _responseField;

        [XmlElement("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        private string _messageField;

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        private DateTime _responseTimeField;

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }
    }
}
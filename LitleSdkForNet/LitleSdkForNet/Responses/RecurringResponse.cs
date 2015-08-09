using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class RecurringResponse
    {
        private long _subscriptionIdField;
        private string _responseCodeField;
        private string _responseMessageField;
        private long _recurringTxnIdField;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        public string ResponseCode
        {
            get { return _responseCodeField; }
            set { _responseCodeField = value; }
        }

        public string ResponseMessage
        {
            get { return _responseMessageField; }
            set { _responseMessageField = value; }
        }

        public long RecurringTxnId
        {
            get { return _recurringTxnIdField; }
            set { _recurringTxnIdField = value; }
        }
    }
}
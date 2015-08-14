using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recurringResponse", Namespace = "http://www.litle.com/schema")]
    public class RecurringResponse
    {
        private long _subscriptionIdField;
        private string _responseCodeField;
        private string _responseMessageField;
        private long _recurringTxnIdField;

        [XmlElement("subscriptionId")]
        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set { _subscriptionIdField = value; }
        }

        [XmlElement("responseCode")]
        public string ResponseCode
        {
            get { return _responseCodeField; }
            set { _responseCodeField = value; }
        }

        [XmlElement("responseMessage")]
        public string ResponseMessage
        {
            get { return _responseMessageField; }
            set { _responseMessageField = value; }
        }

        [XmlElement("recurringTxnId")]
        public long RecurringTxnId
        {
            get { return _recurringTxnIdField; }
            set { _recurringTxnIdField = value; }
        }
    }
}
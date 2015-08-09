using System;

namespace Litle.Sdk.Requests
{
    public class CancelSubscription : recurringTransactionType
    {
        private long _subscriptionIdField;
        private bool _subscriptionIdSet;

        public long SubscriptionId
        {
            get { return _subscriptionIdField; }
            set
            {
                _subscriptionIdField = value;
                _subscriptionIdSet = true;
            }
        }

        public override String Serialize()
        {
            var xml = "\r\n<cancelSubscription>";
            if (_subscriptionIdSet) xml += "\r\n<subscriptionId>" + _subscriptionIdField + "</subscriptionId>";
            xml += "\r\n</cancelSubscription>";
            return xml;
        }
    }
}
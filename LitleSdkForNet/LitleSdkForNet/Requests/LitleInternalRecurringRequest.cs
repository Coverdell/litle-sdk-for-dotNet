using System.Security;

namespace Litle.Sdk.Requests
{
    public class LitleInternalRecurringRequest
    {
        public string SubscriptionId { get; set; }
        public string RecurringTxnId { get; set; }

        private bool _finalPaymentField;
        private bool _finalPaymentSet;

        public bool FinalPayment
        {
            get { return _finalPaymentField; }
            set
            {
                _finalPaymentField = value;
                _finalPaymentSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (SubscriptionId != null)
                xml += "\r\n<subscriptionId>" + SecurityElement.Escape(SubscriptionId) + "</subscriptionId>";
            if (RecurringTxnId != null)
                xml += "\r\n<recurringTxnId>" + SecurityElement.Escape(RecurringTxnId) + "</recurringTxnId>";
            if (_finalPaymentSet)
                xml += "\r\n<finalPayment>" + _finalPaymentField.ToString().ToLower() + "</finalPayment>";
            return xml;
        }
    }
}
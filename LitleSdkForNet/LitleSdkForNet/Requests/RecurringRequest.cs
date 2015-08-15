namespace Litle.Sdk.Requests
{
    public class RecurringRequest
    {
        public Subscription Subscription { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Subscription != null) xml += "\r\n<subscription>" + Subscription.Serialize() + "\r\n</subscription>";
            return xml;
        }
    }
}
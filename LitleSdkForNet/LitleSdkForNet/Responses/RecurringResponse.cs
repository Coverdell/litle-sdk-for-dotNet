using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recurringResponse", Namespace = "http://www.litle.com/schema")]
    public class RecurringResponse
    {
        [XmlElement("subscriptionId")]
        public long SubscriptionId { get; set; }

        [XmlElement("responseCode")]
        public string ResponseCode { get; set; }

        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }

        [XmlElement("recurringTxnId")]
        public long RecurringTxnId { get; set; }
    }
}
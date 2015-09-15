using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("cancelSubscription")]
    public class CancelSubscription : RecurringTransactionType
    {
        [XmlElement("subscriptionId")]
        public long? SubscriptionId { get; set; }
    }
}
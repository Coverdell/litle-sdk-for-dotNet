using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cancelSubscriptionResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("cancelSubscriptionResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CancelSubscriptionResponse
    {
        [XmlElement("subscriptionId")]
        public string SubscriptionId { get; set; }

        [XmlElement("litleTxnId")]
        public string LitleTxnId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
    }
}
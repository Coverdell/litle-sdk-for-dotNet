using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("cancelSubscriptionResponse")]
    [LitleXmlRoot("cancelSubscriptionResponse")]
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
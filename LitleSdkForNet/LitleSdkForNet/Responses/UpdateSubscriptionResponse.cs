using System;
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("updateSubscriptionResponse")]
    public class UpdateSubscriptionResponse
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

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
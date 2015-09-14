using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("recurringResponse")]
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
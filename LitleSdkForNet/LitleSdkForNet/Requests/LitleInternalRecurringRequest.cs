using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("litleInternalRecurringRequest")]
    public class LitleInternalRecurringRequest
    {
        [XmlElement("subsciptionId")]
        public string SubscriptionId { get; set; }
        [XmlElement("recurringTxnId")]
        public string RecurringTxnId { get; set; }
        [XmlElement("finalPayment")]
        public bool? FinalPayment { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
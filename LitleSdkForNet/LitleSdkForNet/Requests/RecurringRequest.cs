using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("recurringRequest")]
    public class RecurringRequest
    {
        [XmlElement("subscription")]
        public Subscription Subscription { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
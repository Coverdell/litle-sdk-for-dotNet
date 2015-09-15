using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("applepayHeaderType")]
    public class ApplepayHeaderType
    {
        [XmlElement("applicationData")]
        public string ApplicationData { get; set; }
        [XmlElement("ephemeralPublicKey")]
        public string EphemeralPublicKey { get; set; }
        [XmlElement("publicKeyHash")]
        public string PublicKeyHash { get; set; }
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
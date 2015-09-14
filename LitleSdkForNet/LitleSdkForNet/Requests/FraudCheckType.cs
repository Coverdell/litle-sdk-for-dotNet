using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("fraudCheckType")]
    public class FraudCheckType
    {
        [XmlElement("authenticationValue")]
        public string AuthenticationValue { get; set; }
        [XmlElement("authenticationTransactionId")]
        public string AuthenticationTransactionId { get; set; }
        [XmlElement("customerIpAddress")]
        public string CustomerIpAddress { get; set; }
        [XmlElement("authenticatedByMerchant", IsNullable = true)]
        public bool? AuthenticatedByMerchant { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
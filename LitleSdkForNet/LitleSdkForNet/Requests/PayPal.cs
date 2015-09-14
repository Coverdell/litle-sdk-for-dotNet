using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("payPal")]
    public class PayPal
    {
        [XmlElement("payerId")]
        public string PayerId { get; set; }
        [XmlElement("payerEmail")]
        public string PayerEmail { get; set; }
        [XmlElement("token")]
        public string Token { get; set; }
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
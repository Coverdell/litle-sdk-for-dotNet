using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("registerTokenRequestType")]
    public class RegisterTokenRequestType : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("accountNumber")]
        public string AccountNumber { get; set; }
        [XmlElement("echeckForToken")]
        public EcheckForTokenType EcheckForToken { get; set; }
        [XmlElement("paypageRegistrationId")]
        public string PaypageRegistrationId { get; set; }
        [XmlElement("cardValidationNum")]
        public string CardValidationNum { get; set; }
        [XmlElement("applepay")]
        public ApplepayType Applepay { get; set; }
    }
}
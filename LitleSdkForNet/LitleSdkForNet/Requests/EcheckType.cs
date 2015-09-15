using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckType")]
    public class EcheckType
    {
        [XmlElement("accType")]
        public EcheckAccountTypeEnum? AccType { get; set; }
        [XmlElement("accNum")]
        public string AccNum { get; set; }
        [XmlElement("routingNum")]
        public string RoutingNum { get; set; }
        [XmlElement("checkNum")]
        public string CheckNum { get; set; }
        [XmlElement("ccdPaymentInformation")]
        public string CcdPaymentInformation { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("echeckRedeposit")]
    public class EcheckRedeposit : BaseRequestTransactionEcheckRedeposit
    {
        [XmlElement("echeck")]
        public EcheckType Echeck { get; set; }
        [XmlElement("token")]
        public EcheckTokenType Token { get; set; }
        [XmlElement("merchantData")]
        public MerchantDataType MerchantData { get; set; }
    }
}
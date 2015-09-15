using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("registerTokenResponse")]
    public class RegisterTokenResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlElement("litleToken")]
        public string LitleToken { get; set; }

        [XmlElement("bin")]
        public string Bin { get; set; }

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum? Type { get; set; }

        [XmlElement("eCheckAccountSuffix")]
        public string ECheckAccountSuffix { get; set; }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse { get; set; }
    }
}
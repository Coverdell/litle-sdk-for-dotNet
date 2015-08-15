using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("registerTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("registerTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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
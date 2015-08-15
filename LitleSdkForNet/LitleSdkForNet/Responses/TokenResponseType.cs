using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("tokenResponseType", Namespace = "http://www.litle.com/schema")]
    public class TokenResponseType
    {
        [XmlElement("litleToken")]
        public string LitleToken { get; set; }

        [XmlElement("tokenResponseCode")]
        public string TokenResponseCode { get; set; }

        [XmlElement("tokenMessage")]
        public string TokenMessage { get; set; }

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }

        [XmlIgnore]
        public bool TypeSpecified { get; set; }

        [XmlElement("bin")]
        public string Bin { get; set; }

        [XmlElement("eCheckAccountSuffix")]
        public string ECheckAccountSuffix { get; set; }
    }
}
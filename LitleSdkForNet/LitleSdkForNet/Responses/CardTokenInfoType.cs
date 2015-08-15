using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cardTokenInfoType", Namespace = "http://www.litle.com/schema")]
    public class CardTokenInfoType
    {
        [XmlElement("litleToken")]
        public string LitleToken { get; set; }

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }

        [XmlElement("expDate")]
        public string ExpDate { get; set; }

        [XmlElement("bin")]
        public string Bin { get; set; }
    }
}
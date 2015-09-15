using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("cardAccountInfoType")]
    public class CardAccountInfoType
    {
        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("expDate")]
        public string ExpDate { get; set; }
    }
}
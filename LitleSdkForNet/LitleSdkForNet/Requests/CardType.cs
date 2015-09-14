using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("cardType")]
    public class CardType
    {
        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }
        [XmlElement("number")]
        public string Number { get; set; }
        [XmlElement("expDate")]
        public string ExpDate { get; set; }
        [XmlElement("track")]
        public string Track { get; set; }
        [XmlElement("cardValidationNum")]
        public string CardValidationNum { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
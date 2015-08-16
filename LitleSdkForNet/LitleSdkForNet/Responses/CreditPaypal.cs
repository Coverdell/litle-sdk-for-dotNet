using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("creditPaypal")]
    public class CreditPaypal
    {
        [XmlElement("payerEmail", typeof (string)), XmlElement("payerId", typeof (string)), XmlChoiceIdentifier("ItemElementName")]
        public string Item { get; set; }

        [XmlIgnore]
        public ItemChoiceType2 ItemElementName { get; set; }
    }
}
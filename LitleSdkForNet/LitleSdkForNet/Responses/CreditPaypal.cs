using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("creditPaypal", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class CreditPaypal
    {
        [XmlElement("payerEmail", typeof (string)), XmlElement("payerId", typeof (string)), XmlChoiceIdentifier("ItemElementName")]
        public string Item { get; set; }

        [XmlIgnore]
        public ItemChoiceType2 ItemElementName { get; set; }
    }
}
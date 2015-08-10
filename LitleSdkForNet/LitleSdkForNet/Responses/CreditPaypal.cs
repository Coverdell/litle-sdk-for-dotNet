using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("creditPaypal", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class CreditPaypal
    {
        private string _itemField;
        private ItemChoiceType2 _itemElementNameField;

        [XmlElement("payerEmail", typeof (string))]
        [XmlElement("payerId", typeof (string))]
        [XmlChoiceIdentifier("ItemElementName")]
        public string Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }

        [XmlIgnore]
        public ItemChoiceType2 ItemElementName
        {
            get { return _itemElementNameField; }
            set { _itemElementNameField = value; }
        }
    }
}
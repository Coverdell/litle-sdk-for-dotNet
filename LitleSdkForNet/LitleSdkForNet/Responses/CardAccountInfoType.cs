using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cardAccountInfoType", Namespace = "http://www.litle.com/schema")]
    public class CardAccountInfoType
    {
        private MethodOfPaymentTypeEnum _typeField;
        private string _numberField;
        private string _expDateField;

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        [XmlElement("number")]
        public string Number
        {
            get { return _numberField; }
            set { _numberField = value; }
        }

        [XmlElement("expDate")]
        public string ExpDate
        {
            get { return _expDateField; }
            set { _expDateField = value; }
        }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("accountInfoType", Namespace = "http://www.litle.com/schema")]
    public class AccountInfoType
    {
        private MethodOfPaymentTypeEnum _typeField;
        private string _numberField;

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
    }
}
using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class AccountInfoType
    {
        private MethodOfPaymentTypeEnum _typeField;
        private string _numberField;

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string Number
        {
            get { return _numberField; }
            set { _numberField = value; }
        }
    }
}
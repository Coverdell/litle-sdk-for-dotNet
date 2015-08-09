using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class CardTokenInfoType
    {
        private string _litleTokenField;
        private MethodOfPaymentTypeEnum _typeField;
        private string _expDateField;
        private string _binField;

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        public string ExpDate
        {
            get { return _expDateField; }
            set { _expDateField = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }
    }
}
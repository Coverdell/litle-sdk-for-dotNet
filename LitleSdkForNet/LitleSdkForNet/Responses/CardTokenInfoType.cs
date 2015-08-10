using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("cardTokenInfoType", Namespace = "http://www.litle.com/schema")]
    public class CardTokenInfoType
    {
        private string _litleTokenField;
        private MethodOfPaymentTypeEnum _typeField;
        private string _expDateField;
        private string _binField;

        [XmlElement("litleToken")]
        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        [XmlElement("expDate")]
        public string ExpDate
        {
            get { return _expDateField; }
            set { _expDateField = value; }
        }

        [XmlElement("bin")]
        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }
    }
}
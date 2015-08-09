using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class TokenResponseType
    {
        private string _litleTokenField;
        private string _tokenResponseCodeField;
        private string _tokenMessageField;
        private MethodOfPaymentTypeEnum _typeField;
        private bool _typeFieldSpecified;
        private string _binField;
        private string _eCheckAccountSuffixField;

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string TokenResponseCode
        {
            get { return _tokenResponseCodeField; }
            set { _tokenResponseCodeField = value; }
        }

        public string TokenMessage
        {
            get { return _tokenMessageField; }
            set { _tokenMessageField = value; }
        }

        public MethodOfPaymentTypeEnum Type
        {
            get { return _typeField; }
            set { _typeField = value; }
        }

        [XmlIgnore]
        public bool TypeSpecified
        {
            get { return _typeFieldSpecified; }
            set { _typeFieldSpecified = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }

        public string ECheckAccountSuffix
        {
            get { return _eCheckAccountSuffixField; }
            set { _eCheckAccountSuffixField = value; }
        }
    }
}
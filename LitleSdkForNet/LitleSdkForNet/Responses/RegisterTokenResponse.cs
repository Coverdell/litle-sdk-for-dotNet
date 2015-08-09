using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class RegisterTokenResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _litleTokenField;
        private string _binField;
        private MethodOfPaymentTypeEnum? _typeField;
        private bool _typeFieldSpecified;
        private string _eCheckAccountSuffixField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;
        private ApplepayResponse _applepayResponseField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }

        public MethodOfPaymentTypeEnum? Type
        {
            get { return _typeFieldSpecified ? _typeField : null; }
            set { _typeField = value; }
        }

        [XmlIgnore]
        public bool TypeSpecified
        {
            get { return _typeFieldSpecified; }
            set { _typeFieldSpecified = value; }
        }

        public string ECheckAccountSuffix
        {
            get { return _eCheckAccountSuffixField; }
            set { _eCheckAccountSuffixField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public ApplepayResponse ApplepayResponse
        {
            get { return _applepayResponseField; }
            set { _applepayResponseField = value; }
        }
    }
}
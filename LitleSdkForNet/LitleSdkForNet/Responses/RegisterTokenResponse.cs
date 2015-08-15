using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("registerTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("registerTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        [XmlElement("orderId")]
        public string OrderId
        {
            get { return _orderIdField; }
            set { _orderIdField = value; }
        }

        [XmlElement("litleToken")]
        public string LitleToken
        {
            get { return _litleTokenField; }
            set { _litleTokenField = value; }
        }

        [XmlElement("bin")]
        public string Bin
        {
            get { return _binField; }
            set { _binField = value; }
        }

        [XmlElement("type")]
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

        [XmlElement("eCheckAccountSuffix")]
        public string ECheckAccountSuffix
        {
            get { return _eCheckAccountSuffixField; }
            set { _eCheckAccountSuffixField = value; }
        }

        [XmlElement("response")]
        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        [XmlElement("applepayResponse")]
        public ApplepayResponse ApplepayResponse
        {
            get { return _applepayResponseField; }
            set { _applepayResponseField = value; }
        }
    }
}
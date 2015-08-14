using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("updateCardValidationNumOnTokenResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("updateCardValidationNumOnTokenResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdateCardValidationNumOnTokenResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private string _messageField;
        private DateTime _responseTimeField;

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
    }
}
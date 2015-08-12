using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("forceCaptureResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("forceCaptureResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ForceCaptureResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("giftCardResponse")]
        public GiftCardResponse GiftCardResponse;
        [XmlElement("fraudResult")]
        public FraudResult FraudResult;
        
        private long _litleTxnIdField;
        private string _orderIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private string _messageField;
        private TokenResponseType _tokenResponseField;
        private AccountUpdater _accountUpdaterField;

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

        [XmlElement("responseTime")]
        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        [XmlIgnore]
        public bool PostDateSpecified
        {
            get { return _postDateFieldSpecified; }
            set { _postDateFieldSpecified = value; }
        }

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }
    }
}
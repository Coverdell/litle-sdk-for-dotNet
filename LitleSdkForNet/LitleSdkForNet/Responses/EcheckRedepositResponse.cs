using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckRedepositResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        private DateTime _postDateField;
        private bool _postDateFieldSpecified;
        private AccountUpdater _accountUpdaterField;
        private TokenResponseType _tokenResponseField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string Response
        {
            get { return _responseField; }
            set { _responseField = value; }
        }

        public DateTime ResponseTime
        {
            get { return _responseTimeField; }
            set { _responseTimeField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement(DataType = "date")]
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

        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }
    }
}
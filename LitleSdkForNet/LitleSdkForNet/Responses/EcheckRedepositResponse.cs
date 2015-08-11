using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckRedepositResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckRedepositResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
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

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
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

        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater
        {
            get { return _accountUpdaterField; }
            set { _accountUpdaterField = value; }
        }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse
        {
            get { return _tokenResponseField; }
            set { _tokenResponseField = value; }
        }
    }
}
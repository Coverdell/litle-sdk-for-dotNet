using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckVoidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseEcheckVoidResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private string _messageField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;

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

        [XmlElement(DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute]
        public bool Duplicate
        {
            get { return _duplicateField; }
            set { _duplicateField = value; }
        }

        [XmlIgnore]
        public bool DuplicateSpecified
        {
            get { return _duplicateFieldSpecified; }
            set { _duplicateFieldSpecified = value; }
        }
    }
}
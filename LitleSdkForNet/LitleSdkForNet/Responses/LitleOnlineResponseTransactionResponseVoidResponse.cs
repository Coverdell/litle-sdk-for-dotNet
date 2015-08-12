using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("litleOnlineResponseTransactionResponseVoidResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("voidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseVoidResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private DateTime _postDateField;
        private string _messageField;
        private bool _duplicateField;
        private bool _duplicateFieldSpecified;
        private VoidRecyclingResponseType _recyclingField;

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

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate
        {
            get { return _postDateField; }
            set { _postDateField = value; }
        }

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlAttribute("duplicate")]
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

        [XmlElement("recycling")]
        public VoidRecyclingResponseType Recycling
        {
            get { return _recyclingField; }
            set { _recyclingField = value; }
        }
    }
}
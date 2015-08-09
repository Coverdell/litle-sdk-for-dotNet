using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class VendorCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;

        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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
    }
}
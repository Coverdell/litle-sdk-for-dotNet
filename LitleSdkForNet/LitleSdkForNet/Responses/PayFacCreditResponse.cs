using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("payFacCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("payFacCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PayFacCreditResponse : TransactionTypeWithReportGroup
    {
        private long _litleTxnIdField;
        private string _fundsTransferIdField;
        private string _responseField;
        private DateTime _responseTimeField;
        private string _messageField;
        
        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return _litleTxnIdField; }
            set { _litleTxnIdField = value; }
        }

        [XmlElement("fundTransferId")]
        public string FundsTransferId
        {
            get { return _fundsTransferIdField; }
            set { _fundsTransferIdField = value; }
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
    }
}
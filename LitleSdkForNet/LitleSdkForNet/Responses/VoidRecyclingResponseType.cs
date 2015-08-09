using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class VoidRecyclingResponseType
    {
        private long _creditLitleTxnIdField;

        public long CreditLitleTxnId
        {
            get { return _creditLitleTxnIdField; }
            set { _creditLitleTxnIdField = value; }
        }
    }
}
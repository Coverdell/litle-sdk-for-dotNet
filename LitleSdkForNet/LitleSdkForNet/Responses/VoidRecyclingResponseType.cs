using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("voidRecyclingResponseType", Namespace = "http://www.litle.com/schema")]
    public class VoidRecyclingResponseType
    {
        private long _creditLitleTxnIdField;
        [XmlElement("creditLitleTxnId")]
        public long CreditLitleTxnId
        {
            get { return _creditLitleTxnIdField; }
            set { _creditLitleTxnIdField = value; }
        }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlType("BaseRequestTransactionEcheckRedeposit", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckRedeposit", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BaseRequestTransactionEcheckRedeposit : TransactionTypeWithReportGroup
    {
        protected long LitleTxnIdField;
        protected bool LitleTxnIdSet;

        private object _itemField;

        [XmlElement("litleTxnId")]
        public long LitleTxnId
        {
            get { return LitleTxnIdField; }
            set
            {
                LitleTxnIdField = value;
                LitleTxnIdSet = true;
            }
        }

        [XmlElement("echeck", typeof (EcheckType))]
        [XmlElement("echeckToken", typeof (EcheckTokenType))]
        public object Item
        {
            get { return _itemField; }
            set { _itemField = value; }
        }
    }
}
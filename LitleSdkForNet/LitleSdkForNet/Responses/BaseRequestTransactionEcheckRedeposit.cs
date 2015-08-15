using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlType("baseRequestTransactionEcheckRedeposit", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckRedeposit", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class BaseRequestTransactionEcheckRedeposit : TransactionTypeWithReportGroup
    {
        protected long LitleTxnIdField;
        protected bool LitleTxnIdSet;

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

        [XmlElement("echeck", typeof (EcheckType)), XmlElement("echeckToken", typeof (EcheckTokenType))]
        public object Item { get; set; }
    }
}
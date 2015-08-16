using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("baseRequestTransactionEcheckRedeposit")]
    [LitleXmlRoot("echeckRedeposit")]
    public class BaseRequestTransactionEcheckRedeposit : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId", IsNullable = true)]
        public long? LitleTxnId { get; set; }

        [XmlElement("echeck", typeof (EcheckType)), XmlElement("echeckToken", typeof (EcheckTokenType))]
        public object Item { get; set; }
    }
}
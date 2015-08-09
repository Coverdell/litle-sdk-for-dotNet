using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateReversalResponse : TransactionTypeWithReportGroup
    {
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
    }
}
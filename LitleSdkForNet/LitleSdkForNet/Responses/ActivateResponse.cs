using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class ActivateResponse : TransactionTypeWithReportGroup
    {
        [XmlAttribute] public bool Duplicate;
        public string LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public DateTime PostDate;
        public string Message;
        public FraudResult FraudResult;
        public GiftCardResponse GiftCardResponse;
        public VirtualGiftCardResponseType VirtualGiftCardResponse;
    }
}
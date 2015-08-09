using System;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponse : TransactionTypeWithReportGroup
    {
        public long LitleTxnId;
        public string OrderId;
        public string Response;
        public DateTime ResponseTime;
        public string Message;

        //Optional child elements
        public CardType UpdatedCard;
        public CardType OriginalCard;
        public AccountUpdateResponseCardTokenType OriginalToken;
        public AccountUpdateResponseCardTokenType UpdatedToken;
    }
}
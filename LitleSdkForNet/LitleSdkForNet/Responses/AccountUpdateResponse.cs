using System;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlType("accountUpdateResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("accountUpdateResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId;
        [XmlElement("orderId")]
        public string OrderId;
        [XmlElement("response")]
        public string Response;
        [XmlElement("responseTime")]
        public DateTime ResponseTime;
        [XmlElement("message")]
        public string Message;

        //Optional child elements
        [XmlElement("updatedCard")]
        public CardType UpdatedCard;
        [XmlElement("originalCard")]
        public CardType OriginalCard;
        [XmlElement("originalToken")]
        public AccountUpdateResponseCardTokenType OriginalToken;
        [XmlElement("updatedToken")]
        public AccountUpdateResponseCardTokenType UpdatedToken;
    }
}
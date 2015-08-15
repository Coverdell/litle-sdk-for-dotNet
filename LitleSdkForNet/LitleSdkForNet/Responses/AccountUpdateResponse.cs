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
        public long LitleTxnId { get; set; }
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("response")]
        public string Response { get; set; }
        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }

        //Optional child elements
        [XmlElement("updatedCard")]
        public CardType UpdatedCard { get; set; }
        [XmlElement("originalCard")]
        public CardType OriginalCard { get; set; }
        [XmlElement("originalToken")]
        public AccountUpdateResponseCardTokenType OriginalToken { get; set; }
        [XmlElement("updatedToken")]
        public AccountUpdateResponseCardTokenType UpdatedToken { get; set; }
    }
}
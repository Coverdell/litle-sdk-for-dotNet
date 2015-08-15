using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlType("accountUpdateResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("accountUpdateResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponse : CommonTransactionTypeWithReportGroup
    {
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
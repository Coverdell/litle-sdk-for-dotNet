using System.Xml.Serialization;
using Litle.Sdk.Requests;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("accountUpdateResponse")]
    [LitleXmlRoot("accountUpdateResponse")]
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
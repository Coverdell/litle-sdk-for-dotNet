using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("accountUpdate")]
    public class AccountUpdate : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("card", IsNullable = true)]
        public CardType Card { get; set; }
        [XmlElement("token", IsNullable = true)]
        public CardTokenType Token { get; set; }
    }
}
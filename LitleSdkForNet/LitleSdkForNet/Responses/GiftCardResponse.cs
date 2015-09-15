using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("giftCardResponse")]
    public class GiftCardResponse
    {
        [XmlElement("availableBalance")]
        public string AvailableBalance { get; set; }
        [XmlElement("beginningBalance")]
        public string BeginningBalance { get; set; }
        [XmlElement("endingBalance")]
        public string EndingBalance { get; set; }
        [XmlElement("cashBackAmount")]
        public string CashBackAmount { get; set; }
    }
}
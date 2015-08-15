using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("giftCardResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class GiftCardResponse
    {
        [XmlElement("availableBalance")]
        public String AvailableBalance { get; set; }
        [XmlElement("beginningBalance")]
        public String BeginningBalance { get; set; }
        [XmlElement("endingBalance")]
        public String EndingBalance { get; set; }
        [XmlElement("cashBackAmount")]
        public String CashBackAmount { get; set; }
    }
}
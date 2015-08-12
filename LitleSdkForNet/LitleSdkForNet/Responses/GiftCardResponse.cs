using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("giftCardResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class GiftCardResponse
    {
        [XmlElement("availableBalance")]
        public String AvailableBalance;
        [XmlElement("beginningBalance")]
        public String BeginningBalance;
        [XmlElement("endingBalance")]
        public String EndingBalance;
        [XmlElement("cashBackAmount")]
        public String CashBackAmount;
    }
}
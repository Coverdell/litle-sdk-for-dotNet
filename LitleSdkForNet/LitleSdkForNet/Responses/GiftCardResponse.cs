using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class GiftCardResponse
    {
        public String AvailableBalance;
        public String BeginningBalance;
        public String EndingBalance;
        public String CashBackAmount;
    }
}
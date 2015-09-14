using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("virtualGiftCardType")]
    public class VirtualGiftCardType
    {
        [XmlElement("accountNumberLength")]
        public int? AccountNumberLength { get; set; }
        [XmlElement("giftCardBin")]
        public string GiftCardBin { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
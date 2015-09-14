using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("deleteDiscount")]
    public class DeleteDiscount
    {
        [XmlElement("discountCode")]
        public string DiscountCode { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
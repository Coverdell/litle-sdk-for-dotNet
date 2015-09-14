using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("cardPaypageType")]
    public class CardPaypageType
    {
        [XmlElement("paypageRegistrationId")]
        public string PaypageRegistrationId { get; set; }
        [XmlElement("expDate")]
        public string ExpDate { get; set; }
        [XmlElement("cardValidationNum")]
        public string CardValidationNum { get; set; }
        [XmlElement("type", IsNullable = true)]
        public MethodOfPaymentTypeEnum? Type { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
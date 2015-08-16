using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("virtualGiftCardResponseType")]
    public class VirtualGiftCardResponseType
    {
        [XmlElement("accountNumber")]
        public String AccountNumber { get; set; }
        [XmlElement("cardValidationNum")]
        public String CardValidationNum { get; set; }
    }
}
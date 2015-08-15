using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("virtualGiftCardResponseType", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class VirtualGiftCardResponseType
    {
        [XmlElement("accountNumber")]
        public String AccountNumber { get; set; }
        [XmlElement("cardValidationNum")]
        public String CardValidationNum { get; set; }
    }
}
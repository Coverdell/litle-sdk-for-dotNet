using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public class VirtualGiftCardResponseType
    {
        public String AccountNumber;
        public String CardValidationNum;
    }
}
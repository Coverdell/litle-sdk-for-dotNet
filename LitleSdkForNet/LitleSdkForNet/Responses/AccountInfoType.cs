using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("accountInfoType")]
    public class AccountInfoType
    {
        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }
    }
}
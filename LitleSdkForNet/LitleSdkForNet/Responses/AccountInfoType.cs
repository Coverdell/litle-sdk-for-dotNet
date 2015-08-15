using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("accountInfoType", Namespace = "http://www.litle.com/schema")]
    public class AccountInfoType
    {
        [XmlElement("type")]
        public MethodOfPaymentTypeEnum Type { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }
    }
}
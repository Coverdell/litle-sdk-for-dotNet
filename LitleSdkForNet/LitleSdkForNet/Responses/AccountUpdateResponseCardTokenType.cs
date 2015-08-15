using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlType("accountUpdateResponseCardTokenType", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("accountUpdateResponseCardTokenType", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponseCardTokenType : CardTokenType
    {
        [XmlElement("bin")]
        public string Bin { get; set; }
    }
}
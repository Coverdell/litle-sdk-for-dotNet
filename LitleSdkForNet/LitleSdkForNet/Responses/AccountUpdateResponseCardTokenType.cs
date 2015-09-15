using System.Xml.Serialization;
using Litle.Sdk.Requests;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("accountUpdateResponseCardTokenType")]
    [LitleXmlRoot("accountUpdateResponseCardTokenType")]
    public class AccountUpdateResponseCardTokenType : CardTokenType
    {
        [XmlElement("bin")]
        public string Bin { get; set; }
    }
}
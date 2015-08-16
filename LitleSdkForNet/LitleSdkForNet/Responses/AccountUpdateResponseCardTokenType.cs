using System.Xml.Serialization;
using Litle.Sdk.Requests;

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
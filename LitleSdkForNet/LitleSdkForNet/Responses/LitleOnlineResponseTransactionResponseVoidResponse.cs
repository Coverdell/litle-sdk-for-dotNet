using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("litleOnlineResponseTransactionResponseVoidResponse")]
    [LitleXmlRoot("voidResponse")]
    public class LitleOnlineResponseTransactionResponseVoidResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }

        [XmlElement("recycling")]
        public VoidRecyclingResponseType Recycling { get; set; }
    }
}
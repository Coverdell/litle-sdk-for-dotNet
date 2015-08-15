using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("litleOnlineResponseTransactionResponseVoidResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("voidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
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
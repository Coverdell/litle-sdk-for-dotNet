using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("litleOnlineResponseTransactionResponseEcheckVoidResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckVoidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseEcheckVoidResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
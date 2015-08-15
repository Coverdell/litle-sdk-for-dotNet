using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckPreNoteCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckPreNoteCreditResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
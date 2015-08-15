using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckPreNoteSaleResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("echeckPreNoteSaleResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class EcheckPreNoteSaleResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
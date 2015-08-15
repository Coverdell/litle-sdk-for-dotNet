using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("authReversalResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("authReversalResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AuthReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
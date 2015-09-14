using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("authReversalResponse")]
    [LitleXmlRoot("authReversalResponse")]
    public class AuthReversalResponse : CommonTransactionTypeWithReportGroupAndOrderAndPostDateAndGiftCardResponse
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("echeckPreNotSaleResponse")]
    [LitleXmlRoot("echeckPreNoteSaleResponse")]
    public class EcheckPreNoteSaleResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("echeckPreNoteCreditResponse")]
    public class EcheckPreNoteCreditResponse : CommonTransactionTypeWithReportGroupAndOrder
    {
        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }
    }
}
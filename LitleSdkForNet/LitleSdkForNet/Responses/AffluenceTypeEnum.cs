using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("AffluenceTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum AffluenceTypeEnum
    {
        [XmlEnum("AFFLUENT")] Affluent,
        [XmlEnum("MASS AFFLUENT")] Massaffluent,
    }
}
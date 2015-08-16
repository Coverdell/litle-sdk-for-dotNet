using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("affluenceTypeEnum")]
    public enum AffluenceTypeEnum
    {
        [XmlEnum("AFFLUENT")] Affluent,
        [XmlEnum("MASS AFFLUENT")] Massaffluent,
    }
}
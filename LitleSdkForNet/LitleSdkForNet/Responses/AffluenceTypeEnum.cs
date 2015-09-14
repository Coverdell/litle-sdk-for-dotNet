using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("affluenceTypeEnum")]
    public enum AffluenceTypeEnum
    {
        [XmlEnum("AFFLUENT")] Affluent,
        [XmlEnum("MASS AFFLUENT")] Massaffluent,
    }
}
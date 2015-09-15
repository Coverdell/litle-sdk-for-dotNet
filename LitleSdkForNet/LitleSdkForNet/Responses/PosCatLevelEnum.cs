using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("catLevel")]
    public enum PosCatLevelEnum
    {
        [XmlEnum("self service")]
        Selfservice
    }
}
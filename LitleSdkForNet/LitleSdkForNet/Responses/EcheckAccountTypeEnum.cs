using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("echeckAccountTypeEnum")]
    public enum EcheckAccountTypeEnum
    {
        Checking,
        Savings,
        Corporate,
        [XmlEnum("Corp Savings")] CorpSavings,
    }
}
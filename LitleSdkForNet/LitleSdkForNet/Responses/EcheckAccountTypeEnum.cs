using System.Xml.Serialization;

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
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("echeckAccountTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum EcheckAccountTypeEnum
    {
        Checking,
        Savings,
        Corporate,
        [XmlEnum("Corp Savings")] CorpSavings,
    }
}
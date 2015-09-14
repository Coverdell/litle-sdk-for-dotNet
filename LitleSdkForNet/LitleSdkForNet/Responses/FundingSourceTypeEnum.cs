using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("fundingSourceTypeEnum")]
    public enum FundingSourceTypeEnum
    {
        [XmlEnum("UNKNOWN")]
        Unknown,
        [XmlEnum("PREPAID")]
        Prepaid,
        [XmlEnum("FSA")]
        Fsa,
        [XmlEnum("CREDIT")]
        Credit,
        [XmlEnum("DEBIT")]
        Debit,
    }
}
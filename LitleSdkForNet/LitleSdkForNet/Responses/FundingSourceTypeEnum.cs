using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("fundingSourceTypeEnum", Namespace = "http://www.litle.com/schema")]
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
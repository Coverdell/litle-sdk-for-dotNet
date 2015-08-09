using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlInclude(typeof (RegisterTokenRequestType))]
    public class TransactionTypeWithReportGroup : TransactionType
    {
        [XmlAttribute]
        public string ReportGroup { get; set; }
    }
}
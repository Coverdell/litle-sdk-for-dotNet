using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("updatePlan")]
    public class UpdatePlan : RecurringTransactionType
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
        [XmlElement("active")]
        public bool? Active { get; set; }
    }
}
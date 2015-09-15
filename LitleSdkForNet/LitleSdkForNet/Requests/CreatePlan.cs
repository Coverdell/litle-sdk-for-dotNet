using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("createPlan")]
    public class CreatePlan : RecurringTransactionType
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description", IsNullable = true)]
        public string Description { get; set; }
        [XmlElement("intervalType")]
        public IntervalType IntervalType { get; set; }
        [XmlElement("amount")]
        public long Amount { get; set; }
        [XmlElement("numberOfPayment", IsNullable = true)]
        public int? NumberOfPayments { get; set; }
        [XmlElement("trialNumberOfIntervals", IsNullable = true)]
        public int? TrialNumberOfIntervals { get; set; }
        [XmlElement("trialIntervalType", IsNullable = true)]
        public TrialIntervalType? TrialIntervalType { get; set; }
        [XmlElement("active", IsNullable = true)]
        public bool? Active { get; set; }
    }
}
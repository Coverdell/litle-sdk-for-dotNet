using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("createPlanResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("createPlanResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CreatePlanResponse : RecurringTransactionResponseType
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("updatePlanResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("updatePlanResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class UpdatePlanResponse : RecurringTransactionResponseType
    {
        [XmlElement("planCode")]
        public string PlanCode;
    }
}
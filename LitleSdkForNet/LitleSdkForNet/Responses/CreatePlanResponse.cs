using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("createPlanResponse")]
    [LitleXmlRoot("createPlanResponse")]
    public class CreatePlanResponse : RecurringTransactionResponseType
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
    }
}
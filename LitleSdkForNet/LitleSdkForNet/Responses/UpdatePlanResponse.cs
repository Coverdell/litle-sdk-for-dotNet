using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("updatePlanResponse")]
    public class UpdatePlanResponse : RecurringTransactionResponseType
    {
        [XmlElement("planCode")]
        public string PlanCode { get; set; }
    }
}
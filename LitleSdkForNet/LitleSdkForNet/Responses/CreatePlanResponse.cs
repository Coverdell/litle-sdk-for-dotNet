using System.Xml.Serialization;
using Litle.Sdk.Xml;

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
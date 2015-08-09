using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class CreatePlanResponse : RecurringTransactionResponseType
    {
        public string PlanCode;
    }
}
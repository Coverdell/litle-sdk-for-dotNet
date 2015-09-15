using System.Xml.Serialization;

namespace Litle.Sdk.Requests
{
    [XmlType("trialIntervalType", Namespace = "http://www.litle.com/schema")]
    public enum TrialIntervalType
    {
        [XmlEnum("MONTH")]
        Month,
        [XmlEnum("DAY")]
        Day
    }
}
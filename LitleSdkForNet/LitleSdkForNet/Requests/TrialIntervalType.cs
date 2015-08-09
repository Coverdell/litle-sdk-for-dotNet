using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Requests
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum TrialIntervalType
    {
        Month,
        Day
    }
}
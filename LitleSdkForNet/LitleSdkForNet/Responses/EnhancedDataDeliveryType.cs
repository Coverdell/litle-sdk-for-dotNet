using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    public enum EnhancedDataDeliveryType
    {
        CNC,
        DIG,
        PHY,
        SVC,
        TBD,
    }
}
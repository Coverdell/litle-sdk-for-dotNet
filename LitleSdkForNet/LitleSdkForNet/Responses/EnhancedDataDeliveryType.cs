using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
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
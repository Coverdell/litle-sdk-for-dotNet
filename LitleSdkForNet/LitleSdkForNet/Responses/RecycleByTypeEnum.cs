using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("recycleTypeEnum", Namespace = "http://www.litle.com/schema")]
    public enum RecycleByTypeEnum
    {
        Merchant,
        Litle,
        None,
    }
}
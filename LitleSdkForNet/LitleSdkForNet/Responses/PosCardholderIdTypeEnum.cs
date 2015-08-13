using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosCardholderIdTypeEnum
    {
        Signature,
        Pin,
        Nopin,
        Directmarket,
    }
}
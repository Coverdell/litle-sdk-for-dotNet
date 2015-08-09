using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public enum PosCapabilityTypeEnum
    {
        Notused,
        Magstripe,
        Keyedonly,
    }
}
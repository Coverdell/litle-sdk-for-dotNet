using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Requests
{
    public static class EnumUtility
    {
        public static XmlEnumAttribute GetXmlEnum(string name, Type type)
        {
            var memberInfo = type.GetMember(name)[0];
            var attr = (XmlEnumAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(XmlEnumAttribute));
            return attr;
        }
    }
}
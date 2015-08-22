using System;
using System.Xml.Serialization;

namespace Litle.Sdk
{
    public static class EnumUtility
    {
        public static XmlEnumAttribute GetXmlEnum(string name, Type type)
        {
            var memberInfo = type.GetMember(name)[0];
            return (XmlEnumAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(XmlEnumAttribute));
        }
    }
}
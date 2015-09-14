using System;
using System.Collections;
using System.Reflection;
using System.Security;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Litle.Sdk.Xml
{
    [Serializable]
    public class LitleXmlSerializable : IXmlSerializable
    {
        private readonly Type _type;
        private readonly object _value;

        public LitleXmlSerializable(Type type, object value)
        {
            _type = type;
            _value = value;
        }

        public LitleXmlSerializable()
            :this(null, null) { }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
        }

        public void WriteXml(XmlWriter writer)
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var properties = _type.GetProperties(bindingFlags);
            if (writer.WriteState == WriteState.Element)
            {
                foreach (var propertyInfo in properties)
                {
                    WritePropertyInfoAttribute(writer, propertyInfo);
                }
            }
            foreach (var propertyInfo in properties)
            {
                WritePropertyInfoElement(writer, propertyInfo);
            }
            foreach (var propertyInfo in properties)
            {
                WritePropertyInfoArray(writer, propertyInfo);
            }
        }

        private void WritePropertyInfoArray(XmlWriter writer, PropertyInfo propertyInfo)
        {
            var propertyType = propertyInfo.PropertyType;
            var arrayAttributes = Attribute.GetCustomAttributes(propertyInfo, typeof(XmlArrayAttribute), true);
            if (arrayAttributes.Length != 0)
            {
                var arrayAttribute = (XmlArrayAttribute)arrayAttributes[0];
                var type = propertyType.GetGenericTypeDefinition();
                var typeName = type != null ? type.Name : propertyType.Name;
                var value = propertyInfo.GetGetMethod().Invoke(_value, null);
                var itemName = arrayAttribute != null ? arrayAttribute.ElementName : typeName;
                foreach (var item in (IEnumerable)value)
                {
                    var valueType = item.GetType();
                    HandleType(writer, valueType, itemName, item);
                }
            }
        }

        private void WritePropertyInfoElement(XmlWriter writer, PropertyInfo propertyInfo)
        {
            var attributes = Attribute.GetCustomAttributes(propertyInfo, typeof (XmlElementAttribute), true);
            if (attributes.Length != 0)
            {
                var elementAttribute = (XmlElementAttribute) attributes[0];
                var value = propertyInfo.GetGetMethod().Invoke(_value, null);
                var propertyType = propertyInfo.PropertyType;
                if (value != null)
                {
                    var name = elementAttribute.ElementName ?? propertyInfo.Name;
                    HandleType(writer, propertyType, name, value);
                }
            }
        }

        private static void HandleType(XmlWriter writer, Type propertyType, string name, object value)
        {
            writer.WriteStartElement(name);
            if (propertyType.IsSerializable)
            {
                HandleSerializable(writer, propertyType, value);
            }
            else
            {
                var wrapper = new LitleXmlSerializable(propertyType, value);
                wrapper.WriteXml(writer);
            }
            writer.WriteEndElement();
        }

        private static void HandleSerializable(XmlWriter writer, Type propertyType, object value)
        {
            if (propertyType.IsGenericType &&
                propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                var underlyingType = Nullable.GetUnderlyingType(propertyType);
                HandleSerializable(writer, underlyingType, value);
            }
            else if (propertyType == typeof (DateTime))
            {
                var valueString = ((DateTime)value).ToString("yyyy-MM-dd");
                writer.WriteValue(SecurityElement.Escape(valueString));
            }
            else if (propertyType.IsEnum)
            {
                var valueString = value.ToString();
                var field = propertyType.GetField(valueString);
                var enumAttributes = Attribute.GetCustomAttributes(field, typeof (XmlEnumAttribute), true);
                if (enumAttributes.Length != 0)
                {
                    var enumAttribute = (XmlEnumAttribute) enumAttributes[0];
                    var enumName = enumAttribute != null ? enumAttribute.Name : valueString;
                    writer.WriteValue(SecurityElement.Escape(enumName));
                }
                else
                {
                    writer.WriteValue(SecurityElement.Escape(valueString));
                }
            }
            else
            {
                writer.WriteValue(value);
            }
        }

        private void WritePropertyInfoAttribute(XmlWriter writer, PropertyInfo propertyInfo)
        {
            var xmlAttributes = Attribute.GetCustomAttributes(propertyInfo, typeof (XmlAttributeAttribute), true);
            if (xmlAttributes.Length != 0)
            {
                var elementAttribute = (XmlAttributeAttribute) xmlAttributes[0];
                var name = elementAttribute.AttributeName ?? propertyInfo.Name;
                var value = propertyInfo.GetGetMethod().Invoke(_value, null);
                if (value != null)
                {
                    writer.WriteStartAttribute(name);
                    writer.WriteValue(value);
                    writer.WriteEndAttribute();
                }
            }
        }
    }
}
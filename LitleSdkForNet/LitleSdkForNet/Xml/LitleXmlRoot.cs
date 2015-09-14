using System.Xml.Serialization;

namespace Litle.Sdk.Xml
{
    public class LitleXmlRootAttribute : XmlRootAttribute
    {
        public LitleXmlRootAttribute(string elementName)
            : base(elementName)
        {
            Namespace = "http://www.litle.com/schema";
            IsNullable = false;
        }
    }

    public class LitleXmlTypeAttribute : XmlTypeAttribute
    {
        public LitleXmlTypeAttribute(string typeName)
            : base(typeName)
        {
            Namespace = "http://www.litle.com/schema";
            AnonymousType = true;
        }
    }
}

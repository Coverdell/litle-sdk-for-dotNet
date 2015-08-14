using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{

    public sealed class PosCatLevelEnum
    {
        [XmlElement("selfservice")]
        public static readonly PosCatLevelEnum Selfservice = new PosCatLevelEnum("self service");

        private PosCatLevelEnum(String value)
        {
            _value = value;
        }

        public string Serialize()
        {
            return _value;
        }

        private readonly string _value;
    }
}
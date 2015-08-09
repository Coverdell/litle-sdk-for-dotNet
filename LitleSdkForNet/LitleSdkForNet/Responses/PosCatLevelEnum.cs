using System;

namespace Litle.Sdk.Responses
{
    public sealed class PosCatLevelEnum
    {
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
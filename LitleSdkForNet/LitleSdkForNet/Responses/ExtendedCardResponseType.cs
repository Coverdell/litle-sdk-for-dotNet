using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class ExtendedCardResponseType
    {
        private string _messageField;
        private string _codeField;

        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        public string Code
        {
            get { return _codeField; }
            set { _codeField = value; }
        }
    }
}
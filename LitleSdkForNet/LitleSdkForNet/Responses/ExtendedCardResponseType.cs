using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType(Namespace = "http://www.litle.com/schema")]
    public class ExtendedCardResponseType
    {
        private string _messageField;
        private string _codeField;

        [XmlElement("message")]
        public string Message
        {
            get { return _messageField; }
            set { _messageField = value; }
        }

        [XmlElement("code")]
        public string Code
        {
            get { return _codeField; }
            set { _codeField = value; }
        }
    }
}
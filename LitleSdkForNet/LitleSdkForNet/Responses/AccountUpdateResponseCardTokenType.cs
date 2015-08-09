using System;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class AccountUpdateResponseCardTokenType : CardTokenType
    {
        public string Bin;
    }
}
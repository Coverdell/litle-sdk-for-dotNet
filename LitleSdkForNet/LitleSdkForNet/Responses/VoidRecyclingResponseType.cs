using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("voidRecyclingResponseType", Namespace = "http://www.litle.com/schema")]
    public class VoidRecyclingResponseType
    {
        [XmlElement("creditLitleTxnId")]
        public long CreditLitleTxnId { get; set; }
    }
}
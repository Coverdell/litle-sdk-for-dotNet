using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("voidRecyclingResponseType")]
    public class VoidRecyclingResponseType
    {
        [XmlElement("creditLitleTxnId")]
        public long CreditLitleTxnId { get; set; }
    }
}
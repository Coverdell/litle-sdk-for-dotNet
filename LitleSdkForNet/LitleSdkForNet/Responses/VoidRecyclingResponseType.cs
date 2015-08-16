using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("voidRecyclingResponseType")]
    public class VoidRecyclingResponseType
    {
        [XmlElement("creditLitleTxnId")]
        public long CreditLitleTxnId { get; set; }
    }
}
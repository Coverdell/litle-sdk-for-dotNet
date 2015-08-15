using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("litleOnlineResponseTransactionResponseVoidResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("voidResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class LitleOnlineResponseTransactionResponseVoidResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("postDate", DataType = "date")]
        public DateTime PostDate { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlAttribute("duplicate")]
        public bool Duplicate { get; set; }

        [XmlIgnore]
        public bool DuplicateSpecified { get; set; }

        [XmlElement("recycling")]
        public VoidRecyclingResponseType Recycling { get; set; }
    }
}
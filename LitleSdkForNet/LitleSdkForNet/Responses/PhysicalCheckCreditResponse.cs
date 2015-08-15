using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("physicalCheckCreditResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("physicalCheckCreditResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class PhysicalCheckCreditResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("fundsTransferId")]
        public string FundsTransferId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }
    }
}
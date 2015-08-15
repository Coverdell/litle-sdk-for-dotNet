using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("fraudCheckResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("fraudCheckResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class FraudCheckResponse : TransactionTypeWithReportGroup
    {
        [XmlElement("litleTxnId")]
        public long LitleTxnId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }

        [XmlElement("advancedFraudResults")]
        public AdvancedFraudResultsType AdvancedFraudResults { get; set; }
    }
}
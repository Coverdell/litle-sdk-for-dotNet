using System;
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [LitleXmlType("recurringTransactionResponseType")]
    public class RecurringTransactionResponseType : TransactionResponse
    {
        [XmlElement("litleTxnId")]
        public string LitleTxnId { get; set; }

        [XmlElement("response")]
        public string Response { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("responseTime")]
        public DateTime ResponseTime { get; set; }
    }
}
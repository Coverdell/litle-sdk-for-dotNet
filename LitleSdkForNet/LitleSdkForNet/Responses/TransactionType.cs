using System;
using System.Xml.Serialization;
using Litle.Sdk.Requests;

namespace Litle.Sdk.Responses
{
    [XmlInclude(typeof (TransactionTypeOptionReportGroup))]
    [XmlInclude(typeof (TransactionTypeWithReportGroupAndPartial))]
    [XmlInclude(typeof (TransactionTypeWithReportGroup))]
    [XmlInclude(typeof (RegisterTokenRequestType))]
    [Serializable]
    [XmlType("transactionType", Namespace = "http://www.litle.com/schema")]
    public class TransactionType : TransactionRequest
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("customerId")]
        public string CustomerId { get; set; }
    }
}
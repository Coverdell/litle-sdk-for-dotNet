using System.Xml.Serialization;
using Litle.Sdk.Requests;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [XmlInclude(typeof (TransactionTypeOptionReportGroup))]
    [XmlInclude(typeof (TransactionTypeWithReportGroupAndPartial))]
    [XmlInclude(typeof (TransactionTypeWithReportGroup))]
    [XmlInclude(typeof (RegisterTokenRequestType))]
    [LitleXmlType("transactionType")]
    public class TransactionType : TransactionRequest
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("customerId")]
        public string CustomerId { get; set; }
    }
}
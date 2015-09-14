using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("updateCardValidationNumOnToken")]
    public class UpdateCardValidationNumOnToken : TransactionTypeWithReportGroup
    {
        [XmlElement("orderId")]
        public string OrderId { get; set; }
        [XmlElement("litleToken")]
        public string LitleToken { get; set; }
        [XmlElement("cardValidationNum")]
        public string CardValidationNum { get; set; }
    }
}
using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlType("fraudCheckResponse", AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot("fraudCheckResponse", Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public class FraudCheckResponse : CommonTransactionTypeWithReportGroup
    {
        [XmlElement("advancedFraudResults")]
        public AdvancedFraudResultsType AdvancedFraudResults { get; set; }
    }
}
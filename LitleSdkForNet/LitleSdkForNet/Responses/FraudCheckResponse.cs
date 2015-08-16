using System.Xml.Serialization;

namespace Litle.Sdk.Responses
{
    [XmlRoot("fraudCheckResponse")]
    public class FraudCheckResponse : CommonTransactionTypeWithReportGroup
    {
        [XmlElement("advancedFraudResults")]
        public AdvancedFraudResultsType AdvancedFraudResults { get; set; }
    }
}
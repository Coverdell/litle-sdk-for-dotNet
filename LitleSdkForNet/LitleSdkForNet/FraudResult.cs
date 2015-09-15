using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk
{
    [LitleXmlType("fraudResult")]
    [LitleXmlRoot("fraudResult")]
    public class FraudResult
    {
        [XmlElement("advancedFraudResults")]
        public AdvancedFraudResultsType AdvancedFraudResults { get; set; }

        [XmlElement("avsResult")]
        public string AvsResult { get; set; }

        [XmlElement("cardValidationResult")]
        public string CardValidationResult { get; set; }

        [XmlElement("authenticationResult")]
        public string AuthenticationResult { get; set; }

        [XmlElement("advancedAvsResult")]
        public string AdvancedAVSResult { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (AvsResult != null) xml += "\r\n<avsResult>" + SecurityElement.Escape(AvsResult) + "</avsResult>";
            if (CardValidationResult != null)
                xml += "\r\n<cardValidationResult>" + SecurityElement.Escape(CardValidationResult) +
                       "</cardValidationResult>";
            if (AuthenticationResult != null)
                xml += "\r\n<authenticationResult>" + SecurityElement.Escape(AuthenticationResult) +
                       "</authenticationResult>";
            if (AdvancedAVSResult != null)
                xml += "\r\n<advancedAVSResult>" + SecurityElement.Escape(AdvancedAVSResult) + "</advancedAVSResult>";
            return xml;
        }
    }
}
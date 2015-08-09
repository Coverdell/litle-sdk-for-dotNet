using System;
using System.Security;
using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://www.litle.com/schema")]
    [XmlRoot(Namespace = "http://www.litle.com/schema", IsNullable = false)]
    public partial class FraudResult
    {
        private string _avsResultField;
        private string _cardValidationResultField;
        private string _authenticationResultField;
        private string _advancedAvsResultField;

        public AdvancedFraudResultsType AdvancedFraudResults;

        public string AvsResult
        {
            get { return _avsResultField; }
            set { _avsResultField = value; }
        }

        public string CardValidationResult
        {
            get { return _cardValidationResultField; }
            set { _cardValidationResultField = value; }
        }

        public string AuthenticationResult
        {
            get { return _authenticationResultField; }
            set { _authenticationResultField = value; }
        }

        public string AdvancedAVSResult
        {
            get { return _advancedAvsResultField; }
            set { _advancedAvsResultField = value; }
        }
    }

    public partial class FraudResult
    {
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
using System.Security;

namespace Litle.Sdk
{
    public partial class FraudResult
    {
        public string Serialize()
        {
            var xml = "";
            if (avsResult != null) xml += "\r\n<avsResult>" + SecurityElement.Escape(avsResult) + "</avsResult>";
            if (cardValidationResult != null)
                xml += "\r\n<cardValidationResult>" + SecurityElement.Escape(cardValidationResult) +
                       "</cardValidationResult>";
            if (authenticationResult != null)
                xml += "\r\n<authenticationResult>" + SecurityElement.Escape(authenticationResult) +
                       "</authenticationResult>";
            if (advancedAVSResult != null)
                xml += "\r\n<advancedAVSResult>" + SecurityElement.Escape(advancedAVSResult) + "</advancedAVSResult>";
            return xml;
        }
    }
}
using System.Security;

namespace Litle.Sdk.Requests
{
    public class ApplepayHeaderType
    {
        public string ApplicationData;
        public string EphemeralPublicKey;
        public string PublicKeyHash;
        public string TransactionId;

        public string Serialize()
        {
            var xml = "";
            if (ApplicationData != null)
                xml += "\r\n<applicationData>" + SecurityElement.Escape(ApplicationData) + "</applicationData>";
            if (EphemeralPublicKey != null)
                xml += "\r\n<ephemeralPublicKey>" + SecurityElement.Escape(EphemeralPublicKey) + "</ephemeralPublicKey>";
            if (PublicKeyHash != null)
                xml += "\r\n<publicKeyHash>" + SecurityElement.Escape(PublicKeyHash) + "</publicKeyHash>";
            if (TransactionId != null)
                xml += "\r\n<transactionId>" + SecurityElement.Escape(TransactionId) + "</transactionId>";
            return xml;
        }
    }
}
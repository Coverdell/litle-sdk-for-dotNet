using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class FraudCheckType
    {
        public String AuthenticationValue;
        public String AuthenticationTransactionId;
        public String CustomerIpAddress;
        private bool _authenticatedByMerchantField;
        private bool _authenticatedByMerchantSet;

        public bool AuthenticatedByMerchant
        {
            get { return _authenticatedByMerchantField; }
            set
            {
                _authenticatedByMerchantField = value;
                _authenticatedByMerchantSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            if (AuthenticationValue != null)
                xml += "\r\n<authenticationValue>" + SecurityElement.Escape(AuthenticationValue) +
                       "</authenticationValue>";
            if (AuthenticationTransactionId != null)
                xml += "\r\n<authenticationTransactionId>" + SecurityElement.Escape(AuthenticationTransactionId) +
                       "</authenticationTransactionId>";
            if (CustomerIpAddress != null)
                xml += "\r\n<customerIpAddress>" + SecurityElement.Escape(CustomerIpAddress) + "</customerIpAddress>";
            if (_authenticatedByMerchantSet)
                xml += "\r\n<authenticatedByMerchant>" + _authenticatedByMerchantField + "</authenticatedByMerchant>";
            return xml;
        }
    }
}
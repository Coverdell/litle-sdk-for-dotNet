using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class AuthInformation
    {
        public DateTime AuthDate;
        public string AuthCode;
        public FraudResult FraudResult;
        private long _authAmountField;
        private bool _authAmountSet;

        public long AuthAmount
        {
            get { return _authAmountField; }
            set
            {
                _authAmountField = value;
                _authAmountSet = true;
            }
        }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<authDate>" + XmlUtil.ToXsdDate(AuthDate) + "</authDate>";
            if (AuthCode != null) xml += "\r\n<authCode>" + SecurityElement.Escape(AuthCode) + "</authCode>";
            if (FraudResult != null) xml += "\r\n<fraudResult>" + FraudResult.Serialize() + "</fraudResult>";
            if (_authAmountSet) xml += "\r\n<authAmount>" + _authAmountField + "</authAmount>";
            return xml;
        }
    }
}
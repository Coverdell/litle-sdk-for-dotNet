using System.Security;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Requests
{
    public class EcheckTokenType
    {
        public string LitleToken { get; set; }
        public string RoutingNum { get; set; }
        private EcheckAccountTypeEnum _accTypeField;
        private bool _accTypeSet;

        public EcheckAccountTypeEnum AccType
        {
            get { return _accTypeField; }
            set
            {
                _accTypeField = value;
                _accTypeSet = true;
            }
        }

        public string CheckNum { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (LitleToken != null) xml += "\r\n<litleToken>" + SecurityElement.Escape(LitleToken) + "</litleToken>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            if (_accTypeSet) xml += "\r\n<accType>" + _accTypeField + "</accType>";
            if (CheckNum != null) xml += "\r\n<checkNum>" + SecurityElement.Escape(CheckNum) + "</checkNum>";
            return xml;
        }
    }
}
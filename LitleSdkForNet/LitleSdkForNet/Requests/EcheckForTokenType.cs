using System.Security;

namespace Litle.Sdk.Requests
{
    public class EcheckForTokenType
    {
        public string AccNum;
        public string RoutingNum;

        public string Serialize()
        {
            var xml = "";
            if (AccNum != null) xml += "\r\n<accNum>" + SecurityElement.Escape(AccNum) + "</accNum>";
            if (RoutingNum != null) xml += "\r\n<routingNum>" + SecurityElement.Escape(RoutingNum) + "</routingNum>";
            return xml;
        }
    }
}
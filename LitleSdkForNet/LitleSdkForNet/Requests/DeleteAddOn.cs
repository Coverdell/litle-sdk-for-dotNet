using System.Security;

namespace Litle.Sdk.Requests
{
    public class DeleteAddOn
    {
        public string AddOnCode { get; set; }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<addOnCode>" + SecurityElement.Escape(AddOnCode) + "</addOnCode>";
            return xml;
        }
    }
}
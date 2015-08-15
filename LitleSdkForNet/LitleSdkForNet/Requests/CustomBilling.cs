using System.Security;

namespace Litle.Sdk.Requests
{
    public class CustomBilling
    {
        public string Phone { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
        public string Descriptor { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Phone != null) xml += "\r\n<phone>" + SecurityElement.Escape(Phone) + "</phone>";
            else if (City != null) xml += "\r\n<city>" + SecurityElement.Escape(City) + "</city>";
            else if (Url != null) xml += "\r\n<url>" + SecurityElement.Escape(Url) + "</url>";
            if (Descriptor != null) xml += "\r\n<descriptor>" + SecurityElement.Escape(Descriptor) + "</descriptor>";
            return xml;
        }
    }
}
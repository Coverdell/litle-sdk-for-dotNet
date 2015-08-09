using System.Security;

namespace Litle.Sdk.Requests
{
    public class CustomBilling
    {
        public string Phone;
        public string City;
        public string Url;
        public string Descriptor;

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
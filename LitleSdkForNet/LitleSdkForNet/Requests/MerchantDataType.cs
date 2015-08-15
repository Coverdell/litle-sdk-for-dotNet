using System.Security;

namespace Litle.Sdk.Requests
{
    public class MerchantDataType
    {
        public string Campaign { get; set; }
        public string Affiliate { get; set; }
        public string MerchantGroupingId { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Campaign != null) xml += "\r\n<campaign>" + SecurityElement.Escape(Campaign) + "</campaign>";
            if (Affiliate != null) xml += "\r\n<affiliate>" + SecurityElement.Escape(Affiliate) + "</affiliate>";
            if (MerchantGroupingId != null)
                xml += "\r\n<merchantGroupingId>" + SecurityElement.Escape(MerchantGroupingId) + "</merchantGroupingId>";
            return xml;
        }
    }
}
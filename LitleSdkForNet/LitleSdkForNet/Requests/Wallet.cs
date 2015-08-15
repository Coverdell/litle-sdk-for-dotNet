using System.Security;

namespace Litle.Sdk.Requests
{
    public class Wallet
    {
        public WalletWalletSourceType WalletSourceType { get; set; }
        public string WalletSourceTypeId { get; set; }

        public string Serialize()
        {
            var xml = "";
            xml += "\r\n<walletSourceType>" + WalletSourceType + "</walletSourceType>";
            if (WalletSourceTypeId != null)
                xml += "\r\n<walletSourceTypeId>" + SecurityElement.Escape(WalletSourceTypeId) + "</walletSourceTypeId>";
            return xml;
        }
    }
}
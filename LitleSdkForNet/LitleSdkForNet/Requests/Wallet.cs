using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("wallet")]
    public class Wallet
    {
        [XmlElement("walletSourceType")]
        public WalletWalletSourceType WalletSourceType { get; set; }
        [XmlElement("walletSourceTypeId")]
        public string WalletSourceTypeId { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
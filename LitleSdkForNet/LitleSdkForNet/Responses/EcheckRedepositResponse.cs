using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Responses
{
    [LitleXmlRoot("echeckRedepositResponse")]
    public class EcheckRedepositResponse : CommonTransactionTypeWithReportGroupAndPostDate
    {
        [XmlElement("accountUpdater")]
        public AccountUpdater AccountUpdater { get; set; }

        [XmlElement("tokenResponse")]
        public TokenResponseType TokenResponse { get; set; }
    }
}
using System.Xml.Serialization;
using Litle.Sdk.Responses;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("pos")]
    public class Pos
    {
        [XmlElement("capability", IsNullable = true)]
        public PosCapabilityTypeEnum? Capability { get; set; }
        [XmlElement("entryMode", IsNullable = true)]
        public PosEntryModeTypeEnum? EntryMode { get; set; }
        [XmlElement("cardholderId", IsNullable = true)]
        public PosCardholderIdTypeEnum? CardholderId { get; set; }
        [XmlElement("terminalId")]
        public string TerminalId { get; set; }
        [XmlElement("catLevel", IsNullable = true)]
        public PosCatLevelEnum? CatLevel { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
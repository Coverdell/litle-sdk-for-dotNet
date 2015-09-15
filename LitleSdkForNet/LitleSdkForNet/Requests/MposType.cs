using System.Xml.Serialization;
using Litle.Sdk.Xml;

namespace Litle.Sdk.Requests
{
    [LitleXmlType("mposType")]
    public class MposType
    {
        [XmlElement("ksn")]
        public string Ksn { get; set; }
        [XmlElement("formatId")]
        public string FormatId { get; set; }
        [XmlElement("encryptedTrack")]
        public string EncryptedTrack { get; set; }
        [XmlElement("track1Status")]
        public int Track1Status { get; set; }
        [XmlElement("track2Status")]
        public int Track2Status { get; set; }

        public string Serialize()
        {
            return LitleXmlSerializer.SerializeObject(this);
        }
    }
}
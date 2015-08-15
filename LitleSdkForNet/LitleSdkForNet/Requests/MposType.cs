using System.Security;

namespace Litle.Sdk.Requests
{
    public class MposType
    {
        public string Ksn { get; set; }
        public string FormatId { get; set; }
        public string EncryptedTrack { get; set; }
        public int Track1Status { get; set; }
        public int Track2Status { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Ksn != null)
            {
                xml += "\r\n<ksn>" + Ksn + "</ksn>";
            }
            if (FormatId != null)
            {
                xml += "\r\n<formatId>" + FormatId + "</formatId>";
            }
            if (EncryptedTrack != null)
            {
                xml += "\r\n<encryptedTrack>" + SecurityElement.Escape(EncryptedTrack) + "</encryptedTrack>";
            }
            if (Track1Status == 0 || Track1Status == 1)
            {
                xml += "\r\n<track1Status>" + Track1Status + "</track1Status>";
            }
            if (Track2Status == 0 || Track2Status == 1)
            {
                xml += "\r\n<track2Status>" + Track2Status + "</track2Status>";
            }

            return xml;
        }
    }
}
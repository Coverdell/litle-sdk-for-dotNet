using System.Security;

namespace Litle.Sdk.Requests
{
    public class ApplepayType
    {
        public string Data { get; set; }
        public ApplepayHeaderType Header { get; set; }
        public string Signature { get; set; }
        public string Version { get; set; }

        public string Serialize()
        {
            var xml = "";
            if (Data != null) xml += "\r\n<data>" + SecurityElement.Escape(Data) + "</data>";
            if (Header != null) xml += "\r\n<header>" + Header.Serialize() + "</header>";
            if (Signature != null) xml += "\r\n<signature>" + SecurityElement.Escape(Signature) + "</signature>";
            if (Version != null) xml += "\r\n<version>" + SecurityElement.Escape(Version) + "</version>";
            return xml;
        }
    }
}
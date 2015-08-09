using System.Security;

namespace Litle.Sdk.Requests
{
    public class ApplepayType
    {
        public string Data;
        public ApplepayHeaderType Header;
        public string Signature;
        public string Version;

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
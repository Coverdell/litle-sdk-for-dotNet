using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Requests;
using Litle.Sdk.Responses;

namespace Litle.Sdk
{
    public class LitleXmlSerializer
    {
        public virtual String SerializeObject(LitleOnlineRequest req)
        {
            var serializer = new XmlSerializer(typeof (LitleOnlineRequest));
            var ms = new MemoryStream();
            try
            {
                serializer.Serialize(ms, req);
            }
            catch (XmlException e)
            {
                throw new LitleOnlineException("Error in sending request to Litle!", e);
            }
            return Encoding.UTF8.GetString(ms.GetBuffer()); //return string is UTF8 encoded.
        } // serialize the xml

        public virtual LitleResponse DeserializeObjectFromFile(string filePath)
        {
            LitleResponse i;
            try
            {
                i = new LitleResponse(filePath);
            }
            catch (XmlException e)
            {
                throw new LitleOnlineException("Error in recieving response from Litle!", e);
            }
            return i;
        } // deserialize the object
    }
}
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Litle.Sdk.Responses;

namespace Litle.Sdk.Xml
{
    public class LitleXmlSerializer
    {
        public static string SerializeObject(object instance)
        {
            var serializer = new XmlSerializer(instance.GetType());
            var ms = new MemoryStream();
            try
            {
                serializer.Serialize(ms, instance);
            }
            catch (XmlException e)
            {
                throw new LitleOnlineException("Error in sending request to Litle!", e);
            }
            return Encoding.UTF8.GetString(ms.GetBuffer()); //return string is UTF8 encoded.
        }

        public static T DeserializeObjectFromFile<T>(string filePath)
        {
            T i;
            try
            {
                i = (T)Activator.CreateInstance(typeof(T), filePath);
            }
            catch (XmlException e)
            {
                throw new LitleOnlineException("Error in recieving response from Litle!", e);
            }
            return i;
        } // deserialize the object

        public virtual LitleResponse DeserializeObjectFromFile(string filePath)
        {
            return DeserializeObjectFromFile<LitleResponse>(filePath);
        }

        public static LitleOnlineResponse DeserializeObject(string response)
        {
            return DeserializeObject<LitleOnlineResponse>(response);
        }

        public static object DeserializeObject(Type type, string response)
        {
            var serializer = new XmlSerializer(type);
            var reader = new StringReader(response);
            return serializer.Deserialize(reader);
        } // deserialize the object
        
        public static T DeserializeObject<T>(string response)
        {
            return (T)DeserializeObject(typeof (T), response);
        }
    }
}
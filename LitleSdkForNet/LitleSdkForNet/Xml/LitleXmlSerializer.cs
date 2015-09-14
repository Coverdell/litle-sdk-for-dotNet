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
        public static string SerializeObject<T>(T instance)
        {
            var type = typeof (T);
            var serializable = new LitleXmlSerializable(type, instance);
            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    var nodeType = typeof(LitleXmlRootAttribute);
                    var attribute = Attribute.GetCustomAttribute(type, nodeType, true);
                    var rootAttribute = (XmlRootAttribute)attribute;
                    var serializableType = typeof(LitleXmlSerializable);
                    var serializer = new XmlSerializer(serializableType, rootAttribute);
                    serializer.Serialize(memoryStream, serializable);
                }
                catch (XmlException e)
                {
                    throw new LitleOnlineException("Error in sending request to Litle!", e);
                }
                var buffer = memoryStream.GetBuffer();
                return Encoding.UTF8.GetString(buffer);
            }
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
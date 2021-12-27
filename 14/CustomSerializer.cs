using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace laba14
{
    public static class CustomSerializer
    {
        public static void SerializeBinary<T>(string filePath, T Obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Obj);
            }
        }
        
        public static T DeserializeBinary<T>(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        
        public static void SerializeXml<T>(string filePath, T Obj)
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Obj);
            }
        }
        
        public static T DeserializeXml<T>(string filePath)
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        
        public static void SerializeSoap<T>(string filePath, T Obj)
        {
            var formatter = new SoapFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Obj);
            }
        }
        
        public static T DeserializeSoap<T>(string filePath)
        {
            var formatter = new SoapFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
        
        public static void SerializeJson<T>(string filePath, T Obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (var fs = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(fs))
            {
                serializer.Serialize(writer, Obj);
            }
        }
        
        public static T DeserializeJson<T>(string filePath)
        {
            var reader = new StreamReader(filePath);
            string data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
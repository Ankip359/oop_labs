using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace laba14
{
    public class Program
    {
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Year { get; set; }

            [NonSerialized] public int id;
 
            public Person(string name, int year)
            {
                Name = name;
                Year = year;
                id = new Random().Next();
            }
        }

        [Serializable]
        public class Women : Person
        {
            public string SecondName { get; set; }

            public Women(): base("san", 2000){}
            public Women(string name, string secondName, int year) : base(name, year)
            {
                SecondName = secondName;
            }
        }

        public static void WriteWoman(Women[] deserializeBinary)
        {
            foreach (var val in deserializeBinary)
            {
                Console.WriteLine($"{val.Name} {val.SecondName} {val.Year}г.");   
            }
        }
        
        public static void Main(string[] args)
        {
            const string mainPath = @"Q:\labaratornii\2 курс\ООП\lab14\";
            Women[] woman =
            {
                new Women("Sasha", "Nikolsraya", 1995),
                new Women("Liza", "Tresfc", 1998),
                new Women("Ksysha", "Ivanova", 1991)
            };
            
            CustomSerializer.SerializeBinary(mainPath+"binary", woman);
            CustomSerializer.SerializeJson(mainPath+"Json.json", woman);
            CustomSerializer.SerializeSoap(mainPath+"Soap.txt", woman);
            CustomSerializer.SerializeXml(mainPath+"Xml.xml", woman);
            
            var deserializeBinary = CustomSerializer.DeserializeBinary<Women[]>(mainPath+"binary");
            var deserializeJson = CustomSerializer.DeserializeJson<Women[]>(mainPath+"Json.json");
            var deserializeSoap = CustomSerializer.DeserializeSoap<Women[]>(mainPath+"Soap.txt");
            var deserializeXml = CustomSerializer.DeserializeXml<Women[]>(mainPath+"Xml.xml");
            
            Console.WriteLine("deserializeBinary########################################");
            WriteWoman(deserializeBinary);
            Console.WriteLine("deserializeJson########################################");
            WriteWoman(deserializeJson);
            Console.WriteLine("deserializeSoap########################################");
            WriteWoman(deserializeSoap);
            Console.WriteLine("deserializeXml########################################");
            WriteWoman(deserializeXml);
            
            
            //3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(mainPath+"Xml.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes) 
                Console.WriteLine(n.OuterXml);
            
                    
            //4
            var reader = new StreamReader(mainPath + "jsonObj.json");
            JObject rss = JObject.Parse(reader.ReadToEnd());
            JArray categories = (JArray)rss["womans"];
        }
    }
}
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SerializeAndExtentionMethodsSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Moritz",
                Alter = 19,
                Kontostand = 5_000_000,
                KreditLimit = 10_000_000
            };

            Stream stream = null;

            #region Binary-Formatter

            //SCHREIBEN
            //BinaryFormatter binary = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binary.Serialize(stream, person);
            //stream.Close();

            ////LESEN
            //stream = File.OpenRead("Person.bin");
            //Person geladenePerson = (Person)binary.Deserialize(stream);
            //stream.Close();

            #endregion

            #region XML Serialize

            //Schreiben
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            //stream = File.OpenWrite("Person.xml");
            //xmlSerializer.Serialize(stream, person);
            //stream.Close();

            ////Lesen
            //stream = File.OpenRead("Person.xml");
            //Person xmlPerson = (Person)xmlSerializer.Deserialize(stream);
            //stream.Close();
            #endregion

            #region JSON Serialize mit Newtonsoft
            string jsonString = JsonConvert.SerializeObject(person);
            File.WriteAllText("Person.json", jsonString);

            string loadedJSON = File.ReadAllText("Person.json");
            Person loadedJsonPersonObj = JsonConvert.DeserializeObject<Person>(loadedJSON);
            #endregion


            #region CSV Parser in Erweiterungs-Methoden
            person.Speichern("Person.csv");

            Person person1 = new Person();

            person1.Laden("Person.csv");
            #endregion


        }
    }

    //[Serializable]
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }
        //[field: NonSerialized] //für Binary

        [JsonIgnore]
        public decimal Kontostand { get; set; }

        //Variante 1: [NonSerialized] //für Binary 
        //[field: NonSerialized] //für Binary
        public decimal KreditLimit;
    }
}
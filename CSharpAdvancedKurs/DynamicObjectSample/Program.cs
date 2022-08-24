using System.Dynamic;

namespace DynamicObjectSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new ExpandoObject();

            myObj.Vorname = "Otto";
            myObj.Nachname = "Walkes";

            //Kein Codevervollständigung 
            //Fehleranfällig
            //Langsam


            var v = new { Amount = 108, Message = "Hello" };

            
        }
    }
}
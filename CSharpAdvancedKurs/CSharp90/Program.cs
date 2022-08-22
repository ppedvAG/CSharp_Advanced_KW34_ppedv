namespace CSharp90
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(1, "Otto", "Walkes");

            (int id, string firstname, string lastname) = person;

            Console.WriteLine($"Id = {id}, firstname = {firstname}, lastname = {lastname}");

            Club club = new(123, "96er");
            (int clubId, string clubName) = club;
        }
    }


    // Feature-Liste:
    // Dekonstruktion /
    // Init-Properties /
    // == != Operator wurde implementiert (Wertegleich) /
    // override Equals (Wertevergleich)
    // override ToString() -> Ausgabe alle Werte in einer Art JSON-Style
    // override GetHashCode() -> Prüfsummen

    public record Person (int Id, string Firstname, string Lastname); //Default der Properties ist hier 'init'




    //Feature-Liste ist kürzer
    //KEIN Dekonstruktion 
    //Init-Properties nur bei Id und Name
    //== und != ist drin
    //Equals 
    //ToString()
    //GetHashCode
    public record Club(int Id, string Name) // Properties sind hier 'init'
    {
        public DateTime Foundation { get; set; }
        public int MemberCount { get; set; }
    }


    /*  Usercase 
     *  
     * Klassen für Rückgabe eines Services = Ergebisse sind nicht verfälschbar
     * 
     * 
     * 
     * Werteobjekte gibt es in Domain Driven Design -> Die Objekt -> Value-Objects
     * Was sind Value Objects: Objekte die bei Prüfung auf den Inhalt gehen 
     * 
     * 
     * 
     * 
     * 
     */

}
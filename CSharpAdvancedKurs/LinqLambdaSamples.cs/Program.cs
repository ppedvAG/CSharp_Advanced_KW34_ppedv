namespace LinqLambdaSamples.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Person> persons = new List<Person>()
            {
                new Person {Id=1, Age=37, Vorname="Kevin", Nachname="Winter"},
                new Person {Id=2, Age=29, Vorname="Hannes", Nachname="Preishuber"},
                new Person {Id=3, Age=19, Vorname="Scott", Nachname="Hunter"},

                new Person {Id=4, Age=21, Vorname="Scott", Nachname="Hanselmann"},
                new Person {Id=5, Age=45, Vorname="Daniel", Nachname="Roth"},
                new Person {Id=6, Age=50, Vorname="Bill", Nachname="Gates"},

                new Person {Id=7, Age=70, Vorname="Newton", Nachname="King"},
                new Person {Id=8, Age=40, Vorname="Andre", Nachname="R"},
                new Person {Id=9, Age=60, Vorname="Petra", Nachname="Musterfrau"},
            };

            //Linq Statement (Linq verwendet Keywords) 
            //benötigt: using System.Linq;

            //->Beispiele -> https://github.com/dotnet/try-samples/tree/main/101-linq-samples/src
            IList<Person> personsBetween40and50 = (from p in persons
                                                   where p.Age >= 40 && p.Age <= 50
                                                   orderby p.Nachname
                                                   select p).ToList();

            //Linq - Functions mit Lambda Expressions
            //Linq-Functions und Lambda Expressions
            //benötigt: using System.Linq;

            // https://linqsamples.com/linq-to-objects
            IList<Person> perosnenBetween40and50 = persons.Where(e => e.Age >= 40 && e.Age <= 50)
                                                          .OrderBy(e => e.Age)
                                                          .ToList();

            #region Calculations

            double altersdurchschnittAllerPersonen = persons.Average(p => p.Age);

            double altersdurchschnittAllerPersonenUeber40 = persons
                                                            .Where(p => p.Age >= 40)
                                                            .Average(p => p.Age);

            int alterSum = persons.Sum(p => p.Age);
            #endregion

            #region Einzelne Datensätze ermitteln

            //FIRST + FIRSTORDEFAULT

            //Muss eine Person in der Liste vorhanden
            Person erstePersonInDerList = persons.First();
            //Wenn keine Person in Liste vorhanden ist, wird Null zurück gegeben
            Person? personOrDefault = persons.FirstOrDefault();


            //Variante A
            Person erstePersonDerPersonenUeber40ListeA = persons.First(p => p.Age > 40);
            //Variante B
            Person erstePersonDerPersonenUeber40ListeB = persons.Where(p => p.Age > 40).First();

            //LAST 
            Person letztePersonInListe = persons.Last();
            Person? letztePersonInListeA = persons.LastOrDefault();


            Person letztePersonInListe1 = persons.Last(p => p.Age > 30);
            Person letztePersonInListe2 = persons.Where(p => p.Age > 30).Last();



            //Single

            //typisch für GetById 

            Person personById = persons.Single(p => p.Id == 2);
            Person? personByIdA = persons.SingleOrDefault(p => p.Id == 20);

            #endregion

            #region Datensatzanzahl + Mengen

            //Wenn eine Liste mit Linq angesprochen wird, ist die schnellste Variante, die Anzahl der Datensätze zu ermitteln ide List.Count->Property
            int anzahlDerDatensätze = persons.Count;

            int anzahlDerDatensätzeB = persons.Count(p=>p.Age > 40);


            //Gibt es Datensätze in der Liste
            bool isAvailable = persons.Any();

            bool isAvailableB = persons.Any(p => p.Age > 100);
            #endregion


            //Paging basiert auf Linq/Lambda

            int pagingSize = 3;  //Anzahl der Elemente, die auf einer Seite angezeigt werden 
            int pagingNumber = 1;  //Auf welcher Seite befinde ich mich -> [1] 2 3 

            IList<Person> ersteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumber = 2;
            IList<Person> zweiteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();

            pagingNumber = 3;
            IList<Person> dritteSeite = persons.Skip((pagingNumber - 1) * pagingSize).Take(pagingSize).ToList();
        }
    }


    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
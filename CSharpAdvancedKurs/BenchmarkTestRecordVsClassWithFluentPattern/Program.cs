using System.Diagnostics;

namespace BenchmarkTestRecordVsClassWithFluentPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i <100000; i++)
            {
                PersonRecord p = new PersonRecord()
                .WithName("Peter")
                .WithAlter(25)
                .WithGewicht(85);
            }
            stopwatch.Stop();
            Console.WriteLine($"Benchmarkzeit bei Records: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                Person p = new Person()
                .WithName("Peter")
                .WithAlter(25)
                .WithGewicht(85);
            }
            stopwatch.Stop();
            Console.WriteLine($"Benchmarkzeit bei Klassen: {stopwatch.ElapsedMilliseconds}");

            Console.ReadLine();
        }
    }


    public record PersonRecord
    {
        public string? Name { get; init; }
        public int? Alter { get; init; }
        public int? Gewicht { get; init; }


        public PersonRecord WithName(string name)
            => this with { Name = name };
        public PersonRecord WithAlter(int alter)
            => this with { Alter = alter };
        public PersonRecord WithGewicht(int gewicht)
            => this with { Gewicht = gewicht };
    }

    public class Person
    {
        public string? Name { get; set; }
        public int? Alter { get; set; }
        public int? Gewicht { get; set; }


        public Person WithName(string name)
        {
            Name = name;
            return this;
        }
        public Person WithAlter(int alter)
        {
            Alter = alter;
            return this;
        }
        public Person WithGewicht(int gewicht)
        {
            this.Gewicht = gewicht;
            return this;
        }
    }
}
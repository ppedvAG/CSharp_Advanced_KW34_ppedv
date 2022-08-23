using System;
using System.Diagnostics;
using System.Text;

namespace StringBuilderBenchmarkDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // string hallo = "HALLO";
            //  -> [H][A][L][L][O] (String im Speicher -> hat eine feste Größe, und kann nicht dynamisch erweitert werden 

            //Im Code passiert folgende -> String wird mit + - Poerator erweitert -> hallo += " Welt";
            //Kopiert aus alten String->HALLO in den neuen Speicherbedarf rein. 

            //[H][A][L][L][O][_][W][E][L][T]


            //wie ein array 
            string aufbauenderString = string.Empty;

            string hallo = "Hallo"; 
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                aufbauenderString += i.ToString(); //Performance - Killer! 


                //1.) Erstelle neuen String-Speicherplatz mit der neuen größe
                //2.) Kopiere die alten Daten rüber in den Speicherplatz + Variable i 
            }
            stopwatch.Stop();
            long testErgebnis1 = stopwatch.ElapsedMilliseconds;


            Console.WriteLine("Taste drücken......");
            Console.ReadKey();

            StringBuilder sb = new StringBuilder();

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            for (int i = 0; i < 100000; i++)
            {
                sb.Append(i); //Strings werden mit Append hinzugefügt 
            }
            string output = sb.ToString(); //ToString() = kompletter String wird ausgelifert 
            stopwatch1.Stop();

            long testErgebnis2 = stopwatch1.ElapsedMilliseconds;

            Console.WriteLine("Benchmark Endergebnis");
            Console.WriteLine($"Ergebnis aus einfachen addieren - Zeit: {testErgebnis1}");
            Console.WriteLine($"Testergebnis - StringBuilder - Zeit: {testErgebnis2}");
            Console.ReadLine();
        }
    }
}

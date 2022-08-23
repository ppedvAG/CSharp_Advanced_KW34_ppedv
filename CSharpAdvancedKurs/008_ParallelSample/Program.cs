#nullable disable

using System.Net;
using System.Text;

namespace _008_ParallelSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = CreateWordArrayFromURL(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            
            Parallel.Invoke(() =>
            {
                //Erste Methode
                GetLongestWord(words);
            },
            () =>
            {
                ZähleWörter(words, "sleep");
            },
            () =>
            {
                GetMostCommonWords(words);
            });

            Console.ReadLine();
        }

        static string[] CreateWordArrayFromURL(string uri)
        {
            Console.WriteLine($"Callen {uri}");

            //Download des Textes
            string s = new WebClient().DownloadString(uri);

            return s.Split(
                new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                StringSplitOptions.RemoveEmptyEntries);
        }


        #region Text Analysen
        public static void GetLongestWord(string[] words)
        {
            //Linq - Statement 
            //string longestWord = (from w in words
            //                      orderby w.Length descending
            //                      select w).First();


            //Sortiere String nach der Länge -> längestes Word wird oben stehen 
            string longestWord2 = words.OrderByDescending(word => word.Length)
                                       .First();

            Console.WriteLine($"länstes Wort ist {longestWord2}");
        }

        public static void ZähleWörter(string[] words, string term)
        {
            IEnumerable<string> findWord = from word in words
                                           where word.ToUpper().Contains(term.ToUpper())
                                           select word;

            Console.WriteLine($"Das gesucht Wort {term} befindet sich {findWord.Count()}x im Text");
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            var commonWords = frequencyOrder.Take(10);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 -- The most common words are:");
            
            foreach (var v in commonWords)
            {
                sb.AppendLine("  " + v);
            }
            Console.WriteLine(sb.ToString());
        }
        #endregion
    }
}
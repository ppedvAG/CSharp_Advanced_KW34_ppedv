namespace CSharp7x
{
    internal class Program
    {
        private static Person Person { get; set; }




        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            #region ref als Return-Wert in Methoden
            int[] zahlen = { 11, 22, 33, 44, 55, 66, 10, 20 };
            ref int position = ref Zahlensuche(55, zahlen);
            position = 100_000_000;
            #endregion

            #region 7.1 -> Default
            ShowResult();
            ShowResult(0);

            #endregion
        }

        public static void ShowResult (int result = default)
        {
            if (result == default)
            {
                Console.WriteLine("Ergebnis ist Default");
            }
            Console.WriteLine(result);
        }
        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (gesuchteZahl == zahlen[i])
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        
    }
}
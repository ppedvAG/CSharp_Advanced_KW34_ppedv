namespace _008_LockSample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart param = null;

            Thread thread = null;

            for (int i = 0; i < 500; i++)
            {
                param = new ParameterizedThreadStart(MachEinKontoUpdate);
                thread = new Thread(param);
                thread.Start();
            }

            Console.WriteLine("fertig");
            Console.ReadLine();
        }


        private static void MachEinKontoUpdate(object state)
        {
            Random rnd = new Random();
            for (int i = 0; i < 5000; i++)
            {
                int auswahl = rnd.Next();
                int betrag = rnd.Next(0, 5000);

                if (auswahl % 2 == 0)
                {
                    Konto.Auszahlen(betrag);
                }
                else
                    Konto.Einzahlen(betrag);
            }
        }
    }



     public static class Konto
    {
        public static decimal Kontostand { get; set; } = 0;

        public static int TransactionId { get; set; } = 0;

        public static object lockFlag = new object();

        public static void Einzahlen(decimal betrag)
        {
            lock (lockFlag)
            {
                TransactionId++;

                Kontostand += betrag;
            Console.WriteLine($"{TransactionId} Einzahlen: {betrag} -> Kontostand {Kontostand}");
        }
    }

        public static void Auszahlen(decimal betrag)
        {
            lock (lockFlag)
            {
                TransactionId++;

                Kontostand -= betrag;
                Console.WriteLine($"{TransactionId} Einzahlen: {betrag} -> Kontostand {Kontostand}");
            }
        }
    }
}
namespace _001_Thread_Starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Threading.Thread

            //Methodenname wird übergeben -> Parameter im Konstruktor ist ein -> public delegate void ThreadStart();
            System.Threading.Thread thread = new Thread(MachEtwasInEinemThread); 

            thread.Start(); //Ab jetzt wird die Methode MachEtwasInEinemThread in einem eigenen "Thread" abgearbeitet 
            //thread.Join(); //Warte bis der Thread abgearbeitet ist 

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i  = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
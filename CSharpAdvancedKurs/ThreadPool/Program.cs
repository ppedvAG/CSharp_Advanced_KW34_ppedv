namespace ThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(Methode1);
            System.Threading.ThreadPool.QueueUserWorkItem(Methode2);
            System.Threading.ThreadPool.QueueUserWorkItem(Methode3);

            Console.ReadLine();
        }

        static void Methode1(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("#");
            }
        }

        static void Methode2(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {

                Console.WriteLine("+");
            }
        }

        static void Methode3(object state)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("%");
            }
        }
    }
}
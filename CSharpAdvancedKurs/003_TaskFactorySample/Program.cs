#nullable disable
namespace _003_Task_Factory_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variante 1
            //4.0 -> Task 
            Task task1 = new Task(MacheEtwasInEinemThread);
            task1.Start();

            Task task1a = new Task(MachEtwas, new Katze());
            task1a.Start();


            //Variante 2
            Task task2 = Task.Factory.StartNew(MacheEtwasInEinemThread); //Task wird sofort gestartet
            
            //Variante 3
            //4.5 verkürzte Schreibweise von Factory.StartNew
            Task.Run(MacheEtwasInEinemThread);

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine($"{i} *");
        }


        private static void MachEtwas(object input)
        {
            if (input is Katze katze)
            {
                
            }

            throw new ArgumentException();
        }


    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
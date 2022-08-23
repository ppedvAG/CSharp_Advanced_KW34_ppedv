namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TPL befindet sich in einem eigenen Namespace  System.Threading.Tasks

            Task task = new Task(MacheEtwasInEinemTask);
            task.Start();

            task.Wait();

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");

            Console.ReadLine();
        }


        private static void MacheEtwasInEinemTask()
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
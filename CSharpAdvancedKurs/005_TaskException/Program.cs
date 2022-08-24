#nullable disable
namespace _005_TaskException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start();
                
                t2 = Task.Factory.StartNew(MachEinenFehler2);

                t3 = Task.Run(MachEinenFehler3);

                t4 = Task.Run(MachKeinenFehler);


                //Warte auf ALLE angegebenen Tasks
                Task.WaitAll(t1, t2, t3, t4);

                //Warte bis der Erste Task fertig ist und dann weiter 
                //Task.WaitAny(t1, t2, t3, t4);




            }
            catch (AggregateException ex) //Hier bekommen wir mit, wenn die Tasks fertig sind, ob es einen Fehler innerhalb der Task gab 
            {
                foreach(Exception ex2 in ex.InnerExceptions)
                {
                    Console.WriteLine(ex2.Message);
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(ex2.ToString()); 

                    //exception.StackTrace -> Wo ist der Fehler passiert
                }
            }



            //Abfragen des Task-Status 

            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig");

            if (t3.IsCompletedSuccessfully)
                Console.WriteLine("Task 3 ist sauber durchgelaufen");

            if (t3.IsFaulted)
                Console.WriteLine("Task 3 hat einen Fehler");

            if (t3.IsCanceled)
                Console.WriteLine("Wurde beenendet -> CancellationTokenSource / CancellationToken");

            if (t4.IsCompleted)
                Console.WriteLine("Task 4 ist fertig");

            if (t4.IsFaulted)
                Console.WriteLine("Task 4 hat einen Fehler");

            if (t4.IsCompletedSuccessfully)
                Console.WriteLine("Task 4 ist sauber durchgelaufen");

            if (t4.IsCanceled)
                Console.WriteLine("Wurde beenendet -> CancellationTokenSource / CancellationToken");
        }

        private static void MachEinenFehler1()
        {
            Task.Delay(3000).Wait();
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Task.Delay(6000).Wait();
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Task.Delay(9000).Wait();
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("Einen schönen Tag");
        }
    }
}
#nullable disable
namespace _002_Task_beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, token);
                task.Start();

                Task.Delay(3000).Wait();
                cts.Cancel();
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {

            CancellationToken cancellationToken = (CancellationToken)param;

            try
            {
                while (true)
                {
                    Console.WriteLine("zzzzZZZZzzzZZZzzZZ");
                    Task.Delay(50).Wait();

                    //Wurde  cts.Cancel(); aufgerufen? 
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested(); //Best Practice
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
    }
}
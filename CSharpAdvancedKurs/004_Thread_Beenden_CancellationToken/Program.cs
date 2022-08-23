namespace _004_Thread_Beenden_CancellationToken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Seperation of Concerne (Arbeitsteilung) -> 
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token; //Reference übergeben

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas);
            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(cancellationToken);

            Thread.Sleep(3000);
            cancellationTokenSource.Cancel();
        }

        private static void MachEtwas(object param) //Übergabe des CancellationToken Objekts
        {
            try
            {
                CancellationToken cancellationToken = (CancellationToken)param;

                ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwasInEinemThread);
                Thread innerThread = new Thread(parameterizedThreadStart);



                innerThread.Start(cancellationToken);


                //10 Sekunden in der Schleife schlafend
                for (int i = 0; i < 50; i++)
                {

                    Console.WriteLine("zzzzzZZZZZzzzzzZZZZZ");
                    Thread.Sleep(200);

                    if (cancellationToken.IsCancellationRequested)
                        cancellationToken.ThrowIfCancellationRequested(); //Ich lasse hier eine OperationCanceledException entstehen

                }

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Thread wird beendet");
            }
        }

        private static void MachEtwasInEinemThread(object param)
        {
            try
            {
                CancellationToken cancellationToken = (CancellationToken)param;

                for (int i = 0; i < 5000; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested(); //kalkulierte Exception
                    }
                    Thread.Sleep(200);
                    Console.WriteLine("#");
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Zweiter Thread wird beendet: " + ex.Message);
            }
        }
    }
}
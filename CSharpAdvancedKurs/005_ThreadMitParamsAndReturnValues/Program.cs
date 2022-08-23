namespace _005_ThreadMitParamsAndReturnValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabeString = "hallo liebe teilnehmer";
            string retString;

            //Thread mit einer anonymen Methode
            Thread thread = new Thread(() =>
            {
                // Dieser Code-Block läuft in einem seperaten Thread
                retString = StringToUpper(eingabeString);
                Console.WriteLine(retString);
            });

            thread.Start(); //ausführen der anonymen Methode



            Thread thread1 = new Thread(StartMethode);
            thread1.Start();


            //Thread-Methode in einer Klasse

            ClassWithThreadAbleMethode classWithThreadMethode = new ClassWithThreadAbleMethode("hallo liebe Teilnehmer");

            Thread thread2 = new Thread(classWithThreadMethode.MethodenDieInEinemThreadLaeuft);
            thread2.Start();
            thread2.Join();
            Console.WriteLine(classWithThreadMethode.ThreadResult);
        }


        private static string StringToUpper(string param)
        {
            return param.ToUpper();
        }

        public static void StartMethode()
        {
            string retString = StringToUpper("testme");
        }
    }


    public class ClassWithThreadAbleMethode
    {
        private string threadParameter;

        public string ThreadResult { get; set; }

        public ClassWithThreadAbleMethode(string param)
        {
            threadParameter = param;
        }

        public void MethodenDieInEinemThreadLaeuft()
        {
            threadResult = "Neues Ergebnis";
        }
    }
}
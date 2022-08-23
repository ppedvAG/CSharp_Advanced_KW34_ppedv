namespace DelegateActionFuncSamples
{

    //Delegate ist ein Datentyp 


    //Delegate ohne Rückgabewert mit String Parameter -> Arbeiten mit Methoden zusammen, die ohne Rückgabe + einen String-Parameter vorweisen
    public delegate void LogDelegate(string message);

    //Delegate mit Rückgabewert 
    public delegate double CalcDelegate(double n1, double n2);




    internal class Program
    {
        static void Main(string[] args)
        {
            #region Grundlagen
            //Zuweisen eines Delgates zu einer Methode
            //Delegate kann von überall jetzt, DbLog aufrufen, weil von DBLog die Speicheradresse (Funktionszeiger) bekannt ist. 
            LogDelegate logDelegate = new LogDelegate(DbLog);


            CalcDelegate calcDelegate = new CalcDelegate(Addition);
            //Wir fügen eine weitere Methode an das calcDelegate mit dem += Operator
            calcDelegate += Subtraktion;


            //Aufrufen von Delegates
            logDelegate("Hallo Welt");


            double result = 0;
           
            foreach (Delegate item in calcDelegate.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                result = Convert.ToDouble(item.DynamicInvoke(result, new Random().Next(11)));
                Console.WriteLine($"Ergebnis nach der {item.Method} ist:  {result}");
            }

            double result2 = calcDelegate.Invoke(11, 11);
            double result3 = calcDelegate(22, 22);
            #endregion

            #region UseCase
            // Warum verwendet man Delegates
            #endregion

            #region Action und Func
            //Action kann nur Methoden die ein VOID zurückgeben
            Action<string> logAction = new Action<string>(DbLog);
            logAction("Send a message");


            //Func gibt einen Rückgabe-Wert zurück 
            Func<double, double, double> func = new Func<double, double, double>(Addition);

            result = func(11.5, 22.4);

            func += Subtraktion;


            foreach (Delegate item in func.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                result = Convert.ToDouble(item.DynamicInvoke(result, new Random().Next(11)));
                Console.WriteLine($"Ergebnis nach der {item.Method} ist:  {result}");
            }
            #endregion
        }

        static void DbLog(string msg)
            => Console.WriteLine("Log in DB");


        static double Addition(double n1, double n2)
            => n1 + n2; 

        static double Subtraktion (double n1, double n2)
            => n1 - n2;

    }
}
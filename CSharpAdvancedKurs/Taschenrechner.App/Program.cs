using System.Reflection;

namespace Taschenrechner.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //geladene DLL im Arbeitsspeicher
            Assembly geladeneDll = Assembly.LoadFrom("Taschenrechner.dll");

            //Wir selektieren MyCalc
            Type type = geladeneDll.GetType("Taschenrechner.MyCalc");

            //Adresse wird von MyCalc hinterlegt
            object tr = Activator.CreateInstance(type);

            MethodInfo methodenInfo = type.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            //Ausführen der Methode Add
            object result = methodenInfo.Invoke(tr, new object[] { 11, 33 });
            
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
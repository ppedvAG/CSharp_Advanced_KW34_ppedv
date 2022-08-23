namespace _006_ThreadWithState
{


    public delegate void MyResultDelegate(MyReturnObject myReturnObject);


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ThreadWithState threadWithState = new ThreadWithState("hallo liebe teilnehmer", 123, new MyResultDelegate(ResultCallback));

            Thread thread = new Thread(threadWithState.ThreadProc);
            Thread thread1 = new Thread(threadWithState.ThreadProc);
            thread.Start();
            thread1.Start();

            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }

        public static void ResultCallback(MyReturnObject myReturnObject )
            => Console.WriteLine($"Rückgabewert-> {myReturnObject.Text} und {myReturnObject.Zahl}");
    }







    public class MyReturnObject
    {
        public MyReturnObject()
        {

        }

        public string Text { get; set; }
        public int Zahl { get; set; }
    }



    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;
        private MyResultDelegate resultDelegate;
        private object lockFlag = new object();

        public ThreadWithState(string text, int zahl, MyResultDelegate resultDelegate)
        {
            this.myStringText = text;
            this.myNumberValue = zahl;
            this.resultDelegate = resultDelegate;
        }


        //Diese Methode läuft in einem Thread
        public void ThreadProc()
        {
            //Mach etwas wichtiges

            lock (lockFlag)
            {
                //Pseudoverarbeitung ->
                MyReturnObject myReturnObject = new MyReturnObject();
                myReturnObject.Zahl = myNumberValue * 2;
                myReturnObject.Text = myStringText.ToUpper();

                //Achtung hier verwenden wir ein Delegate-Callback

                //Gibt ein Objekt zurück
                resultDelegate(myReturnObject); // public static void ResultCallback(MyReturnObject myReturnObject) wird via callback aufgerufen
            }
        }

    }
}
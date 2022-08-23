namespace _007_ContinueWith_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sample1
            Task<string> task = Task.Run(DayTime);

            task.ContinueWith(secondTask => ShowDayTime(task.Result));
            #endregion

            Console.ReadLine();


            #region Sample2
            Task<string> ersterTask = Task.Run(DayTime);

            Task<string> zweiterTask = ersterTask.ContinueWith(mytask => StringToUpper(ersterTask.Result));

            Task dritterTask = zweiterTask.ContinueWith(myTask => ShowDayTime(zweiterTask.Result));

            dritterTask.Wait();
            #endregion

            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now; //Aktuelle Uhrzeit ermitteln wird

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }
        public static string StringToUpper(string dayTime)
          => dayTime.ToUpper();

        public static void ShowDayTime(string daytime)
            => Console.WriteLine(daytime);
    }
}
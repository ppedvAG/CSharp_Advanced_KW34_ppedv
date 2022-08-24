namespace AsyncAwaitSample
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            Task<string> taskWithResult = Task.Run(DayTime);
            taskWithResult.Wait();
            string result = taskWithResult.Result;


            string result2 = await Task.Run(DayTime);


            //Variante 2

            Task<string> taskWithResult2 = DayTimeAsync();
            taskWithResult2.Wait();

            string result3 = taskWithResult2.Result;


            string result4 = await DayTimeAsync();

        }


        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now;

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static Task<string> DayTimeAsync()
        {
            DateTime dateTime = DateTime.Now;

            string dayTimeOutput =  dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";

            return Task.FromResult(dayTimeOutput);
        }
    }
}
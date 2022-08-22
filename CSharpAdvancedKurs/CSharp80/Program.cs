
namespace CSharp80
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Form form = new Form(11, 22);

            double result = form.Berechne;

            
        }

       


            
    }

    public class Form
    {
        public int X { get; set; }
        public int  Y { get; set; }

        public Form(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Berechne
            => Math.Sqrt(X * X + Y * Y);
    }
}
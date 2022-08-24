namespace LP_SAMPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region BadCode
    public class BadKirsche
    {
        public int TageDerReife = 100;

        public string GetColor()
        {
            return "rot";
        }
    }

    public class BadErbeere : BadKirsche
    {
        public string GetColor()
        {
            return base.GetColor();
        }
    }

    #endregion

    #region Better
    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Kirsche : Fruits
    {
        public Kirsche()
        {

        }

        public override string GetColor()
        {
            return "rot";
        }
    }

    public class Erbeer : Fruits
    {
        public override string GetColor()
        {
            return "rot";
        }
    }
    #endregion
}
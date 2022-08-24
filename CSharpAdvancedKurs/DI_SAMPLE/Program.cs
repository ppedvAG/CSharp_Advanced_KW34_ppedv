namespace DI_SAMPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region BadCode


    //Programmierer A -> 5 Tage (Tag 1 bis Tag 5) 
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }

    //Programmierer B -> 3 Tage (Tag 5 bis Tag 8) 
    public class BadCarService
    {
        public void Repair (BadCar car) //feste Kopplung
        {
            //repariere Auto 
        }
    }
    #endregion




    #region Lose Kopplung mit Interfaces
    
    //Contract First Tag1
    public interface ICar
    {
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car); //Lose Kopplung 
    }

    //Programmierer A: 5 Tage -> Startet Tag 1 bis Tag 5
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }

    //Programmierer B: 3 Tage -> Startet Tag bis Tag 3
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            //repariere Auto
        }
    }

    //Dummy-Object oder Mock-Object oder Stub-Object
    public class DummyCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 2000;

    }
    #endregion  
}
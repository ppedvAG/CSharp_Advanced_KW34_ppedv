namespace ISP_SAMPLE
{
    //https://en.wikipedia.org/wiki/SOLID
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IBadVehicle
    {
        void ICanFly();
        void ICanDrive();
        void ICanSwim();
    }

    public class MulitVehicle : IBadVehicle
    {
        public void ICanDrive()
        {
            //Fahren
        }

        public void ICanFly()
        {
            //Fahren
        }

        public void ICanSwim()
        {
            //Schwimmen
        }
    }

    public class BadCarVehicle : IBadVehicle
    {
        public void ICanDrive()
        {
            //Fahren
        }


        //Implementierung wird nicht beötigt
        public void ICanFly()
        {
            throw new NotImplementedException();
        }

        //Implementierung wird nicht beötigt
        public void ICanSwim()
        {
            throw new NotImplementedException();
        }
    }



    #region Better
    public interface IFlyVehicle
    {
        void Fly();
    }

    public interface IDriveVehicle
    {
        void Drive();
    }

    public interface ISwimVehicle
    {
        void Swim();
    }

    public class MultiVehicle2 : IFlyVehicle, IDriveVehicle, ISwimVehicle
    {
        public void Drive()
        {
           
        }

        public void Fly()
        {
           
        }

        public void Swim()
        {

        }
    }

    public class AmphibischeVehicle : ISwimVehicle, IDriveVehicle
    {
        public void Drive()
        {
            
        }

        public void Swim()
        {
            
        }
    }
    #endregion
}
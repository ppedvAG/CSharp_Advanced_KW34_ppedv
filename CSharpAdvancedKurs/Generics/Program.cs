namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Was sind Generic Classes in .NET Core

            List<string> list = new List<string>();
            list.Add("Hallo");


            DataStore<string> cities = new DataStore<string>();

            cities.AddOrUpdate(0, "Hamburg");
            cities.AddOrUpdate(1, "Kiel");
            cities.AddOrUpdate(2, "Hannover");

        }
    }

    //Generische Klasse
    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
            else 
                throw new IndexOutOfRangeException();
        }

        public T GetByIndex(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];   
            else
                throw new IndexOutOfRangeException();   
        }

        //Generische Methode
        //public void GenericMethods<T2>(T2 parameter)
        //    => Console.WriteLine(parameter.ToString());
    }
}
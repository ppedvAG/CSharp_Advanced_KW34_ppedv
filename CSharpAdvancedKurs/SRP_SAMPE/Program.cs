namespace SRP_SAMPE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region BadCode

    public class BadEmployee
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public void InsertEmployeeToTable(BadEmployee employee)
        {
            //any Code
        }

        public void GenerateReport()
        {
            //any Code
        }
    }
    #endregion

    #region Bessere Variante
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    //DataAccess Layer 
    public class EmployeeRepository
    {
        public void Insert(Employee employee)
        {
            //Any Code
        }
    }

    //Generate
    public class GenerateReport
    {
        public void Generate()
        {
            //any Code
        }
    }
    #endregion
}
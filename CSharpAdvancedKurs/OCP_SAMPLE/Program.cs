namespace OCP_SAMPLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    #region Bad-Code
    public class BadReportGenerator
    {
        public string ReportType { get; set; } = string.Empty;


        public void GenerateReport(Employee em)
        {
            if (ReportType == "CR")
            {
                //Templates / 
            }
            else if (ReportType == "List10")
            {
                //Templates / Ausgabeverzeichnis
            }
            else if (ReportType == "PDF")
            {
                //PDF -> Watermark / Compressrate
            }
        }
    }
    #endregion


    public abstract class ReportGenerator
    {
        public abstract void GenerateReport(Employee em);   //abstrakte Methoden müssen überschrieben werden
    }

    //Close-Prinzip Implementiert 
    public class PDFReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            //any Code
        }

        //Compress Rate 
        //Watermarks
    }


    //Close-Prinzip Implementiert 
    public class CrystalReports : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {

        }

        //Template Vorlagen
        //Template Verzeichnis
    }


}
using System.IO;
using CARS_Case_Study.Utility;
using CARS_Case_Study.Repository;
using CARS_Case_Study.Model;
using CARS_Case_Study.Models;
using CARS_Case_Study.Service;
using CARS_Case_Study.MainFolder;


namespace CARS_Case_Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mainclass mainclass = new Mainclass();
            mainclass.start();

            //utilityclass util = new utilityclass();
            //util.getConnection();

            //IIncidentRepository incidentRepository = new IncidentRepository();
            //int rep=incidentRepository.UpdateIncidentStatus(2,"Open");
            //Console.WriteLine(rep);
        }
    }
}

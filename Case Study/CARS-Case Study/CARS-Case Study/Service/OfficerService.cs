using CARS_Case_Study.Models;
using CARS_Case_Study.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Service
{
    class OfficerService:IOfficerService
    {
        readonly IOfficerRepository _officerRepository;

        public OfficerService()
        {
            _officerRepository = new OfficerRepository();
        }

        public void GetAllOfficersForMenu()
        {
            try
            {
                List<Officer> allOfficers = _officerRepository.GetAllOfficers();
                if (allOfficers.Count == 0)
                {
                    Console.WriteLine("No officers found");
                    return;
                }
                Console.WriteLine("------------------------Listing all officers---------------------");
                foreach (Officer officer in allOfficers)
                {
                    Console.WriteLine($"Officer ID {officer.OfficerId}: {officer.FirstName} {officer.LastName}");
                }
                Console.WriteLine("----------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using CARS_Case_Study.Models;
using CARS_Case_Study.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Service
{
    class SuspectService
    {
        readonly ISuspectRepository _suspectRepository;
        readonly IIncidentService _incidentService;
        public SuspectService()
        {
            _suspectRepository = new SuspectRepository();
            _incidentService = new IncidentService();
        }
       public void AddNewSuspect()
        {
            try
            {
                Suspect suspect = new Suspect();

                Console.WriteLine("\nEnter particulars of the suspect");

                Console.WriteLine("List of Incidents:");
                _incidentService.GetIncidentsForMenu();

                Console.Write("=> Select incident ID to add suspect: ");
                suspect.IncidentId = int.Parse(Console.ReadLine());

                Console.Write("=> First name: ");
                suspect.FirstName = Console.ReadLine();

                Console.Write("=> Last name: ");
                suspect.LastName = Console.ReadLine();

                Console.Write("=> Date of Birth (yyyy-mm-dd) : ");
                suspect.DateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.Write("=> Gender: ");
                suspect.Gender = Console.ReadLine();

                while (true)
                {
                    Console.Write("=> Contact number: ");
                    suspect.PhoneNumber = long.Parse(Console.ReadLine());
                    if (suspect.PhoneNumber.ToString().Length == 10)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid phone number");
                }

                Console.Write("=> Address: ");
                suspect.Address = Console.ReadLine();

                int addsuspectStatus = _suspectRepository.AddSuspect(suspect);

                if (addsuspectStatus > 0)
                {
                    Console.WriteLine("New suspect added successfully\n");

                }
                else
                {
                    Console.WriteLine("Oops! The suspect could not be added. Please try again!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nRetry!");
            }
        }

    }
}


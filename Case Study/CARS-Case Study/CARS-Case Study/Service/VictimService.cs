using CARS_Case_Study.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Models;

namespace CARS_Case_Study.Service
{
    class VictimService: IVictimService
    {

        readonly IVictimRepository _victimRepository;
        readonly IIncidentService _incidentService;

        public VictimService(){
            _victimRepository=new VictimRepository();
            _incidentService = new IncidentService();
        }
        public void AddNewVictim()
        { 
            try
            {
                Victim victim = new Victim();

                Console.WriteLine("\nEnter particulars of the Victim");

                Console.WriteLine("List of Incidents:");
                _incidentService.GetIncidentsForMenu();

                Console.Write("=> Select incident ID to add victim: ");
                victim.IncidentId = int.Parse(Console.ReadLine());

                Console.Write("=> First name: ");
                victim.FirstName = Console.ReadLine();

                Console.Write("=> Last name: ");
                victim.LastName = Console.ReadLine();

                Console.Write("=> Date of Birth (yyyy-mm-dd) : ");
                victim.DateOfBirth = DateTime.Parse(Console.ReadLine());

                Console.Write("=> Gender: ");
                victim.Gender = Console.ReadLine();

                while (true)
                {
                    Console.Write("=> Contact number: ");
                    victim.PhoneNumber = long.Parse(Console.ReadLine());
                    if (victim.PhoneNumber.ToString().Length == 10)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid phone number");
                }

                Console.Write("=> Address: ");
                victim.Address = Console.ReadLine();

                int addVictimStatus = _victimRepository.AddVictim(victim);

                if (addVictimStatus > 0)
                {
                    Console.WriteLine("New victim added successfully\n");
                }
                else
                {
                    Console.WriteLine("Oops! The victim could not be added. Please try again!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nRetry!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Model;
using CARS_Case_Study.Models;
using CARS_Case_Study.Repository;

namespace CARS_Case_Study.Service
{
    class AgencyService:IAgencyService
    {
        readonly IAgencyRepository _agencyRepository;
        public AgencyService()
        {
            _agencyRepository = new AgencyRepository();
        }
        public void GetAllAgents()
        {
            List<Agency> agencies = new List<Agency>();
            agencies = _agencyRepository.GetAllAgencies();
            if (agencies.Count == 0)
            {
                Console.WriteLine("No Agencies Found");
            }
            else
            {
                foreach(var agency in agencies)
                {
                    Console.WriteLine(agency);
                }
            }

        }
        public void GetAgentsIdAndName()
        {
            List<Agency> AgencyIdandName = new List<Agency>();
            AgencyIdandName = _agencyRepository.GetAllAgencies();
            if (AgencyIdandName.Count == 0)
            {
                Console.WriteLine("No Agencies Found");
            }
            else
            {
                foreach (var agency in AgencyIdandName)
                {
                    Console.WriteLine(agency);
                }
            }
        }
        public void AddNewAgency()
        {
            try
            {
                Agency agency = new Agency();

                Console.WriteLine("\nEnter details of the Agency");

                Console.Write("=> Name of the agency: ");
                agency.AgencyName = Console.ReadLine();

                Console.Write("=> Jurisdiction: ");
                agency.Jurisdiction = Console.ReadLine();

                while (true)
                {
                    Console.Write("=> Contact number: ");
                    agency.PhoneNumber = long.Parse(Console.ReadLine());
                    if (agency.PhoneNumber.ToString().Length == 10)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid phone number");
                }

                Console.Write("=> Address: ");
                agency.Address = Console.ReadLine();

                int addAgencyStatus = _agencyRepository.AddAgency(agency);

                if (addAgencyStatus > 0)
                {
                    Console.WriteLine("New agency registered successfully\n");
                }
                else
                {
                    Console.WriteLine("Oops! The agency could not be registered. Please try again!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nRetry!");
            }
        }
    }
    }

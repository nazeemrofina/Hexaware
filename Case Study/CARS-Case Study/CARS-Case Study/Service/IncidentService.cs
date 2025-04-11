using CARS_Case_Study.Models;
using CARS_Case_Study.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.ExceptionClass;

namespace CARS_Case_Study.Service
{
    class IncidentService:IIncidentService
    {
        readonly IIncidentRepository _incidentRepository;
        readonly IAgencyService _agencyService;
        readonly IEvidenceRepository _evidenceRepository;
        readonly IVictimRepository _victimRepository;
        readonly ISuspectRepository _suspectRepository;
        public IncidentService()
        {
            _incidentRepository = new IncidentRepository();
            _agencyService = new AgencyService();
            _evidenceRepository = new EvidenceRepository();
            _suspectRepository = new SuspectRepository();
            _victimRepository = new VictimRepository();
        }
        public void GetAllIncidents()
        {
            try
            {
                List<Incident> incidents = new List<Incident>();
                incidents = _incidentRepository.GetAllIncidents();
                if (incidents.Count == 0)
                {
                    Console.WriteLine("No Incidents Found");
                    return;
                }
                    Console.WriteLine("---------------------Listing all incidents-----------------------");
                    foreach (Incident incident in incidents)
                    {
                        Console.WriteLine(incident);
                    }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetIncidentsForMenu() {
            try
            {
                List<Incident> allIncidents = _incidentRepository.GetAllIncidents();
                if (allIncidents.Count == 0)
                {
                    Console.WriteLine("No incidents found");
                    return;
                }
                Console.WriteLine("----------------------------------------------------\nListing all incidents");
                Console.WriteLine();
                foreach (Incident incident in allIncidents)
                {
                    Console.WriteLine($"Incident ID {incident.IncidentId}: {incident.IncidentType}, {incident.Location}, {incident.IncidentDate}");
                }
                Console.WriteLine("----------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddNewIncident() 
        {

            try
            {
                Incident incident = new Incident();

                Console.WriteLine("\nEnter particulars of the Incident");

                Console.Write("=> Incident type (Robbery/Homicide/Theft): ");
                incident.IncidentType = Console.ReadLine();

                Console.Write("=> Incident date and time (yyyy-mm-dd): ");
                incident.IncidentDate = DateTime.Parse(Console.ReadLine());

                Console.Write("=> Location: ");
                incident.Location = Console.ReadLine();

                Console.Write("=> Description: ");
                incident.Description = Console.ReadLine();

                Console.WriteLine("List of Agencies:");
                _agencyService.GetAgentsIdAndName();

                Console.Write("=> Enter respective Agency's ID: ");
                incident.AgencyId = int.Parse(Console.ReadLine());

                int addIncidentStatus = _incidentRepository.AddIncident(incident);

                //Console.WriteLine(addIncidentStatus);
                if (addIncidentStatus > 0)
                {
                    Console.WriteLine("New incident registered successfully\n");
                    int moreInfoChoice = 0;
                    do
                    {
                        Console.Write("Would you like to add any of the following?\n\t1.Evidence\t2.Victim\t3.Suspect\t4.Go back to main menu\nEnter your choice: ");
                        moreInfoChoice = int.Parse(Console.ReadLine());
                        switch (moreInfoChoice)
                        {
                            case 1:
                                try
                                {
                                    Evidence evidence = new Evidence();

                                    Console.WriteLine("\nEnter particulars of the Evidence");

                                    evidence.IncidentId = addIncidentStatus;

                                    Console.Write("=> Evidence description: ");
                                    evidence.Description = Console.ReadLine();

                                    Console.Write("=> Location where evidence is found: ");
                                    evidence.LocationFound = Console.ReadLine();

                                    int addEvidenceStatus = _evidenceRepository.AddEvidence(evidence);

                                    if (addEvidenceStatus > 0)
                                    {
                                        Console.WriteLine("New evidence added successfully\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Oops! The evidence could not be added. Please try again!\n");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message + "\nRetry!");
                                }
                                break;

                            case 2:
                                try
                                {
                                    Victim victim = new Victim();

                                    Console.WriteLine("\nEnter particulars of the Victim");

                                    victim.IncidentId = addIncidentStatus;

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
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid phone number");
                                        Console.ResetColor();
                                    }

                                    Console.Write("=> Address: ");
                                    victim.Address = Console.ReadLine();
                                  //  Console.Write("=> Victim Status: ");
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
                                break;

                            case 3:
                                try
                                {
                                    Suspect suspect = new Suspect();

                                    Console.WriteLine("\nEnter particulars of the suspect");

                                    suspect.IncidentId = addIncidentStatus;

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
                                break;

                            case 4:
                                Console.WriteLine("Navigating to main menu...");
                                break;

                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (moreInfoChoice != 4);
                 //   return addIncidentStatus;
                }
                else
                {
                    Console.WriteLine("Oops! The incident could not be registered. Please try again!\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nRetry!");
            }
          //  return 0;
        }
        public void UpdateIncidentStatus()
        {
            
                try
                {
                    Console.Write(" Enter Incident ID: ");
                    int incidentId = int.Parse(Console.ReadLine());

                    if (_incidentRepository.GetIncidentById(incidentId) == -1)
                    {
                          throw (new IncidentNumberNotFoundException($"Incident with ID {incidentId} does not exists!"));
                    }

                    Console.WriteLine("Select the status: Open - 1, Closed - 2, Under Investigation - 3");
                    Console.Write("=> Choose status: ");
                    int statusChoice = int.Parse(Console.ReadLine());

                    if (statusChoice != 1 && statusChoice != 2 && statusChoice != 3)
                    {
                        Console.WriteLine("Invalid status choice");
                        return;
                    }

                    string status = (statusChoice == 1) ? "Open" : (statusChoice == 2) ? "Closed" : "Under Investigation";

                    int updateIncidentStatus = _incidentRepository.UpdateIncidentStatus(incidentId, status);

                    if (updateIncidentStatus > 0)
                    {
                        Console.WriteLine($"Status for Incident {incidentId} is updated to {status}");
                    }
                    else
                    {
                        Console.WriteLine("Oops! The incident status could not be updated. Please try again!");
                    }
                }
            catch (IncidentNumberNotFoundException e)
            {
                Console.WriteLine(e.Message + "\nRetry!");
                Console.ResetColor();
            }
            catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nRetry!");
                }
            }
        
        public void GetIncidentInDateRange() {

            try
            {
                Console.Write("\n=> Enter start date (yyyy-mm-dd): ");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.Write("=> Enter end date (yyyy-mm-dd): ");
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                List<Incident> allIncidents = _incidentRepository.GetIncidentInDateRange(startDate, endDate);
                if (allIncidents.Count == 0)
                {
                    Console.WriteLine("No incidents found");
                    return;
                }
                Console.WriteLine("------------------Listing all incidents-------------------------");
                foreach (Incident incident in allIncidents)
                {
                    Console.WriteLine(incident);
                }
                Console.WriteLine("-----------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nRetry!");
            }
        }
        public void GetIncidentByType() {
            try
            {
                Console.Write("\nChoose Incident Type:\n\t1. Robbery\n\t2. Homicide\n\t3. Theft\n=> Enter your choice: ");
                int incidentTypeChoice = int.Parse(Console.ReadLine());

                if (incidentTypeChoice != 1 && incidentTypeChoice != 2 && incidentTypeChoice != 3)
                {
                    Console.WriteLine("Invalid incident type choice!");
                    return;
                }

                string incidentType = (incidentTypeChoice == 1) ? "Robbery" : (incidentTypeChoice == 2) ? "Homicide" : "Theft";

                List<Incident> allIncidentsByType = _incidentRepository.GetIncidentsByType(incidentType);


                Console.WriteLine("-----------------------Listing all incidents--------------------------");
                foreach (Incident incident in allIncidentsByType)
                {
                    Console.WriteLine(incident);
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

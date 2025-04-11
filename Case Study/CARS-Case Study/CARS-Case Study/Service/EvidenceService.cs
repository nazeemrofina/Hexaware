using CARS_Case_Study.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Models;

namespace CARS_Case_Study.Service
{
    class EvidenceService:IEvidenceService
    {
        readonly IEvidenceRepository _evidenceRepository;
        readonly IIncidentService _incidentService;

        public EvidenceService()
        {
            _evidenceRepository = new EvidenceRepository();
            _incidentService = new IncidentService();
        }
        public void GetEvidencesByIncidentId()
        {
            try
            {
                Console.Write("Enter Incident ID: ");
                int incidentId = int.Parse(Console.ReadLine());
                List<Evidence> allEvidences = _evidenceRepository.GetEvidencesByIncidentId(incidentId);
                if (allEvidences.Count == 0)
                {
                    Console.WriteLine("No evidences found");
                    return;
                }
                Console.WriteLine("-------------------Listing all evidences---------------------------");
                foreach (Evidence evidence in allEvidences)
                {
                    Console.WriteLine(evidence);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddNewEvidence()
        {
            try
            {
                Evidence evidence = new Evidence();

                Console.WriteLine("\nEnter particulars of the Evidence");

                Console.WriteLine("List of Incidents:");
                _incidentService.GetIncidentsForMenu();

                Console.Write("=> Select incident ID to add evidence: ");
                evidence.IncidentId = int.Parse(Console.ReadLine());

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
        }
    }
}

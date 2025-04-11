using CARS_Case_Study.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.MainFolder
{
    class Mainclass
    {
        public void start()
        {
            IncidentService incidentService = new IncidentService();
            CaseReportService caseReportService = new CaseReportService();
            EvidenceService evidenceService = new EvidenceService();
            VictimService victimService = new VictimService();
            ReportService reportService = new ReportService();
            SuspectService suspectService = new SuspectService();
            int officerMenuChoice = 0;
            do
            {

                Console.WriteLine("Welcome Officer!");
                Console.Write("\nMain menu:\n" +
                    "\t------- Incidents -------\n" +
                    "\t1. Get all incidents\n" +
                    "\t2. Register new incident\n" +
                    "\t3. Update incident status\n" +
                    "\t4. Get incident in date range\n" +
                    "\t5. Filter incidents by type\n" +
                    "\n\t------- Cases -------\n" +
                    "\t6. Report a new case\n" +
                    "\t7. Get specific case details\n" +
                    "\t8. Update case details\n" +
                    "\t9. Get all case reports\n" +
                    "\n\t------- Others -------\n" +
                    "\t10. Add a new evidence\n" +
                    "\t11. Add a new victim\n" +
                    "\t12. Add a new suspect\n" +
                    "\t13. Logout\n" +
                    "\nEnter your choice: ");
                officerMenuChoice = int.Parse(Console.ReadLine());

                switch (officerMenuChoice)
                {
                    case 1:
                        incidentService.GetAllIncidents();
                        break;

                    case 2:
                        incidentService.AddNewIncident();
                        break;

                    case 3:
                        incidentService.UpdateIncidentStatus();
                        break;

                    case 4:
                        incidentService.GetIncidentInDateRange();
                        break;

                    case 5:
                        incidentService.GetIncidentByType();
                        break;

                    case 6:
                        reportService.AddNewReport();
                        break;

                    case 7:
                        caseReportService.GetCaseReportById();
                        break;

                    case 8:
                        reportService.UpdateReport();
                        break;

                    case 9:
                        caseReportService.GetAllCaseReports();
                        break;

                    case 10:
                        evidenceService.AddNewEvidence();
                        break;

                    case 11:
                        victimService.AddNewVictim();
                        break;

                    case 12:
                        suspectService.AddNewSuspect();
                        break;

                    case 13:
                        Console.WriteLine("Logging out...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                Console.WriteLine();
            } while (officerMenuChoice != 13);


        }
    }
}
      

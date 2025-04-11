using NUnit.Framework.Legacy;
using CARS_Case_Study.Models;
using CARS_Case_Study.Repository;
using CARS_Case_Study.Utility;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Web;
using System.Data.SqlClient;


namespace CARS_Case_Study.Tests
{
    public class Tests
    {
        IIncidentRepository incidentRepository = new IncidentRepository();
        

        [Test]
        public void TestToAddIncident()
        {
               // con.Open();
                Incident incident = new Incident()
                {
                    IncidentType = "Homicide",
                    IncidentDate = DateTime.Now,
                    Location = "Test location",
                    Description = "Test description",
                   // Status = "open",
                    AgencyId = 1
                };
                int addIncidentStatus = incidentRepository.AddIncident(incident);
                ClassicAssert.IsTrue(addIncidentStatus > 0);
            
            }

        [Test]
        public void TestToUpdateIncident()
        {
            int incidentId = 2;
            string status = "Closed";
            int updateIncidentStatus = incidentRepository.UpdateIncidentStatus(incidentId, status);
            Assert.That(updateIncidentStatus, Is.EqualTo(1));
        }
    }
}
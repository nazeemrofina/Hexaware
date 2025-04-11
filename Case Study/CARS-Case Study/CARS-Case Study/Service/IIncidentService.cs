using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Service
{
    interface IIncidentService
    {
        void GetAllIncidents();
        void GetIncidentsForMenu();
        void AddNewIncident();
        void UpdateIncidentStatus();
        void GetIncidentInDateRange();
        void GetIncidentByType();
    }
}

﻿using CARS_Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Repository
{
    public interface IIncidentRepository
    {
        List<Incident> GetAllIncidents();
        int GetIncidentById(int incidentId);
        int AddIncident(Incident incident);
        int UpdateIncidentStatus(int incidentId, string status);
        List<Incident> GetIncidentInDateRange(DateTime startDate, DateTime endDate);
        List<Incident> GetIncidentsByType(string incidentType);
        Incident GetIncidentForCaseReport(int incidentId);
    }
}

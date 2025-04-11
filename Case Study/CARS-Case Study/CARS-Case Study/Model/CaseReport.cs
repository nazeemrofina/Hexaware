using CARS_Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Model
{
    class CaseReport
    {
        Incident _incidentDetails;
        List<Evidence> _evidenceDetails;
        List<Suspect> _suspectDetails;
        List<Victim> _victimDetails;
        Agency _agencyDetails;
        Officer _officerDetails;
        Report _reportDetails;

        public Incident IncidentDetails
        {
            get { return _incidentDetails; }
            set { _incidentDetails = value; }
        }

        public Report ReportDetails
        {
            get { return _reportDetails; }
            set { _reportDetails = value; }
        }

        public Agency AgencyDetails
        {
            get { return _agencyDetails; }
            set { _agencyDetails = value; }
        }

        public Officer OfficerDetails
        {
            get { return _officerDetails; }
            set { _officerDetails = value; }
        }

        public List<Evidence> EvidenceDetails
        {
            get { return _evidenceDetails; }
            set { _evidenceDetails = value; }
        }

        public List<Victim> VictimDetails
        {
            get { return _victimDetails; }
            set { _victimDetails = value; }
        }

        public List<Suspect> SuspectDetails
        {
            get { return _suspectDetails; }
            set { _suspectDetails = value; }
        }
    }
}

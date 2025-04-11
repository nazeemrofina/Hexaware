using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Models;

namespace CARS_Case_Study.Repository
{
    internal interface IEvidenceRepository
    {
        List<Evidence> GetEvidencesByIncidentId(int incidentId);
        int AddEvidence(Evidence evidence);
    }
}

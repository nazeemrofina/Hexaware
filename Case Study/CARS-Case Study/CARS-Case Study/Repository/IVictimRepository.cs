using CARS_Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Repository
{
    internal interface IVictimRepository
    {
        List<Victim> GetVictimsByIncidentId(int incidentId);
        int AddVictim(Victim victim);
    }
}

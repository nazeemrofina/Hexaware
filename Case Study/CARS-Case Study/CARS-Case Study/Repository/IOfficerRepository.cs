using CARS_Case_Study.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Repository
{
    internal interface IOfficerRepository
    {
        List<Officer> GetAllOfficers();
        int AddOfficer(Officer officer);
        Officer GetOfficerById(int officerId);
        int OfficerLogin(string email, string password, string role);
    }
}

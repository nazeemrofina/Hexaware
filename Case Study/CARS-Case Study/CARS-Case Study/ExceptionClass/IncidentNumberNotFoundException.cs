using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.ExceptionClass
{
   
        public class IncidentNumberNotFoundException:Exception
        {
           public  IncidentNumberNotFoundException(string msg) : base(msg){} 
        }
    }


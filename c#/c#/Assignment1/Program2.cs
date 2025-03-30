using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


//2.Write a C# Sharp program to check whether a given number is positive or negative. 

//Test Data : 14
//Expected Output :
//14 is a positive number

namespace Assignment
{
     class Program2
    {
        public  void Checks()
        {
            int  a = Convert.ToInt32(Console.ReadLine());
            if (a > 0)
            {
                Console.WriteLine("{a}: is positive");
              }
            else
                Console.WriteLine("A is negative");
        }
    }
}

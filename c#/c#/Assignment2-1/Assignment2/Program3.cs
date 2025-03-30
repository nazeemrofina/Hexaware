using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

//Test Data / input: 2

//Expected Output :
//Tuesday
namespace Assignment2
{
    class Program3
    {
        public static void pro3() {
            Console.WriteLine("Enter number");
         int num=Convert.ToInt32(Console.ReadLine());
            
            switch (num){ 
                case 1:
                    Console.WriteLine("Sunday");
                break;
                case 2:
                    Console.WriteLine("Monday");
                break;
                case 3:
                    Console.WriteLine("Tuesday");
                break;
                case 4:
                    Console.WriteLine("Wednesday");
                break;
                case 5:
                    Console.WriteLine("Thursday");
                    break;
                case 6:
                    Console.WriteLine("Friday");
                    break;
                case 7:
                    Console.WriteLine("Saturday");
                    break;




            }
    }
    }
}

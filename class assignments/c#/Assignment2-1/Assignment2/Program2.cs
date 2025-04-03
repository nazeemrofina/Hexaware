using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//2.Write a C# program that takes a number as input and displays it four times in a row
//(separated by blank spaces), and then four times in the next row, with no separation.
//You should do it twice: Use the console. Write and use {0}.

//Test Data:
//Enter a digit: 25

//Expected Output:
//25 25 25 25
//25252525
//25 25 25 25
//25252525
namespace Assignment2
{
    class Program2
    {
       public static void pro2()
        {
            Console.WriteLine("Enter the number:");
            int num = Convert.ToInt32(Console.ReadLine());
            spacefunc(num);
            nospace(num);
            spacefunc(num);
            nospace(num);
        }
        static void spacefunc(int num)
        {
            Console.WriteLine("{0} {1} {2} {3}", num, num, num, num);
        }
        static void nospace(int num)
        {
            Console.WriteLine("{0}{1}{2}{3}", num, num, num, num);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//5.Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.
namespace Assignment
{
    class Program5
    {
        public static void Main()
        {
            Console.WriteLine("Enter First number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;
            if (num1 == num2)
            {
                Console.WriteLine("The answer is "+ sum * 3);
            }
            else
            {
                Console.WriteLine("The answer is " + sum);
            }
        }
    }
}

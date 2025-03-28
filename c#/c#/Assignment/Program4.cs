using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//4.Write a C# Sharp program that prints the multiplication table of a number as input.

//Test Data:
//Enter the number: 5
//Expected Output:
//5 * 0 = 0
//5 * 1 = 5
//5 * 2 = 10
//5 * 3 = 15....5 * 10 = 50
namespace Assignment
{
    class Program4
    {
        public static void Pro4()
        {
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= 10; i++)
            {
                int ans = i * number;
                Console.WriteLine(number + $" * {i} = {ans}");
            }
        }
    }
}

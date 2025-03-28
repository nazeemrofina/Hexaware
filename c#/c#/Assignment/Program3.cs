using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation. 

//Test Data
//Input first number: 20
//Input operation: -
//Input second number: 12
//Expected Output :
//20 - 12 = 8
namespace Assignment
{
    class Program3
    {
        public static void Pro3() 
        {
            Console.WriteLine("Input First Number ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Operation");
            char myop = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Input Second Number ");
            int b = Convert.ToInt32(Console.ReadLine());
            int c = 0;

            switch(myop)
            {
                case '+':
                    c = a + b;
                    Console.WriteLine($"Expected output= {a} + {b} = {c}" );
                    break;
                case '-':
                    c = a - b;
                    Console.WriteLine($"Expected output= {a} - {b} = {c}");
                    break;
                case '*':
                    c = a * b;
                    Console.WriteLine($"Expected output= {a} * {b} = {c}");
                    break;
                case '/':
                    c = a / b;
                    Console.WriteLine($"Expected output= {a} / {b} = {c}");
                    break;

            }
                    }
}
}


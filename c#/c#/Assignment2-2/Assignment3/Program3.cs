using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)

namespace Assignment3
{
    class Program3
    {
        public static void pro3()
        {
            Console.WriteLine("Enter a number ");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] array1 = new int[num];
            int[] array2 = new int[array1.Length];
            for (int i = 0; i < num; i++)
            {
                array1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The element in second array ");
            for (int i = 0; i < num; i++)
            {
                 array2[i]= array1[i];
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(array2[i]);
            }
        }
    }
}

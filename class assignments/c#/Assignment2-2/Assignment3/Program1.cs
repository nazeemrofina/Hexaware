using System.ComponentModel;

namespace Assignment3
{

    //1.    Write a  Program to assign integer values to an array  and then print the following
    //a.Average value of Array elements

    //b.Minimum and Maximum value in an array
    internal class Program1
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the number:");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            // Console.WriteLine(arr);
            for (int i = 0; i < num; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Program2.pro2();
            Program3.pro3();
        }
    }
}

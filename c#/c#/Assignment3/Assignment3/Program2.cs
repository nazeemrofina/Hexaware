using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//2.Write a program in C# to accept ten marks and display the following
//	a.	Total
//	b.	Average
//	c.	Minimum marks
//	d.	Maximum marks
//	e.	Display marks in ascending order
//	f.	Display marks in descending order

namespace Assignment3
{
    class Program2
    {
        public static void pro2()
        {
            Console.WriteLine("Enter the total number of subject");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] marks = new int[num];
            int tot = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < num; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
                tot = tot + marks[i];
                if (min > marks[i])
                {
                    min = marks[i];
                }
                if (max < marks[i])
                {
                    max = marks[i];
                }
            }
            float avg = (float)tot / (float)num;


            Console.WriteLine("The Total of all marks is " + tot);
            Console.WriteLine("The average of all marks is " + avg);
            Console.WriteLine("The Minimum of all marks is " + min);
            Console.WriteLine("The Maximum of all marks is " + max);
           

            AscOrder(marks, num);
            Console.WriteLine();
            DescOrder(marks, num);
            Console.WriteLine();
            Console.ReadKey();



        }
        public static void AscOrder(int[] marks, int num)
        {
            for (int i = 0; i < num - 1; i++)
            {
                for (int j = 0; j < num - 1; j++)
                {
                    if (marks[j] > marks[j + 1])
                    {
                        int temp = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("The ASCENDING ORDER : ");
            for (int i = 0; i < num; i++)
            {
                Console.Write(marks[i] + " ");
            }
            

        }
    
     public static void DescOrder(int[] marks, int num)
        {
            for (int i = 0; i < num - 1; i++)
            {
                for (int j = 0; j < num - 1; j++)
                {
                    if (marks[j] < marks[j + 1])
                    {
                        int temp = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("The DESCENDING ORDER : ");
            for (int i = 0; i < num; i++)
            {
                Console.Write(marks[i] + " ");
            }

        }
    }
}

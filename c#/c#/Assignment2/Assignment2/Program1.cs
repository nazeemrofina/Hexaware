namespace Assignment2
{

    //1. Write a C# Sharp program to swap two numbers.
    internal class Program1
    {
        static void Main(string[] args)
        {
            Program2.pro2();
            Program3.pro3();
            Console.WriteLine("Enter number 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numbers before swapped");
            Console.WriteLine($"number 1-{num1}");
            Console.WriteLine($"number 2-{num2}");
            swap(num1, num2);
        }
        static void swap(int num1,int num2)
        {
             num1 = num1 + num2;
             num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("Numbers after swapped");
            Console.WriteLine($"number 1-{num1}");
            Console.WriteLine($"number 2-{num2}");

        }
    }
}

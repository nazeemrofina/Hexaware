namespace Assignment
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Program2 prg = new Program2();
            prg.Checks();
            Program3.Pro3();
            Console.WriteLine("Enter a number a and b:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine("YES BOTH ARE SAME");
            }
            else
            {
                Console.WriteLine($"{a} NO THEY ARE DIFFERENT NUMBERS");
            }

            Program4.Pro4();
            Program5.Pro5();
        }
    }
}

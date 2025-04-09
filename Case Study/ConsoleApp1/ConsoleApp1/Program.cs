namespace ConsoleApp1
{
   
        class Customer
        {
            public Customer()
            {
                Console.WriteLine("Customer Construction 1 ...");
            }

            public Customer(int a) : this()
            {
                Console.WriteLine("Customer Construction 2 .....");
            }

            public Customer(string s, int a) : this(a)
            {
                Console.WriteLine("Customer Construction 3 ....");
            }

        }

        //understanding Composition
    
        internal class ConstructorChaining
        {
            public static void Main()
            {
                 Customer customer = new Customer("CSharp", 10);
               
            }
        }

    }



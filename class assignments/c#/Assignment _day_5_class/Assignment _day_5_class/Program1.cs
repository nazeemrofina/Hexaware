namespace Assignment__day_5_class
{


    //    2. Abstract Class :

    //A furniture manufacturing company, takes specifications from their customers and builds the furniture.
    //The company wants to computerize the order processing system. They will accept values for the items like Chair, Bookshelf etc.
    //You have to develop the hierarchy of these items


    internal class Program1
    {
        static void Main(string[] args)
        {
            orderSofa ods1 = new orderSofa();
            String name=ods1.Product();
            int length=ods1.Length();
            int height=ods1.Height();
            int no=ods1.no_of_compartments(name);
            Console.WriteLine("The product is " +name);
            Console.WriteLine("The Length of the Product is " + length);
            Console.WriteLine("The Height of the Product is " + height);
            Console.WriteLine("The no of compartment is " + no);

        }

    }
    abstract class OrderDetails
    {
        public abstract String? Product();
        public abstract int Height();
        public abstract int Length();
    }

    class Orders : OrderDetails
    {

        public override string Product()
        {
            Console.WriteLine("Name of the product");
            String? name = Console.ReadLine();
            return name;
        }
        public override int Height()
        {
            Console.WriteLine("Height of the product");
            int Height = int.Parse(Console.ReadLine());
            return Height;
        }
        public override int Length()
        {
            Console.WriteLine("Length of the product");
            int Length = int.Parse(Console.ReadLine());
            return Length;
        }
        public virtual int no_of_compartments(string name)
        {
            return 0;
        }

    }
    class orderSofa : Orders
    {



        public override int no_of_compartments(string name)
        {
            int numofcomp = 0;
            if ((name) != "Sofa")
            {
                Console.WriteLine("No of Compartments: ");
                numofcomp = int.Parse(Console.ReadLine());
                return numofcomp;
            }
            return 0;
        }

    }
}


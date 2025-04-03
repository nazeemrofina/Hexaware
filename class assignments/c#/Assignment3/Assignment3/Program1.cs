//using System.Security.Cryptography.X509Certificates;

//namespace Assignment3
//{
//    internal class Program1
//    {
//        static void Main(string[] args)
//        {

//            Manager mgr = new Manager(100000, 5000, 2000);
//            mgr.showdetails();
//            Manager mgr2 = new Manager(10000, 0, 0);
//            mgr2.showdetails();


//        }
//    }
//    class Employee
//    {
//        protected int id;
//        protected string? Name;
//        protected string? Dob;
//        protected float salary;

//        public Employee(int a)
//        {

//            salary = a;
//            getdetails();
//        }
//        public void getdetails()
//        {
//            Console.WriteLine("Enter Id:");
//            id = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Enter Name:");
//            Name = Convert.ToString(Console.ReadLine());
//            Console.WriteLine("Enter Dob:");
//            Dob = Convert.ToString(Console.ReadLine());
//            // Console.WriteLine("Enter Salary:");
//            // salary =Convert.ToSingle(Console.ReadLine());



//        }

//        public virtual float TotalSalary()
//        {
//            return salary;
//        }
//        public virtual void showdetails()
//        {
//            Console.WriteLine("ID : " + id + " Name : " + Name + " DOB :  " + Dob + " Salary : " + salary);
//        }
//    }
//    class Manager : Employee
//    {
//        public float OnSiteAllowance;
//        public float Bonus;

//        public Manager(int a, int b, int c) : base(a)
//        {

//            OnSiteAllowance = b;
//            Bonus = c;
//            base.showdetails();

//        }

//        public override float TotalSalary()
//        {
//            return OnSiteAllowance + Bonus + salary;
//        }
//        public override void showdetails()
//        {
//            Console.WriteLine("Onsiteallowance : " + OnSiteAllowance + " Bonus : " + Bonus +" Total Salary  "+TotalSalary());
//        }

//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


////1.Create an Interface IStudent with StudentId, Name and Fees as Properties, void ShowDetails() as its method.
////Create 2 classes Dayscholar and Resident that implements the interface Properties and Methods.
////(Fees for day scholar will be different from resident)
//// resident student will also have accommodation fees

//namespace Assignment3
//{
//    class Program3
//    {
//        static void Main(string[] args)
//        {
//            Dayscholar ds = new Dayscholar();
//            ds.Name = "Rofina";
//            ds.StudentId = 56;
//            ds.Fees = 40000;
//            ds.ShowDetails();
//            Resident rs = new Resident();
//            rs.Name = "Sabeena";
//            rs.StudentId = 28;
//            rs.Fees = 3000;
//            rs.ShowDetails();
//            rs.accomodation = 10000;
//        }
//    }
//    interface IStudent
//    {
//        int StudentId { get; set; }
//        String ? Name { get; set; }
//        int Fees { get; set; }
//        void ShowDetails();
       

//    }
//    class Dayscholar : IStudent
//    {
//        public int StudentId { get; set; }
//        public String ? Name { get; set; }
//        public int Fees { get; set; }
//        public void ShowDetails()
//        {
//            Console.WriteLine("Student ID "+StudentId);
//            Console.WriteLine("Name "+Name);
//            Console.WriteLine("Fees "+Fees);

//        }
//    }
//    class Resident : IStudent
//    {
//        public int StudentId { get; set; }
//        public String ? Name { get; set; }
//        public int Fees { get; set; }
//        public int accomodation { get; set; }
//        public void ShowDetails()
//        {
//            Console.WriteLine("Student ID " + StudentId);
//            Console.WriteLine("Name " + Name);
//            Console.WriteLine("Fees and accomodation is " + (Fees+accomodation));

//        }
    
//    }
//    }

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


////2.Create a class called student which has data members like rollno, name, class, Semester,
////branch, int [] marks = new int marks[5](marks of 5 subjects)

//// - Pass the details of student like rollno, name, class, SEM, branch in constructor
 
//// -For marks write a method called GetMarks() and give marks for all 5 subjects
 
//// -Write a method called displayresult, which should calculate the average marks
 
//// -If marks of any one subject is less than 35 print result as failed
//// -If marks of all subject is >35, but average is < 50 then also print result as failed
//// -If avg > 50 then print result as passed.
 
//// -Write a DisplayData() method to display all object members values.


//namespace Assignment3
//{
//    class Program2
//    {
//       static void Main(string[] args)
//        {
//           // Student stu = new Student();
//            Results res = new Results(56, "Rofina", "IV", 8, "ECE");
            
//            res.DisplayResults();
            
//        }
//    }

//    class Student
//    {
//        protected int RollNo;
//        protected string ? Name;
//        protected string ? Cls;
//        protected int  Sem;
//        protected string ? Branch;
//        protected int[] marks = new int[5];

//        public Student(int rollno,string name,string cls,int sem,string branch)
//        {
//            RollNo = rollno;
//            Name = name;
//            Cls = cls;
//            Sem = sem;
//            Branch = branch;
//        }
//        protected void DisplayDetails()
//        {
//            Console.WriteLine($"Name :{Name}");
//            Console.WriteLine($"cls :{Cls}");
//            Console.WriteLine($"Rollno :{RollNo}");
//            Console.WriteLine($"Sem :{Sem}");
//            Console.WriteLine($"Branch :{Branch}");
//        }
//        protected void GetMarks()
//        {
//            Console.WriteLine("Give all the marks");
//            for(int i = 0; i < 5; i++)
//            {
//                marks[i] = Convert.ToInt32(Console.ReadLine());
//            }
//        }

      

//    }

//    class Results : Student
//    {
       
//        public Results(int rollno, string name,string cls,int sem,string branch) : base(rollno, name, cls, sem, branch)
//        {
//            GetMarks();
//            DisplayDetails();
//        }
       
//        public void DisplayResults()
//        {

//            float avg = 0.0f;
//            int total = 0;
//            int count = 0;
//            for (int i = 0; i < 5; i++)
//            {
//                if (marks[i] < 35)
//                {
//                    Console.WriteLine("Fail in a subject");
//                    count++;
//                }
//                total += marks[i];
//            }
//            avg = (float)total / 5;
//            if (count > 0)
//            {
//                Console.WriteLine($"Student is fail and failed in {count} subjects and average is {avg}");
//            }
//            else
//            {
//                Console.WriteLine($"Student is pass and average is {avg}");
//            }
//        }

//    }

//}

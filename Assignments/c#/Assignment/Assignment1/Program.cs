using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;


//Task 1: Define Classes  
namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 2: Implement Constructors
            Students students = new Students(1, "john", "smith",new DateTime(2005,05,15), "johnsmith@gmail.com", 9865758962);
            students.DisplayStudentInfo(1);
            //Students students2 = new Students();
            //students2.UpdateStudentInfo(2, "Nazeem", "Rofina", new DateTime(2003, 11, 08), "nazeemrofina@gmail.com", 9865258963);
            //students2.DisplayStudentInfo(2);
            //students.DisplayStudentInfo(1);
            Courses courses = new Courses(2001, "Physics", 101, "Ariel");
            Enrollments enrollments = new Enrollments(121, 1, 2001, new DateTime(2024, 11, 08));
            Teacher teacher = new Teacher(1001, "Ariel", "Benya", "ariel.banya@example.com");
            Payments payments = new Payments(301, 1, 15000, new DateTime(2024, 11, 07));

        }
    }
    class Students
    {
        private int Student_ID;
        string First_Name;
        string Last_Name;
        DateTime Date_Of_Birth;
        string Email;
        long Phone_Number;
        public List<Courses> ListCourse = new List<Courses>();
        public List<Payments> payment = new List<Payments>();
        public Students()
        {

        }
        public Students(int student_id, string First_Name,string Last_Name,DateTime Date_Of_Birth,string Email,long Phone_Number)
        {
            this.Student_ID = student_id;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Date_Of_Birth = Date_Of_Birth;
            this.Email = Email;
            this.Phone_Number = Phone_Number;
        }
        public  void EnrollInCourse()
        {
           
            
        }

        public void UpdateStudentInfo(int student_id, string First_Name, string Last_Name, DateTime Date_Of_Birth, string Email, long Phone_Number)
        {
            this.Student_ID = student_id;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Date_Of_Birth = Date_Of_Birth;
            this.Email = Email;
            this.Phone_Number = Phone_Number;
        }
        public void MakePayment()
        {
            //  amount: decimal, paymentDate: DateTime

        }
        public void DisplayStudentInfo(int Student_id)
        {
            if (this.Student_ID == Student_id)
            {
                Console.WriteLine($"Student ID = {Student_ID}");
                Console.WriteLine($"First Name = {First_Name}");
                Console.WriteLine($"Last Name  = {Last_Name}");
                Console.WriteLine($"Date Of Birth = {Date_Of_Birth}");
                Console.WriteLine($"Email = {Email}");
                Console.WriteLine($"Phone Number = {Phone_Number}");

            }
        }
        public  List<Courses> GetEnrolledCourses()
        {
            return ListCourse;

        }
        public List<Payments> GetPaymentHistory()
        {
            return payment;
        }
       
    }

    class Courses
    {
        int Course_ID;
        string Course_Name;
        int Course_Code;
        string Instructor_Name;
        public List<Courses> c = new List<Courses>();
        public Courses(int Course_ID,string Course_Name,int Course_Code,string Instructor_Name)
        {
            this.Course_ID = Course_ID;
            this.Course_Name = Course_Name;
            this.Course_Code = Course_Code;
            this.Instructor_Name = Instructor_Name;
        }

        public void AssignTeacher(int course_id,string Instrucor_Name)
        {
           if(this.Course_ID == course_id)
            {
                this.Instructor_Name = Instructor_Name;
            }

        }
        public void UpdateCourseInfo(int course_id,string course_name,int course_code,string instructor_name)
        {
            if (this.Course_ID == course_id)
            {
                this.Course_Name = course_name;
                this.Course_Code = course_code;
                this.Instructor_Name = instructor_name;
            }

        }
        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course ID = " + Course_ID);
            Console.WriteLine("Course Name = " + Course_Name);
            Console.WriteLine("Instructor Name = " + Instructor_Name);

        }

        public List<Courses> GetEnrollments()
        {
            return c;

        }
        public string GetTeachers()
        {

            return Instructor_Name;
        }
    }

    class Enrollments
    {
        int Enrollment_ID;
        int Student_ID;
        int Course_ID;
        DateTime Enrollment_Date;
        public Enrollments(int Enrollment_ID,int Student_ID,int Course_ID,DateTime Enrollment_Date)
        {
            this.Enrollment_ID = Enrollment_ID;
            this.Student_ID = Student_ID;
            this.Course_ID = Course_ID;
            this.Enrollment_Date = Enrollment_Date;

        }

        public int GetStudent()
        {
            return Student_ID;

        }

        public int GetCourse()
        {
            return Course_ID;
        }
    }

    class Teacher
    {
        int Teacher_ID;
        string First_Name;
        string Last_Name;
        string Email;
        public List<Courses> ListCourse = new List<Courses>;
        public Teacher(int Teacher_ID,string First_Name,string Last_Name,string Email)
        {
            this.Teacher_ID = Teacher_ID;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email = Email;
        }

        public void UpdateTeacherInfo(int Teacher_ID, string First_Name, string Last_Name, string Email)
        {
            this.Teacher_ID = Teacher_ID;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email = Email;
        }
        public void DisplayTeacherInfo()
        {

            Console.WriteLine("Teacher ID = " + Teacher_ID);
            Console.WriteLine("Name = " + First_Name +" "+Last_Name);
            Console.WriteLine("Email ID = " + Email);
        }
        public List<Courses> GetAssignedCourses()
        {
            return ListCourse;
        }
    }

    class Payments
    {
        int Payment_ID;
        int Student_ID;
        long Amount;
        DateTime Payment_Date;
        public Payments(int Payment_ID,int Student_ID,long Amount,DateTime Payment_Date)
        {
            this.Payment_ID = Payment_ID;
            this.Student_ID = Student_ID;
            this.Amount = Amount;
            this.Payment_Date = Payment_Date;
        }
        public void GetStudent(int payment_id)
        {
            Students s = new Students();
            s.DisplayStudentInfo(Student_ID);

        }
        public long GetPaymentAmount()
        {
            return Amount;
        }
        public DateTime GetPaymentDate()
        {
            return Payment_Date;
        }
    }
    class SIS
    {
        public void EnrollStudentInCourse()
        {

        }
        public void AssignTeacherToCourse()
        {

        }
        public void RecordPayment()
        {

        }
        public void GenerateEnrollmentReport()
        {

        }
        public void GeneratePaymentReport()
        {

        }
            public void CalculateCourseStatistics()
        {

        }

        

    }

}
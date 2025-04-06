using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Assignment.ExceptionClass;

namespace C_Assignment
{
    class Students
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public static List<Students> AllStudents = new List<Students>();
        public List<Enrollments> EnrolledCourses { get; set; }
        public List<Payments> PaymentHistory { get; set; }
        private static int enrollment_id = 0;
        private static int payment_id = 0;


        public Students(int studentID, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            EnrolledCourses = new List<Enrollments>();
            PaymentHistory = new List<Payments>();
            AllStudents.Add(this);
        }

        public void EnrollInCourse(Courses course)
        {
            try
            {
                ExceptionCode.checkDuplicateEnrollmentException(this, course);
                ExceptionCode.CheckStudentNotFoundException(this);
                ExceptionCode.CheckCourseNotFoundException(course);
                Enrollments enrollment = new Enrollments(enrollment_id++, this, course, DateTime.Now);
                ExceptionCode.checkEnrollments(this, course);
                EnrolledCourses.Add(enrollment);
            }
            catch(DuplicateEnrollmentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(StudentNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(CourseNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidEnrollmentDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateStudentInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            try {
                ExceptionCode.InvalidStudentDataException(firstName, lastName, dateOfBirth, email, phoneNumber);
                FirstName = firstName;
                LastName = lastName;
                DateOfBirth = dateOfBirth;
                Email = email;
                PhoneNumber = phoneNumber;
            }
            catch(InvalidStudentDataException e)
            {
                Console.WriteLine(e.Message);
            }
            
            }


        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            try
            {
                ExceptionCode.PaymentValidationException(amount, paymentDate);
                ExceptionCode.CheckStudentNotFoundException(this);
                Payments payment = new Payments(payment_id++, this, amount, paymentDate);
                PaymentHistory.Add(payment);
            }
            catch (PaymentValidationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student ID: {StudentID}\nName: {FirstName} {LastName}\nDOB: {DateOfBirth.ToShortDateString()}\nEmail: {Email}\nPhone: {PhoneNumber}\n");
        }

        public List<string> GetEnrolledCourses()
        {
            List<string> courses = new List<string>();
            foreach (var enrollment in EnrolledCourses)
            {
                courses.Add(enrollment.CourseID.CourseName);
            }
            return courses;
        }

        public List<Payments> GetPaymentHistory()
        {
            return PaymentHistory;
        }
    }
}

    


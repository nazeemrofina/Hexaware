using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Assignment.ExceptionClass;

namespace C_Assignment
{
    class SIS
    {
        public void EnrollStudentInCourse(Students student, Courses course)
        {
            try
            {
                student.EnrollInCourse(course);
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Enrollment failed : {ex.Message}");
            }
        }

        public void AssignTeacherToCourse(Teachers teacher, Courses course)
        {
            course.AssignTeacher(teacher);
        }

        public void RecordPayment(Students student, decimal amount, DateTime paymentDate)
        {
            student.MakePayment(amount, paymentDate);
        }

        public List<string> GenerateEnrollmentReport(Courses course)
        {
            List<string> enrolledStudents = new List<string>();
            foreach (var enrollment in course.GetEnrollments(course))
            {
                enrolledStudents.Add(enrollment.StudentID.FirstName + " " + enrollment.StudentID.LastName);
            }
            return enrolledStudents;
        }

        public List<string> GeneratePaymentReport(Students student)
        {
            List<string> paymentReport = new List<string>();
            foreach (var payment in student.GetPaymentHistory())
            {
                paymentReport.Add($"Amount: {payment.Amount}, Date: {payment.PaymentDate.ToShortDateString()}");
            }
            return paymentReport;
        }

        public (int, decimal) CalculateCourseStatistics(Courses course)
        {
            int enrollmentCount = 0;
            decimal totalPayments = 0;

            foreach (var enrollment in course.GetEnrollments(course))
            {
                enrollmentCount++;
                foreach (var payment in enrollment.StudentID.GetPaymentHistory())
                {
                    totalPayments += payment.Amount;
                }
            }

            return (enrollmentCount, totalPayments);
        }

        public void AddStudent()
        {
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
                DateTime dob = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine();
                int id = Students.AllStudents.Count + 1;
                ExceptionCode.InvalidStudentDataException(firstName, lastName, dob, email, phone);
                Students newStudent = new Students(id, firstName, lastName, dob, email, phone);
                Console.WriteLine("Student successfully added");
            }
            catch(InvalidStudentDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayAllStudents()
        {
            foreach (var student in Students.AllStudents)
            {
                student.DisplayStudentInfo();
            }
        }

        public void EnrollStudentInCourse()
        {
            Console.Write("Enter Student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Course ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            foreach (var student in Students.AllStudents)
            {

                if (student.StudentID == studentId)
                {
                    foreach (var course in Courses.AllCourses)
                    {

                        if (course.CourseID == courseId)
                        {
                            student.EnrollInCourse(course);
                            Console.WriteLine("Successfully Enrolled");
                            return;
                        }
                    }
                }
            }

        Console.WriteLine("Enrollment failed: Student or Course not found.");
        }

        public void AddTeacher()
        {
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                Console.Write("Enter Area of Expertise: ");
                string expertise = Console.ReadLine();
                int id = Teachers.AllTeachers.Count + 1;
                ExceptionCode.InvalidTeacherDataException(firstName, lastName, email, expertise);
                new Teachers(id, firstName, lastName, email, expertise);
            }
           catch(InvalidTeacherDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisplayAllTeachers()
        {
            foreach (var teacher in Teachers.AllTeachers)
            {
                teacher.DisplayTeacherInfo();
            }
        }

        public void AddCourse()
        {
            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Course Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Instructor Name: ");
            string instructor = Console.ReadLine();
            int id = Courses.AllCourses.Count + 1;

            new Courses(id, name, code, instructor);
        }

        public void DisplayAllCourses()
        {
            foreach (var course in Courses.AllCourses)
            {
                course.DisplayCourseInfo();
            }
        }

        public void AssignTeacherToCourse()
        {
            Console.Write("Enter Teacher ID: ");
            int teacherId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Course ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            foreach (var teacher in Teachers.AllTeachers)
            {
                if (teacher.TeacherID == teacherId)
                {
                    foreach (var course in Courses.AllCourses)
                    {
                        if (course.CourseID == courseId)
                        {
                            course.AssignTeacher(teacher);
                            Console.WriteLine("Successfully Assigned");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Assignment failed Teacher or Course not found.");
        }

        public void MakeStudentPayment()
        {
            Console.Write("Enter Student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Date (yyyy-mm-dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            foreach (var student in Students.AllStudents)
            {
                try
                {
                    if (student.StudentID == studentId)
                    {
                        ExceptionCode.PaymentValidationException(amount, date);
                        ExceptionCode.InsufficientFundsException(amount);
                        student.MakePayment(amount, date);
                        Console.WriteLine("Payment Successfull");
                        return;
                    }
                }
                catch(PaymentValidationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(InsufficientFundsException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Payment failed: Student not found.");
        }
        public void GetEnrollmentsForStudent()
        {
            Console.WriteLine("Enter student id");
            int Student_id=Convert.ToInt32(Console.ReadLine());
            foreach(var student in Students.AllStudents)
            {
                if (Student_id == student.StudentID)
                {
                    List<string> EnrolledCourses=student.GetEnrolledCourses();
                    foreach(var course in EnrolledCourses)
                    {
                        Console.WriteLine("Courses enrolled are " + course);
                    }
                }
            }

        }
        public void GetCoursesForTeacher()
        {
            Console.WriteLine("Enter teacher name");
            string teacherName = Console.ReadLine();
            foreach(var teacher in Teachers.AllTeachers)
            {
                if(teacher.FirstName+" "+teacher.LastName== teacherName)
                {
                    foreach(var courses in teacher.GetAssignedCourse())
                    {
                        Console.WriteLine(courses.CourseName);
                    }
                }
            }
        }

    }
}
